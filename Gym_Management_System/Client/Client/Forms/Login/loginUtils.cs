using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms.Login
{

    //lớp chứa phương thức hỗ trợ cho form login
    public static class loginUtils
    {
        //phương thức kiểm tra thông tin đăng nhập có hợp lệ hay không
        public static bool checkLoginInfoIsValid(String loginKey, String password)
        {
            if(loginKey.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if(password.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
