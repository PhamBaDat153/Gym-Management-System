using Client.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms.Login
{
    public partial class frmForgotPassword : Form
    {
        private SqlConnection connection;
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtLoginKey.Text))
            {
                MessageBox.Show("Vui lòng nhập mã đăng nhập của bạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email của bạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới của bạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới của bạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (connection = GymManagementSystemContext.Connect())
                {
                    connection.Open();
                    string sql = "SELECT email FROM Employee WHERE login_key = @loginKey";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@loginKey", txtLoginKey.Text);
                        object result = command.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Mã đăng nhập không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string emailInDb = result.ToString();
                        if (!emailInDb.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Email không khớp với mã đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    using (SqlCommand updateCommand = new SqlCommand("UPDATE Employee SET password = @newPassword WHERE login_key = @loginKey", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@newPassword", BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text.Trim()));
                        updateCommand.Parameters.AddWithValue("@loginKey", txtLoginKey.Text);
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Mật khẩu đã được cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật mật khẩu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
