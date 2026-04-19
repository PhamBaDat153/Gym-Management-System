using Client.DataContext;
using Client.Models;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace Client.Forms.EmployeeManage
{
    public partial class frmEmployee : Form
    {
        private SqlConnection connection;
        private String choosenEmployeeId;
        public Employee choosenEmployee;
        
        private string selectedImagePath;
        private readonly Cloudinary cloudinary;

        public frmEmployee()
        {
            InitializeComponent();
            txtDOB.MaxDate = DateTime.Today.AddDays(-1);
            txtDOB.Value = DateTime.Today.AddYears(-18);
            pictureEmployee.Click += pictureEmployee_Click;
            pictureEmployee.Cursor = Cursors.Hand;
            cloudinary = TryCreateCloudinary();
        }

        #region Shared

        // Phương thức load data từ database vào DataGridView
        public void loadData(SqlCommand cmd)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                if (cmd == null)
                {
                    throw new ArgumentNullException(nameof(cmd));
                }

                connection = GymManagementSystemContext.Connect();
                if (connection == null)
                {
                    throw new Exception("Không thể kết nối đến database.");
                }
                cmd.Connection = connection;
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeId = (Guid)reader["employee_id"],
                        LoginKey = reader["login_key"].ToString(),
                        Password = reader["password"].ToString(),
                        Email = reader["email"].ToString(),
                        ImageUrl = reader["image_url"] == DBNull.Value ? null : reader["image_url"].ToString(),
                        EmployeeName = reader["employee_name"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        DateOfBirth = (DateTime)reader["date_of_birth"],
                        Salary = (int)reader["salary"],
                        HireDate = (DateTime)reader["hire_date"],
                        Status = (bool)reader["status"],
                        IsActive = (bool)reader["is_active"],
                        Roles = new List<Role>()
                    };

                    employees.Add(employee);
                }

                reader.Close();

                foreach (Employee employee in employees)
                {
                    cmd.CommandText = "SELECT r.role_name " +
                                      "FROM dbo.EmployeeRole er " +
                                      "JOIN dbo.Role r ON er.role_id = r.role_id " +
                                      "WHERE er.employee_id = @employeeId";

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@employeeId", employee.EmployeeId);

                    SqlDataReader roleReader = cmd.ExecuteReader();
                    List<Role> roles = new List<Role>();

                    while (roleReader.Read())
                    {
                        roles.Add(new Role
                        {
                            RoleName = roleReader["role_name"].ToString()
                        });
                    }

                    roleReader.Close();
                    employee.Roles = roles;
                }

                connection.Close();

                if (dgvEmployee == null)
                {
                    throw new Exception("DataGridView chưa được khởi tạo.");
                }

                // Ensure columns exist (defensive for runtime cases where designer columns may not be present)
                if (dgvEmployee.Columns.Count == 0)
                {
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colName", HeaderText = "Tên nhân viên" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colEmail", HeaderText = "Email" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colPhoneNumber", HeaderText = "Số điện thoại" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colRole", HeaderText = "Chức vụ" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colDOB", HeaderText = "Ngày sinh" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colHireDate", HeaderText = "Ngày nhận việc" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colSalary", HeaderText = "Lương" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colStatus", HeaderText = "Trạng thái nhân viên" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colIsActive", HeaderText = "Trạng thái tài khoản" });
                    dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colID", HeaderText = "Mã nhân viên" });
                }

                dgvEmployee.Rows.Clear();

                foreach (Employee employee in employees)
                {
                    try
                    {
                        int rowIndex = dgvEmployee.Rows.Add(
                            employee.EmployeeName,
                            employee.Email,
                            employee.PhoneNumber,
                            employee.Roles.Any() ? employee.Roles.First().RoleName : "",
                            employee.DateOfBirth.ToString("dd/MM/yyyy"),
                            employee.HireDate.ToString("dd/MM/yyyy"),
                            employee.Salary.ToString("N0"),
                            employee.Status ? "Khả dụng" : "Không khả dụng",
                            employee.IsActive ? "Đang hoạt động" : "Ngừng hoạt động",
                            employee.EmployeeId.ToString()
                        );

                        dgvEmployee.Rows[rowIndex].Tag = employee.EmployeeId;
                    }
                    catch (Exception rowEx)
                    {
                        // Skip problematic row but continue loading others
                        System.Diagnostics.Debug.WriteLine("Failed to add employee row: " + rowEx);
                    }
                }

                dgvEmployee.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách nhân viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm role vào combobox
        public void loadRoleToComboBox()
        {
            try
            {
                bool isAdmin = User.Roles.Contains("Admin");

                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand("Select * from dbo.Role", conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cbxRole.Items.Clear();
                        cbxRoleInfo.Items.Clear();

                        while (reader.Read())
                        {
                            string roleName = reader["role_name"].ToString();

                            cbxRole.Items.Add(roleName);

                            if (isAdmin || roleName == "Receptionist" || roleName == "Trainer")
                            {
                                cbxRoleInfo.Items.Add(roleName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách vai trò.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi form được load   
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Employee");
            loadData(cmd);
            loadRoleToComboBox();
           
        }

        private bool TryGetSelectedRoleId(out int roleId)
        {
            roleId = 0;

            if (cbxRoleInfo.SelectedItem == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand("SELECT role_id FROM dbo.Role WHERE role_name = @roleName", conn))
                {
                    cmd.Parameters.AddWithValue("@roleName", cbxRoleInfo.SelectedItem.ToString());
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        return false;
                    }

                    roleId = Convert.ToInt32(result);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private static Cloudinary TryCreateCloudinary()
        {
            try
            {
                string cloudName = ConfigurationManager.AppSettings["CloudinaryCloudName"];
                string apiKey = ConfigurationManager.AppSettings["CloudinaryApiKey"];
                string apiSecret = ConfigurationManager.AppSettings["CloudinaryApiSecret"];

                if (string.IsNullOrWhiteSpace(cloudName) ||
                    string.IsNullOrWhiteSpace(apiKey) ||
                    string.IsNullOrWhiteSpace(apiSecret))
                {
                    return null;
                }

                var account = new Account(cloudName.Trim(), apiKey.Trim(), apiSecret.Trim());
                return new Cloudinary(account) { Api = { Secure = true } };
            }
            catch
            {
                return null;
            }
        }

        private static bool IsHttpUrl(string value)
        {
            return Uri.TryCreate(value, UriKind.Absolute, out Uri uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        private string UploadEmployeeImageToCloudinary(string sourceFilePath, Guid employeeId)
        {
            if (cloudinary == null)
            {
                throw new InvalidOperationException("Chưa cấu hình Cloudinary trong App.config (CloudinaryCloudName/CloudinaryApiKey/CloudinaryApiSecret).");
            }

            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("Không tìm thấy file ảnh.", sourceFilePath);
            }

            string folder = ConfigurationManager.AppSettings["CloudinaryEmployeesFolder"];
            folder = string.IsNullOrWhiteSpace(folder) ? "gym/employees" : folder.Trim().Trim('/');

            var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams
            {
                File = new CloudinaryDotNet.FileDescription(sourceFilePath),
                Folder = folder,
                PublicId = "employee_" + employeeId.ToString("N"),
                Overwrite = true,
                UniqueFilename = false
            };

            CloudinaryDotNet.Actions.ImageUploadResult result = cloudinary.Upload(uploadParams);
            if (result == null || result.StatusCode != HttpStatusCode.OK || result.SecureUrl == null)
            {
                string msg = result != null ? result.Error?.Message : null;
                throw new Exception("Upload ảnh thất bại." + (string.IsNullOrWhiteSpace(msg) ? "" : "\n" + msg));
            }

            return result.SecureUrl.ToString();
        }

        // Phương thức lưu ảnh
        private string SaveImage(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
            {
                return null;
            }

            if (cloudinary != null)
            {
                // Nếu đang chọn một nhân viên cụ thể, dùng employeeId đó để đặt PublicId. Nếu đang tạo mới, dùng Guid mới tạm thời.
                Guid idForImage = Guid.TryParse(choosenEmployeeId, out Guid parsed) ? parsed : Guid.NewGuid();
                return UploadEmployeeImageToCloudinary(sourceFilePath, idForImage);
            }

            string userImagesFolder = Path.Combine(Application.StartupPath, "UserImages");

            if (!Directory.Exists(userImagesFolder))
            {
                Directory.CreateDirectory(userImagesFolder);
            }

            string extension = Path.GetExtension(sourceFilePath);
            string fileName = Guid.NewGuid().ToString("N") + extension;
            string destinationPath = Path.Combine(userImagesFolder, fileName);

            File.Copy(sourceFilePath, destinationPath, true);

            return destinationPath;
        }

        private void SetPictureEmployeeImage(string imagePath)
        {
            pictureEmployee.Image = Properties.Resources.defaultUser;

            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return;
            }

            if (IsHttpUrl(imagePath))
            {
                try
                {
                    pictureEmployee.Load(imagePath);
                }
                catch
                {
                    pictureEmployee.Image = Properties.Resources.defaultUser;
                }

                return;
            }

            if (!File.Exists(imagePath))
            {
                return;
            }

            using (Image image = Image.FromFile(imagePath))
            {
                pictureEmployee.Image = new Bitmap(image);
            }
        }

        private bool CanUpdateEmployee(Guid employeeId)
        {
            if (User.Roles.Contains("Admin"))
            {
                return true;
            }

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) " +
                    "FROM dbo.EmployeeRole er " +
                    "JOIN dbo.Role r ON er.role_id = r.role_id " +
                    "WHERE er.employee_id = @employeeId " +
                    "AND r.role_name IN ('Admin', 'Manager')", conn))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    conn.Open();

                    int protectedRoleCount = (int)cmd.ExecuteScalar();
                    return protectedRoleCount == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kiểm tra được quyền cập nhật.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Search Tab

        //Nút tìm kiếm nhân viên theo bộ lọc
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Xây dựng câu truy vấn động dựa trên các điều kiện lọc
            string query = "SELECT * FROM dbo.Employee";
            List<string> conditions = new List<string>();
            SqlCommand cmd = new SqlCommand();

            // Thêm điều kiện lọc theo tên nhân viên
            if (!string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                conditions.Add("employee_name LIKE @employeeName");
                cmd.Parameters.AddWithValue("@employeeName", "%" + txtEmployeeName.Text.Trim() + "%");
            }

            // Thêm điều kiện lọc theo Số điện thoại
            if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                conditions.Add("phone_number LIKE @phoneNumber");
                cmd.Parameters.AddWithValue("@phoneNumber", "%" + txtPhoneNumber.Text.Trim() + "%");
            }

            // Thêm điều kiện lọc theo vai trò
            if (cbxRole.SelectedItem != null)
            {
                conditions.Add(
                    "(SELECT TOP 1 r.role_name " +
                    " FROM dbo.EmployeeRole er " +
                    " JOIN dbo.Role r ON er.role_id = r.role_id " +
                    " WHERE er.employee_id = Employee.employee_id) = @roleName");

                cmd.Parameters.AddWithValue("@roleName", cbxRole.SelectedItem.ToString());
            }

            // Thêm điều kiện lọc theo trạng thái nhân viên
            if (cbIsAvailable.Checked)
            {
                conditions.Add("status = 1");
            }
            else if (cbUnAvailable.Checked)
            {
                conditions.Add("status = 0");
            }

            // Thêm điều kiện lọc theo trạng thái tài khoản
            if (cbIsActive.Checked)
            {
                conditions.Add("is_active = 1");
            }
            else if (cbUnActive.Checked)
            {
                conditions.Add("is_active = 0");
            }

            // Kết hợp các điều kiện lọc vào câu truy vấn
            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            // Thực thi câu truy vấn và tải dữ liệu vào ListView
            cmd.CommandText = query;
            loadData(cmd);
        }

        private void cbIsAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsAvailable.Checked)
            {
                cbUnAvailable.Checked = false;
            }
        }

        private void cbUnAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnAvailable.Checked)
            {
                cbIsAvailable.Checked = false;
            }
        }

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsActive.Checked)
            {
                cbUnActive.Checked = false;
            }
        }

        private void cbUnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnActive.Checked)
            {
                cbIsActive.Checked = false;
            }
        }

        // Nút làm mới bộ lọc
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtEmployeeName.Clear();
            txtPhoneNumber.Clear();
            cbxRole.SelectedIndex = -1;

            cbIsAvailable.Checked = false;
            cbUnAvailable.Checked = false;
            cbIsActive.Checked = false;
            cbUnActive.Checked = false;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Employee");
            loadData(cmd);
        }

        #endregion

        #region Information Tab

        // Tab Thông tin
        private void lvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvEmployee.SelectedRows[0];
            if (selectedRow.Tag == null) return;
            Guid employeeId = (Guid)selectedRow.Tag;
            choosenEmployeeId = employeeId.ToString();
            txtNameInfo.Text = Convert.ToString(selectedRow.Cells[0].Value);
            txtEmailInfo.Text = Convert.ToString(selectedRow.Cells[1].Value);
            txtPhoneNumberInfo.Text = Convert.ToString(selectedRow.Cells[2].Value);
            txtSalaryInfo.Text = Convert.ToString(selectedRow.Cells[6].Value);
            txtPassword.Clear();

            if (DateTime.TryParseExact(Convert.ToString(selectedRow.Cells[4].Value), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateOfBirth))
            {
                txtDOB.Value = dateOfBirth;
            }
            lblHireDate.Text = "Ngày vào làm: " + Convert.ToString(selectedRow.Cells[5].Value);

            string roleText = Convert.ToString(selectedRow.Cells[3].Value);
            if (cbxRoleInfo.Items.Contains(roleText))
            {
                cbxRoleInfo.SelectedItem = roleText;
            }
            else
            {
                cbxRoleInfo.SelectedIndex = -1;
            }

            cbInfoIsAvailable.Checked = Convert.ToString(selectedRow.Cells[7].Value) == "Khả dụng";
            cbInfoUnAvailable.Checked = Convert.ToString(selectedRow.Cells[7].Value) == "Không khả dụng";
            cbInfoIsActive.Checked = Convert.ToString(selectedRow.Cells[8].Value) == "Đang hoạt động";
            cbInfoUnActive.Checked = Convert.ToString(selectedRow.Cells[8].Value) == "Ngừng hoạt động";

            pictureEmployee.Image = null;

            try
            {
                connection = GymManagementSystemContext.Connect();
                SqlCommand cmd = new SqlCommand(
                    "SELECT image_url, login_key, password FROM dbo.Employee WHERE employee_id = @ID",
                    connection);

                cmd.Parameters.AddWithValue("@ID", employeeId);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string imageUrl = reader["image_url"] == DBNull.Value ? null : reader["image_url"].ToString();
                        selectedImagePath = imageUrl;

                        if(User.Roles.Contains("Admin"))
                            txtLoginKey.Text = reader["login_key"].ToString();


                        SetPictureEmployeeImage(imageUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được ảnh nhân viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            TabsCtr.SelectedTab = tabInformation;
        }

        private void cbInfoIsAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInfoIsAvailable.Checked) 
            {
                cbInfoUnAvailable.Checked = false;
            }
        }

        private void cbInfoUnAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInfoUnAvailable.Checked)
            {
                cbInfoIsAvailable.Checked = false;
            }
        }

        private void cbInfoIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if(cbInfoIsActive.Checked)
            {
                cbInfoUnActive.Checked = false;
            }
        }

        private void cbInfoUnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInfoUnActive.Checked)
            {
                cbInfoIsActive.Checked = false;
            }
        }

        // Phương thức làm mới tab thông tin
        private void ClearInfoTab()
        {
            choosenEmployeeId = null;
            choosenEmployee = null;
            selectedImagePath = null;

            txtNameInfo.Clear();
            txtEmailInfo.Clear();
            txtPhoneNumberInfo.Clear();
            txtSalaryInfo.Clear();
            txtDOB.Value = DateTime.Today.AddYears(-18);
            txtLoginKey.Clear();
            txtPassword.Clear();

            lblHireDate.Text = "Ngày vào làm: ";

            cbxRoleInfo.SelectedIndex = -1;

            cbInfoIsAvailable.Checked = false;
            cbInfoUnAvailable.Checked = false;
            cbInfoIsActive.Checked = false;
            cbInfoUnActive.Checked = false;

            pictureEmployee.Image = Properties.Resources.defaultUser;
            dgvEmployee.ClearSelection();
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu nhập vào tab thông tin
        private bool ValidateInfoInput()
        {
            if (txtLoginKey.Visible && string.IsNullOrWhiteSpace(txtLoginKey.Text))
            {
                MessageBox.Show("Login key không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginKey.Focus();
                return false;
            }

            if (txtPassword.Visible && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNameInfo.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameInfo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmailInfo.Text))
            {
                MessageBox.Show("Email không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailInfo.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtEmailInfo.Text.Trim(), @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Email không đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailInfo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumberInfo.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumberInfo.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtPhoneNumberInfo.Text.Trim(), @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 hoặc 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumberInfo.Focus();
                return false;
            }

            DateTime dateOfBirth = txtDOB.Value.Date;

            if (dateOfBirth.Date >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDOB.Focus();
                return false;
            }

            int salary;
            if (!int.TryParse(txtSalaryInfo.Text.Replace(",", ""), out salary) || salary < 0)
            {
                MessageBox.Show("Lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalaryInfo.Focus();
                return false;
            }

            if (!cbInfoIsAvailable.Checked && !cbInfoUnAvailable.Checked)
            {
                MessageBox.Show("Hãy chọn trạng thái nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!cbInfoIsActive.Checked && !cbInfoUnActive.Checked)
            {
                MessageBox.Show("Hãy chọn trạng thái tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbxRoleInfo.Visible && cbxRoleInfo.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxRoleInfo.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateInfoInputForUpdate()
        {
            if (txtLoginKey.Visible && string.IsNullOrWhiteSpace(txtLoginKey.Text))
            {
                MessageBox.Show("Login key không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginKey.Focus();
                return false;
            }

      

            if (string.IsNullOrWhiteSpace(txtNameInfo.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameInfo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmailInfo.Text))
            {
                MessageBox.Show("Email không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailInfo.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtEmailInfo.Text.Trim(), @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Email không đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailInfo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumberInfo.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumberInfo.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtPhoneNumberInfo.Text.Trim(), @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 hoặc 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumberInfo.Focus();
                return false;
            }

            DateTime dateOfBirth = txtDOB.Value.Date;

            if (dateOfBirth.Date >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDOB.Focus();
                return false;
            }

            int salary;
            if (!int.TryParse(txtSalaryInfo.Text.Replace(",", ""), out salary) || salary < 0)
            {
                MessageBox.Show("Lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalaryInfo.Focus();
                return false;
            }

            if (!cbInfoIsAvailable.Checked && !cbInfoUnAvailable.Checked)
            {
                MessageBox.Show("Hãy chọn trạng thái nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!cbInfoIsActive.Checked && !cbInfoUnActive.Checked)
            {
                MessageBox.Show("Hãy chọn trạng thái tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbxRoleInfo.Visible && cbxRoleInfo.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxRoleInfo.Focus();
                return false;
            }

            return true;
        }
        // Nút thêm nhân viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if(choosenEmployeeId != null)
            {
                MessageBox.Show("Bạn không thể thêm nhân viên mới khi đang xem thông tin nhân viên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            choosenEmployeeId = null;
            dgvEmployee.ClearSelection();

            if (!ValidateInfoInput())
            {
                return;
            }

            int roleId;
            if (!TryGetSelectedRoleId(out roleId))
            {
                MessageBox.Show("Không xác định được chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid employeeId = Guid.NewGuid();
            bool status = cbInfoIsAvailable.Checked;
            bool isActive = cbInfoIsActive.Checked;
            int salary = int.Parse(txtSalaryInfo.Text.Replace(",", ""));

            string loginKey = txtLoginKey.Text.Trim();

            //Hashing trc khi thêm vào database
            string password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text.Trim());
            DateTime dateOfBirth = txtDOB.Value.Date;
            DateTime hireDate = DateTime.Today;

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO dbo.Employee " +
                                "(employee_id, login_key, password, email, image_url, employee_name, phone_number, date_of_birth, salary, hire_date, status, is_active) " +
                                "VALUES " +
                                "(@employeeId, @loginKey, @password, @email, @imageUrl, @employeeName, @phoneNumber, @dateOfBirth, @salary, @hireDate, @status, @isActive)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                                cmd.Parameters.AddWithValue("@loginKey", loginKey);
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@email", txtEmailInfo.Text.Trim());
                                cmd.Parameters.AddWithValue("@imageUrl", string.IsNullOrWhiteSpace(selectedImagePath) ? (object)DBNull.Value : selectedImagePath);
                                cmd.Parameters.AddWithValue("@employeeName", txtNameInfo.Text.Trim());
                                cmd.Parameters.AddWithValue("@phoneNumber", txtPhoneNumberInfo.Text.Trim());
                                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                                cmd.Parameters.AddWithValue("@salary", salary);
                                cmd.Parameters.AddWithValue("@hireDate", hireDate);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@isActive", isActive);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdRole = new SqlCommand(
                                "INSERT INTO dbo.EmployeeRole (employee_id, role_id) VALUES (@employeeId, @roleId)", conn, tran))
                            {
                                cmdRole.Parameters.AddWithValue("@employeeId", employeeId);
                                cmdRole.Parameters.AddWithValue("@roleId", roleId);
                                cmdRole.ExecuteNonQuery();
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(new SqlCommand("SELECT * FROM dbo.Employee"));
                ClearInfoTab();
                TabsCtr.SelectedTab = tabSearch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm nhân viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút xóa nhân viên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn ít nhất một nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Guid> employeeIds = new List<Guid>();
            List<string> employeeNames = new List<string>();

            foreach (DataGridViewRow selectedRow in dgvEmployee.SelectedRows)
            {
                Guid employeeId = (Guid)selectedRow.Tag;

                if (employeeId == User.EmployeeId)
                {
                    MessageBox.Show("Bạn không thể xóa chính mình.", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!CanUpdateEmployee(employeeId))
                {
                    MessageBox.Show("Bạn không có quyền xóa một hoặc nhiều tài khoản Admin hoặc Manager.", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                employeeIds.Add(employeeId);
                employeeNames.Add(Convert.ToString(selectedRow.Cells[0].Value));
            }

            string confirmMessage = employeeIds.Count == 1
                ? "Xác nhận xóa nhân viên này?"
                : "Xác nhận xóa " + employeeIds.Count + " nhân viên đã chọn?";

            if (MessageBox.Show(confirmMessage, "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            List<string> imagePaths = new List<string>();

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (Guid employeeId in employeeIds)
                            {
                                using (SqlCommand cmdGetImage = new SqlCommand(
                                    "SELECT image_url FROM dbo.Employee WHERE employee_id = @employeeId", conn, tran))
                                {
                                    cmdGetImage.Parameters.AddWithValue("@employeeId", employeeId);
                                    object result = cmdGetImage.ExecuteScalar();
                                    string imagePath = result == null || result == DBNull.Value ? null : result.ToString();

                                    if (!string.IsNullOrWhiteSpace(imagePath))
                                    {
                                        imagePaths.Add(imagePath);
                                    }
                                }

                                using (SqlCommand cmdRole = new SqlCommand(
                                    "DELETE FROM dbo.EmployeeRole WHERE employee_id = @employeeId", conn, tran))
                                {
                                    cmdRole.Parameters.AddWithValue("@employeeId", employeeId);
                                    cmdRole.ExecuteNonQuery();
                                }

                                using (SqlCommand cmdEmp = new SqlCommand(
                                    "DELETE FROM dbo.Employee WHERE employee_id = @employeeId", conn, tran))
                                {
                                    cmdEmp.Parameters.AddWithValue("@employeeId", employeeId);
                                    cmdEmp.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                string userImagesFolder = Path.Combine(Application.StartupPath, "UserImages");
                string fullUserImagesFolder = Path.GetFullPath(userImagesFolder);

                foreach (string imagePath in imagePaths)
                {
                    if (string.IsNullOrWhiteSpace(imagePath) || IsHttpUrl(imagePath))
                    {
                        continue;
                    }

                    string fullImagePath = Path.GetFullPath(imagePath);

                    if (fullImagePath.StartsWith(fullUserImagesFolder, StringComparison.OrdinalIgnoreCase) && File.Exists(fullImagePath))
                    {
                        File.Delete(fullImagePath);
                    }
                }

                MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(new SqlCommand("SELECT * FROM dbo.Employee"));
                ClearInfoTab();
                TabsCtr.SelectedTab = tabSearch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa nhân viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            choosenEmployeeId = null;
        }

        // Nút cập nhật thông tin nhân viên
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(choosenEmployeeId))
            {
                MessageBox.Show("Hãy chọn nhân viên cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInfoInputForUpdate())
            {
                return;
            }

            int roleId;
            if (!TryGetSelectedRoleId(out roleId))
            {
                MessageBox.Show("Không xác định được chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid employeeId = Guid.Parse(choosenEmployeeId);

            if (!CanUpdateEmployee(employeeId))
            {
                MessageBox.Show("Bạn không có quyền cập nhật tài khoản Admin hoặc Manager.", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool status = cbInfoIsAvailable.Checked;
            bool isActive = cbInfoIsActive.Checked;
            int salary = int.Parse(txtSalaryInfo.Text.Replace(",", ""));

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                

                            using (SqlCommand cmd = new SqlCommand(
                                "UPDATE dbo.Employee SET " +
                                "login_key = @loginKey, " +
                                "password = @password, " +
                                "employee_name = @employeeName, " +
                                "email = @email, " +
                                "phone_number = @phoneNumber, " +
                                "date_of_birth = @dateOfBirth, " +
                                "salary = @salary, " +
                                "image_url = @imageUrl, " +
                                "status = @status, " +
                                "is_active = @isActive " +
                                "WHERE employee_id = @employeeId", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                                cmd.Parameters.AddWithValue("@loginKey", txtLoginKey.Text.Trim());


                                //Hash password trc khi thêm vào databased
                                if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
                                {
                                    using (SqlCommand cmdGetPassword = new SqlCommand(
                                        "SELECT password FROM dbo.Employee WHERE employee_id = @employeeId", conn, tran))
                                    {
                                        cmdGetPassword.Parameters.AddWithValue("@employeeId", employeeId);
                                        object result = cmdGetPassword.ExecuteScalar();
                                        string existingHashedPassword = result == null || result == DBNull.Value ? null : result.ToString();
                                        cmd.Parameters.AddWithValue("@password", existingHashedPassword);
                                    }
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text.Trim()));
                                }
                    
                                cmd.Parameters.AddWithValue("@employeeName", txtNameInfo.Text.Trim());
                                cmd.Parameters.AddWithValue("@email", txtEmailInfo.Text.Trim());
                                cmd.Parameters.AddWithValue("@phoneNumber", txtPhoneNumberInfo.Text.Trim());
                                cmd.Parameters.AddWithValue("@dateOfBirth", txtDOB.Value.Date);
                                cmd.Parameters.AddWithValue("@salary", salary);
                                cmd.Parameters.AddWithValue("@imageUrl", string.IsNullOrWhiteSpace(selectedImagePath) ? (object)DBNull.Value : selectedImagePath);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@isActive", isActive);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdDeleteRole = new SqlCommand(
                                "DELETE FROM dbo.EmployeeRole WHERE employee_id = @employeeId", conn, tran))
                            {
                                cmdDeleteRole.Parameters.AddWithValue("@employeeId", employeeId);
                                cmdDeleteRole.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdInsertRole = new SqlCommand(
                                "INSERT INTO dbo.EmployeeRole (employee_id, role_id) VALUES (@employeeId, @roleId)", conn, tran))
                            {
                                cmdInsertRole.Parameters.AddWithValue("@employeeId", employeeId);
                                cmdInsertRole.Parameters.AddWithValue("@roleId", roleId);
                                cmdInsertRole.ExecuteNonQuery();
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(new SqlCommand("SELECT * FROM dbo.Employee"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật nhân viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            choosenEmployeeId = null;
        }

        // Nút làm mới thông tin nhân viên
        private void btnClearInfo_Click(object sender, EventArgs e)
        {
            ClearInfoTab();
        }

        private void pictureEmployee_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh nhân viên";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    selectedImagePath = SaveImage(openFileDialog.FileName);
                    SetPictureEmployeeImage(selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được ảnh.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Không reset choosenEmployeeId ở đây, để người dùng vẫn có thể bấm "Cập nhật"
            // và lưu selectedImagePath (URL Cloudinary) xuống DB.
        }

        #endregion

        
    }
}
