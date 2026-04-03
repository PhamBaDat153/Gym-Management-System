using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms.Dashboard
{
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(User.ImageUrl) && File.Exists(User.ImageUrl))
            {
                picUser.Image = Image.FromFile(User.ImageUrl);
            }

            lblName.Text = User.EmployeeName;
            lblPhone.Text = User.PhoneNumber;
            lblEmail.Text = User.Email;
            lblDOB.Text = User.DateOfBirth.ToShortDateString();
            lblHireDate.Text = User.HireDate.ToShortDateString();
            lblSalary.Text = User.Salary.ToString("C");
            lblRole.Text = User.Roles.First().ToString();
        }
    }
}
