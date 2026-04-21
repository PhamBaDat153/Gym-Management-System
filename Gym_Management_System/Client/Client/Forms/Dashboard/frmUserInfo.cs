using Client.DataContext;
using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudinaryDotNet;

namespace Client.Forms.Dashboard
{
    public partial class frmUserInfo : Form
    {
        private string selectedImagePath;
        private readonly Cloudinary cloudinary;

        private static bool IsHttpUrl(string value)
        {
            return Uri.TryCreate(value, UriKind.Absolute, out Uri uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        public frmUserInfo()
        {
            InitializeComponent();
            cloudinary = TryCreateCloudinary();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(User.ImageUrl) && IsHttpUrl(User.ImageUrl))
            {
                try
                {
                    picUser.Load(User.ImageUrl);
                }
                catch
                {
                    picUser.Image = Properties.Resources.defaultUser;
                }
            }
            else if (!string.IsNullOrWhiteSpace(User.ImageUrl) && File.Exists(User.ImageUrl))
            {
                using (Image img = Image.FromFile(User.ImageUrl))
                {
                    picUser.Image = new Bitmap(img);
                }
            }

            lblName.Text = User.EmployeeName;
            txtPhone.Text = User.PhoneNumber;
            txtEmail.Text = User.Email;
            lblDOB.Text = User.DateOfBirth.ToShortDateString();
            lblHireDate.Text = User.HireDate.ToShortDateString();
            lblSalary.Text = User.Salary.ToString() + " VND";
            lblRole.Text = User.Roles.First().ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    using (Image img = Image.FromFile(selectedImagePath))
                    {
                        picUser.Image = new Bitmap(img);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newPhone = txtPhone.Text.Trim();
            string newEmail = txtEmail.Text.Trim();

            bool phoneChanged = newPhone != (User.PhoneNumber ?? "");
            bool emailChanged = newEmail != (User.Email ?? "");
            bool imageChanged = !string.IsNullOrWhiteSpace(selectedImagePath);

            if (!phoneChanged && !emailChanged && !imageChanged)
            {
                return;
            }

            if (phoneChanged && !System.Text.RegularExpressions.Regex.IsMatch(newPhone, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 10 đến 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (emailChanged && !System.Text.RegularExpressions.Regex.IsMatch(newEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newImageUrl = User.ImageUrl;
            if (imageChanged)
            {
                try
                {
                    newImageUrl = SaveImage(selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE dbo.Employee SET phone_number = @phone, email = @email, image_url = @imageUrl WHERE employee_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", newPhone);
                        cmd.Parameters.AddWithValue("@email", newEmail);
                        cmd.Parameters.AddWithValue("@imageUrl", string.IsNullOrWhiteSpace(newImageUrl) ? (object)DBNull.Value : newImageUrl);
                        cmd.Parameters.AddWithValue("@id", User.EmployeeId);
                        cmd.ExecuteNonQuery();
                    }
                }

                User.PhoneNumber = newPhone;
                User.Email = newEmail;
                User.ImageUrl = newImageUrl;
                selectedImagePath = null;

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string SaveImage(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
            {
                return null;
            }

            if (cloudinary != null)
            {
                string folder = ConfigurationManager.AppSettings["CloudinaryEmployeesFolder"];
                folder = string.IsNullOrWhiteSpace(folder) ? "gym/employees" : folder.Trim().Trim('/');

                var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams
                {
                    File = new CloudinaryDotNet.FileDescription(sourceFilePath),
                    Folder = folder,
                    PublicId = "employee_" + User.EmployeeId.ToString("N"),
                    Overwrite = true,
                    UniqueFilename = false
                };

                CloudinaryDotNet.Actions.ImageUploadResult result = cloudinary.Upload(uploadParams);
                if (result == null || result.StatusCode != HttpStatusCode.OK || result.SecureUrl == null)
                {
                    string msg = result?.Error?.Message;
                    throw new Exception("Upload ảnh thất bại." + (string.IsNullOrWhiteSpace(msg) ? "" : "\n" + msg));
                }

                return result.SecureUrl.ToString();
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
    }
}
