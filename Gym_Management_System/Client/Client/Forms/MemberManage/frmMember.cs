using Client.DataContext;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client.Forms.MemberManage
{
    public partial class frmMember : Form
    {
        private Guid? _selectedMemberId;
        private bool _readyForFilterEvents;
        /// <summary>
        /// Khi true, bỏ qua SelectionChanged để tránh nạp lại form sau khi gán DataSource (thường auto-chọn dòng đầu).
        /// </summary>
        private bool _suppressGridSelectionSync;

        public frmMember()
        {
            InitializeComponent();
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            dgvMembers.AutoGenerateColumns = true;
            cmbFilter.SelectedIndex = 0;
            LoadPackages();
            LoadPaymentMethods();
            LoadMembers();
            _readyForFilterEvents = true;
        }

        private void LoadPackages()
        {
            try
            {
                var list = new List<Package>();
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT package_id, package_name, duration, price, with_trainer, is_active FROM dbo.Package WHERE is_active = 1 ORDER BY package_name",
                    conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Package
                            {
                                PackageId = (Guid)r["package_id"],
                                PackageName = r["package_name"].ToString(),
                                Duration = (int)r["duration"],
                                Price = (int)r["price"],
                                WithTrainer = (bool)r["with_trainer"],
                                IsActive = (bool)r["is_active"]
                            });
                        }
                    }
                }

                cmbPackage.DataSource = list;
                cmbPackage.DisplayMember = "PackageName";
                cmbPackage.ValueMember = "PackageId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách gói tập.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentMethods()
        {
            try
            {
                var table = new DataTable();
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand("SELECT method_id, method_name FROM dbo.PaymentMethod ORDER BY method_id", conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }

                cmbPayment.DataSource = table;
                cmbPayment.DisplayMember = "method_name";
                cmbPayment.ValueMember = "method_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được hình thức thanh toán.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMembers()
        {
            try
            {
                var dt = new DataTable();
                string sql =
                    "SELECT m.member_id, m.member_name, " +
                    "CASE WHEN m.gender = 1 THEN N'Nam' ELSE N'Nữ' END AS gender_display, " +
                    "m.date_of_birth, m.age, m.phone_number, m.email, m.remaining_duration, m.register_date, " +
                    "CASE WHEN m.has_trainer = 1 THEN N'Có' ELSE N'Không' END AS has_trainer_display, " +
                    "CASE WHEN m.is_expired = 1 THEN N'Hết hạn' ELSE N'Còn hạn' END AS expired_display, " +
                    "CASE WHEN m.is_active = 1 THEN N'Có' ELSE N'Không' END AS active_display " +
                    "FROM dbo.Member m WHERE 1 = 1";

                var conditions = new List<string>();

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    conditions.Add("(m.member_name LIKE @search OR m.phone_number LIKE @search)");
                }

                switch (cmbFilter.SelectedIndex)
                {
                    case 1:
                        conditions.Add("m.is_expired = 0 AND m.is_active = 1 AND m.remaining_duration > 0");
                        break;
                    case 2:
                        conditions.Add("(m.is_expired = 1 OR m.remaining_duration <= 0)");
                        break;
                    case 3:
                        conditions.Add("m.remaining_duration > 0 AND m.remaining_duration <= 7 AND m.is_expired = 0");
                        break;
                }

                if (conditions.Count > 0)
                {
                    sql += " AND " + string.Join(" AND ", conditions);
                }

                sql += " ORDER BY m.member_name";

                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                dgvMembers.DataSource = dt;

                if (dgvMembers.Columns.Contains("member_id"))
                {
                    dgvMembers.Columns["member_id"].Visible = false;
                }

                SetColumnHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách hội viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetColumnHeaders()
        {
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "member_name", "Họ tên" },
                { "gender_display", "Giới tính" },
                { "date_of_birth", "Ngày sinh" },
                { "age", "Tuổi" },
                { "phone_number", "Số ĐT" },
                { "email", "Email" },
                { "remaining_duration", "Ngày còn lại" },
                { "register_date", "Ngày đăng ký" },
                { "has_trainer_display", "HLV kèm" },
                { "expired_display", "Hết hạn" },
                { "active_display", "Hoạt động" }
            };

            foreach (DataGridViewColumn col in dgvMembers.Columns)
            {
                if (map.TryGetValue(col.Name, out string title))
                {
                    col.HeaderText = title;
                }

                if (col.Name == "date_of_birth" || col.Name == "register_date")
                {
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppressGridSelectionSync)
            {
                return;
            }

            if (dgvMembers.CurrentRow == null || dgvMembers.CurrentRow.IsNewRow)
            {
                return;
            }

            DataRowView rowView = dgvMembers.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null)
            {
                return;
            }

            object idObj = rowView["member_id"];
            if (idObj == null || idObj == DBNull.Value)
            {
                return;
            }

            Guid memberId = (Guid)idObj;
            _selectedMemberId = memberId;
            LoadMemberToForm(memberId);
        }

        private void LoadMemberToForm(Guid memberId)
        {
            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT member_name, gender, date_of_birth, age, phone_number, email, remaining_duration, register_date, has_trainer, is_expired, is_active " +
                    "FROM dbo.Member WHERE member_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberId);
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            return;
                        }

                        txtMemberName.Text = r["member_name"].ToString();
                        bool gender = (bool)r["gender"];
                        rdoNam.Checked = gender;
                        rdoNu.Checked = !gender;
                        dtpDOB.Value = ((DateTime)r["date_of_birth"]).Date;
                        txtPhone.Text = r["phone_number"].ToString();
                        txtEmail.Text = r["email"].ToString();
                        dtpRegister.Value = ((DateTime)r["register_date"]).Date;
                        numRemaining.Value = Math.Min(numRemaining.Maximum, Math.Max(numRemaining.Minimum, Convert.ToDecimal(r["remaining_duration"])));
                        chkHasTrainer.Checked = (bool)r["has_trainer"];
                        chkMemberActive.Checked = (bool)r["is_active"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được chi tiết hội viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int ComputeAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private bool TryValidateInput(out string error)
        {
            error = null;

            if (string.IsNullOrWhiteSpace(txtMemberName.Text))
            {
                error = "Vui lòng nhập họ tên.";
                return false;
            }

            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^\d{10,11}$"))
            {
                error = "Số điện thoại phải có 10–11 chữ số.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                error = "Vui lòng nhập email.";
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text.Trim());
                if (addr.Address != txtEmail.Text.Trim())
                {
                    error = "Email không hợp lệ.";
                    return false;
                }
            }
            catch
            {
                error = "Email không hợp lệ.";
                return false;
            }

            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_readyForFilterEvents)
            {
                return;
            }

            LoadMembers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _suppressGridSelectionSync = true;
            try
            {
                _selectedMemberId = null;
                txtSearch.Clear();
                cmbFilter.SelectedIndex = 0;
                LoadMembers();
                dgvMembers.ClearSelection();
                ResetMemberDetailInputs();
            }
            finally
            {
                _suppressGridSelectionSync = false;
            }
        }

        /// <summary>
        /// Xóa nội dung phần thông tin hội viên và đăng ký gói (không đụng ô tìm / bộ lọc — đã xử lý trước đó).
        /// </summary>
        private void ResetMemberDetailInputs()
        {
            txtMemberName.Clear();
            rdoNam.Checked = true;
            dtpDOB.Value = DateTime.Today.AddYears(-20);
            txtPhone.Clear();
            txtEmail.Clear();
            dtpRegister.Value = DateTime.Today;
            numRemaining.Value = 0;
            chkHasTrainer.Checked = false;
            chkMemberActive.Checked = true;
            ClearPackageRegistrationFields();
        }

        /// <summary>
        /// Bỏ chọn gói tập và hình thức thanh toán (nhóm đăng ký gói).
        /// </summary>
        private void ClearPackageRegistrationFields()
        {
            if (cmbPackage.Items.Count > 0)
            {
                cmbPackage.SelectedIndex = -1;
            }

            if (cmbPayment.Items.Count > 0)
            {
                cmbPayment.SelectedIndex = -1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryValidateInput(out string err))
            {
                MessageBox.Show(err, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = Guid.NewGuid();
            DateTime dob = dtpDOB.Value.Date;
            int age = ComputeAge(dob);
            bool gender = rdoNam.Checked;
            int remaining = (int)numRemaining.Value;
            bool expired = remaining <= 0;

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.Member (member_id, member_name, gender, date_of_birth, age, phone_number, email, remaining_duration, register_date, has_trainer, is_expired, is_active) " +
                    "VALUES (@id, @name, @gender, @dob, @age, @phone, @email, @remaining, @reg, @hasTrainer, @expired, @active)",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", txtMemberName.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@remaining", remaining);
                    cmd.Parameters.AddWithValue("@reg", dtpRegister.Value.Date);
                    cmd.Parameters.AddWithValue("@hasTrainer", chkHasTrainer.Checked);
                    cmd.Parameters.AddWithValue("@expired", expired);
                    cmd.Parameters.AddWithValue("@active", chkMemberActive.Checked);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã thêm hội viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được hội viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMemberId == null)
            {
                MessageBox.Show("Chọn một hội viên trong danh sách để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryValidateInput(out string err))
            {
                MessageBox.Show(err, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid id = _selectedMemberId.Value;
            DateTime dob = dtpDOB.Value.Date;
            int age = ComputeAge(dob);
            bool gender = rdoNam.Checked;
            int remaining = (int)numRemaining.Value;
            bool expired = remaining <= 0;

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.Member SET member_name = @name, gender = @gender, date_of_birth = @dob, age = @age, phone_number = @phone, email = @email, " +
                    "remaining_duration = @remaining, register_date = @reg, has_trainer = @hasTrainer, is_expired = @expired, is_active = @active " +
                    "WHERE member_id = @id",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", txtMemberName.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@remaining", remaining);
                    cmd.Parameters.AddWithValue("@reg", dtpRegister.Value.Date);
                    cmd.Parameters.AddWithValue("@hasTrainer", chkHasTrainer.Checked);
                    cmd.Parameters.AddWithValue("@expired", expired);
                    cmd.Parameters.AddWithValue("@active", chkMemberActive.Checked);

                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("Không tìm thấy hội viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                MessageBox.Show("Đã cập nhật hội viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không cập nhật được hội viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMemberId == null)
            {
                MessageBox.Show("Chọn một hội viên trong danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xóa hội viên đã chọn? Các lịch hẹn và hóa đơn liên quan cũng sẽ bị xóa.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Guid id = _selectedMemberId.Value;

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Schedule WHERE member_id = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Receipt WHERE member_id = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Member WHERE member_id = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                _selectedMemberId = null;
                MessageBox.Show("Đã xóa hội viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được hội viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterPackage_Click(object sender, EventArgs e)
        {
            if (_selectedMemberId == null)
            {
                MessageBox.Show("Chọn hội viên trong danh sách trước khi đăng ký gói.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbPackage.SelectedValue == null || cmbPayment.SelectedValue == null)
            {
                MessageBox.Show("Chọn gói tập và hình thức thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid memberId = _selectedMemberId.Value;
            Guid packageId = (Guid)cmbPackage.SelectedValue;
            int paymentMethodId = Convert.ToInt32(cmbPayment.SelectedValue);

            Package pkg = cmbPackage.SelectedItem as Package;
            if (pkg == null)
            {
                MessageBox.Show("Không đọc được thông tin gói.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO dbo.Receipt (receipt_id, member_id, package_id, total_amount, payment_date, payment_method) " +
                                "VALUES (@rid, @mid, @pid, @amount, @pdate, @pmethod)",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@rid", Guid.NewGuid());
                                cmd.Parameters.AddWithValue("@mid", memberId);
                                cmd.Parameters.AddWithValue("@pid", packageId);
                                cmd.Parameters.AddWithValue("@amount", pkg.Price);
                                cmd.Parameters.AddWithValue("@pdate", DateTime.Today);
                                cmd.Parameters.AddWithValue("@pmethod", paymentMethodId);
                                cmd.ExecuteNonQuery();
                            }

                            // Package.duration = số tháng; Member.remaining_duration = số ngày (ước lượng 30 ngày/tháng)
                            int addDays = pkg.Duration * 30;
                            using (SqlCommand cmd = new SqlCommand(
                                "UPDATE dbo.Member SET " +
                                "remaining_duration = remaining_duration + @dur, " +
                                "has_trainer = CASE WHEN @wtrainer = 1 THEN 1 ELSE has_trainer END, " +
                                "is_expired = 0, is_active = 1 " +
                                "WHERE member_id = @mid",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@dur", addDays);
                                cmd.Parameters.AddWithValue("@wtrainer", pkg.WithTrainer);
                                cmd.Parameters.AddWithValue("@mid", memberId);
                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Đã ghi nhận thanh toán và cập nhật thời hạn gói.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                LoadMemberToForm(memberId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đăng ký gói được.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvMembers.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV|*.csv";
                dlg.FileName = "hoi-vien-" + DateTime.Now.ToString("yyyyMMdd-HHmm", CultureInfo.InvariantCulture) + ".csv";
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    var sb = new StringBuilder();
                    bool first = true;
                    foreach (DataGridViewColumn col in dgvMembers.Columns)
                    {
                        if (!col.Visible)
                        {
                            continue;
                        }

                        if (!first)
                        {
                            sb.Append(',');
                        }

                        first = false;
                        sb.Append(EscapeCsv(col.HeaderText));
                    }

                    sb.AppendLine();

                    foreach (DataGridViewRow row in dgvMembers.Rows)
                    {
                        if (row.IsNewRow)
                        {
                            continue;
                        }

                        first = true;
                        foreach (DataGridViewColumn col in dgvMembers.Columns)
                        {
                            if (!col.Visible)
                            {
                                continue;
                            }

                            if (!first)
                            {
                                sb.Append(',');
                            }

                            first = false;
                            object v = row.Cells[col.Index].FormattedValue;
                            sb.Append(EscapeCsv(v != null ? v.ToString() : ""));
                        }

                        sb.AppendLine();
                    }

                    File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                    MessageBox.Show("Đã xuất file.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không ghi được file.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string EscapeCsv(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "\"\"";
            }

            if (s.IndexOfAny(new[] { '"', ',', '\r', '\n' }) >= 0)
            {
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            }

            return s;
        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
