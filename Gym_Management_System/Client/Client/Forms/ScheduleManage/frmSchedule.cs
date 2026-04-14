using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Client.Forms.ScheduleManage
{
    public partial class frmSchedule : Form
    {
        // 1. Chuỗi kết nối Database chuẩn
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementSystem;Integrated Security=True";

        // 2. Biến lưu ID của lịch tập đang được chọn
        string selectedScheduleId = "";

        public frmSchedule()
        {
            InitializeComponent();
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            LoadComboBoxData(); // Tải HLV và Hội viên vào Combobox trước
            LoadData();         // Tải danh sách lịch tập vào Bảng DataGridView
        }

        // --- HÀM 1: TẢI DANH SÁCH LỊCH TẬP VÀO BẢNG (DATAGRIDVIEW) ---
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.schedule_id, 
                                s.employee_id, e.employee_name, 
                                s.member_id, m.member_name, 
                                s.schedule_date, s.session_start, s.session_end, 
                                s.session_status, 
                                CASE 
                                    WHEN s.session_status = 1 THEN N'Hoạt động' 
                                    ELSE N'Dừng hoạt động' 
                                END AS status_name
                         FROM Schedule s
                         LEFT JOIN Employee e ON s.employee_id = e.employee_id
                         LEFT JOIN Member m ON s.member_id = m.member_id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvScheduleManage.DataSource = dt;

                // --- THÊM 3 DÒNG NÀY ĐỂ ÉP BẢNG CHỈ HIỂN THỊ GIỜ ---
                if (dgvScheduleManage.Columns["session_start"] != null)
                    dgvScheduleManage.Columns["session_start"].DefaultCellStyle.Format = "HH:mm"; // HH:mm là định dạng 24h

                if (dgvScheduleManage.Columns["session_end"] != null)
                    dgvScheduleManage.Columns["session_end"].DefaultCellStyle.Format = "HH:mm";

                // (Tùy chọn) Format luôn cột ngày để ẩn cái 12:00 AM đi cho gọn
                if (dgvScheduleManage.Columns["schedule_date"] != null)
                    dgvScheduleManage.Columns["schedule_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                // --- ĐỔI TÊN TIÊU ĐỀ CỘT SANG TIẾNG VIỆT ---
                if (dgvScheduleManage.Columns["employee_name"] != null)
                    dgvScheduleManage.Columns["employee_name"].HeaderText = "Huấn luyện viên";

                if (dgvScheduleManage.Columns["member_name"] != null)
                    dgvScheduleManage.Columns["member_name"].HeaderText = "Hội viên";

                if (dgvScheduleManage.Columns["schedule_date"] != null)
                    dgvScheduleManage.Columns["schedule_date"].HeaderText = "Ngày tập";

                if (dgvScheduleManage.Columns["session_start"] != null)
                    dgvScheduleManage.Columns["session_start"].HeaderText = "Giờ bắt đầu";

                if (dgvScheduleManage.Columns["session_end"] != null)
                    dgvScheduleManage.Columns["session_end"].HeaderText = "Giờ kết thúc";

                if (dgvScheduleManage.Columns["status_name"] != null)
                    dgvScheduleManage.Columns["status_name"].HeaderText = "Trạng thái";

                if (dgvScheduleManage.Columns["employee_id"] != null)
                    dgvScheduleManage.Columns["employee_id"].Visible = false;

                if (dgvScheduleManage.Columns["member_id"] != null)
                    dgvScheduleManage.Columns["member_id"].Visible = false;

                if (dgvScheduleManage.Columns["session_status"] != null)
                    dgvScheduleManage.Columns["session_status"].Visible = false;

                // (Tùy chọn) Bạn có thể ẩn luôn schedule_id nếu không muốn hiển thị đoạn mã GUID dài ngoằng
                if (dgvScheduleManage.Columns["schedule_id"] != null)
                    dgvScheduleManage.Columns["schedule_id"].Visible = false;
            }
        }

        // --- HÀM 2: TẢI DỮ LIỆU LÊN CÁC Ô CHỌN (COMBOBOX) ---
        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Tải Huấn Luyện Viên
                string queryTrainer = "SELECT employee_id, employee_name FROM Employee WHERE login_key = 'trainer' AND is_active = 1";
                SqlDataAdapter daTrainer = new SqlDataAdapter(queryTrainer, conn);
                DataTable dtTrainer = new DataTable();
                daTrainer.Fill(dtTrainer);
                cmbTrainer.DataSource = dtTrainer;
                cmbTrainer.DisplayMember = "employee_name";
                cmbTrainer.ValueMember = "employee_id";

                // 2. Tải Hội Viên 
                string queryMember = "SELECT member_id, member_name FROM Member";
                SqlDataAdapter daMember = new SqlDataAdapter(queryMember, conn);
                DataTable dtMember = new DataTable();
                daMember.Fill(dtMember);
                cmbMember.DataSource = dtMember;
                cmbMember.DisplayMember = "member_name";
                cmbMember.ValueMember = "member_id";
            }
        }

        // --- NÚT LÀM MỚI (Xóa rỗng các ô nhập) ---
        private void button3_Click(object sender, EventArgs e)
        {
            cmbTrainer.SelectedIndex = -1;
            cmbMember.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            txtTime.Text = "";
            txtEndTime.Text = "";
            selectedScheduleId = "";

            // Mặc định chọn nút Đã kích hoạt khi làm mới
            rdoKichHoat.Checked = true;
        }

        // --- CLICK VÀO BẢNG: ĐẨY DỮ LIỆU LÊN Ô NHẬP ---
        private void dgvScheduleManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvScheduleManage.Rows[e.RowIndex];

                // Lấy ID lịch tập
                selectedScheduleId = row.Cells["schedule_id"].Value.ToString();

                if (row.Cells["schedule_id"].Value != DBNull.Value)
                {
                    txtScheduleId.Text = row.Cells["schedule_id"].Value.ToString();
                }
                // Đẩy dữ liệu lên các Combobox
                cmbTrainer.SelectedValue = row.Cells["employee_id"].Value;
                cmbMember.SelectedValue = row.Cells["member_id"].Value;

                // Xử lý ngày tháng
                if (row.Cells["schedule_date"].Value != DBNull.Value)
                {
                    dtpDate.Value = Convert.ToDateTime(row.Cells["schedule_date"].Value);
                }

                // Xử lý giờ bắt đầu và kết thúc
                if (row.Cells["session_start"].Value != DBNull.Value)
                {
                    txtTime.Text = Convert.ToDateTime(row.Cells["session_start"].Value).ToString("HH:mm");
                }

                if (row.Cells["session_end"].Value != DBNull.Value)
                {
                    txtEndTime.Text = Convert.ToDateTime(row.Cells["session_end"].Value).ToString("HH:mm");
                }

                // Xử lý Check RadioButton Trạng thái
                if (row.Cells["session_status"].Value != DBNull.Value)
                {
                    int status = Convert.ToInt32(row.Cells["session_status"].Value);
                    if (status == 1)
                    {
                        rdoKichHoat.Checked = true;
                    }
                    else
                    {
                        rdoChuaKichHoat.Checked = true;
                    }
                }
            }
        }

        // --- NÚT THÊM LỊCH TẬP ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTrainer.SelectedValue == null || cmbMember.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Huấn luyện viên và Hội viên!", "Cảnh báo");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Schedule (employee_id, member_id, schedule_date, session_start, session_end, session_status) " +
                               "VALUES (@employeeId, @memberId, @date, @start, @end, @status)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@employeeId", cmbTrainer.SelectedValue);
                cmd.Parameters.AddWithValue("@memberId", cmbMember.SelectedValue);
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@start", txtTime.Text);
                cmd.Parameters.AddWithValue("@end", txtEndTime.Text);

                // Kiểm tra RadioButton để lưu trạng thái
                int statusValue = 0;
                if (rdoKichHoat.Checked == true)
                {
                    statusValue = 1;
                }
                cmd.Parameters.AddWithValue("@status", statusValue);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm lịch tập thành công!", "Thông báo");

                LoadData();
                button3_Click(sender, e); // Xóa trắng form sau khi thêm
            }
        }

        // --- NÚT CẬP NHẬT (SỬA) ---
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedScheduleId))
            {
                MessageBox.Show("Vui lòng click chọn một lịch tập dưới bảng để cập nhật!", "Cảnh báo");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Cập nhật đủ thông tin HLV, Hội viên, Giờ giấc VÀ TRẠNG THÁI
                string query = "UPDATE Schedule SET employee_id = @employeeId, member_id = @memberId, " +
                               "schedule_date = @date, session_start = @start, session_end = @end, session_status = @status " +
                               "WHERE schedule_id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@employeeId", cmbTrainer.SelectedValue);
                cmd.Parameters.AddWithValue("@memberId", cmbMember.SelectedValue);
                cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@start", txtTime.Text);
                cmd.Parameters.AddWithValue("@end", txtEndTime.Text);
                cmd.Parameters.AddWithValue("@id", selectedScheduleId);

                // Kiểm tra RadioButton để lưu trạng thái
                int statusValue = 0;
                if (rdoKichHoat.Checked == true)
                {
                    statusValue = 1;
                }
                cmd.Parameters.AddWithValue("@status", statusValue);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật lịch tập thành công!", "Thông báo");

                LoadData();
                button3_Click(sender, e); // Xóa trắng form sau khi sửa
            }
        }

        // --- NÚT XÓA ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedScheduleId))
            {
                MessageBox.Show("Vui lòng click chọn một lịch tập dưới bảng để xóa!", "Cảnh báo");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa lịch tập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Schedule WHERE schedule_id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedScheduleId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa lịch tập!", "Thông báo");

                    LoadData();
                    button3_Click(sender, e);
                }
            }
        }

        // Các hàm rỗng giữ lại để tránh lỗi giao diện
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void cmbTrainer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtScheduleId_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}