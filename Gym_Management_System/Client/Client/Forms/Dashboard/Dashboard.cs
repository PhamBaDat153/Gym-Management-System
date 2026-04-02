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
using Client.Forms.EmployeeManage;
using Client.Forms.MemberManage;
using Client.Forms.PackageManage;
using Client.Forms.ReportManage;
using Client.Forms.ScheduleBrowse;
using Client.Forms.ScheduleManage;
using Client.Models;

namespace Client.Forms.Dashboard
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmEmployee());
            lblWelcome.Text = $"Chào mừng trở lại - {User.EmployeeName}!";
            pictureUser.SizeMode = PictureBoxSizeMode.Zoom;

            string imageUrl = User.ImageUrl;
            if (!string.IsNullOrWhiteSpace(imageUrl) && File.Exists(imageUrl))
            {
                pictureUser.Image = Image.FromFile(imageUrl);
            }

            SetNavigationVisibility();
        }

        private void SetNavigationVisibility()
        {
            btnBrowseNavigate.Visible = false;
            btnMemberNavigate.Visible = false;
            btnPackageNavigate.Visible = false;
            btnEmployeeNavigate.Visible = false;
            btnReportNavigate.Visible = false;
            btnScheduleNavigate.Visible = false;

            if (User.Roles.Contains("Admin"))
            {
                btnBrowseNavigate.Visible = true;
                btnMemberNavigate.Visible = true;
                btnPackageNavigate.Visible = true;
                btnEmployeeNavigate.Visible = true;
                btnReportNavigate.Visible = true;
                btnScheduleNavigate.Visible = true;
                return;
            }

            if (User.Roles.Contains("Manager"))
            {
                btnPackageNavigate.Visible = true;
                btnEmployeeNavigate.Visible = true;
                btnReportNavigate.Visible = true;
                btnScheduleNavigate.Visible = true;
                btnMemberNavigate.Visible = true;
            }

            if (User.Roles.Contains("Receptionist"))
            {
                btnMemberNavigate.Visible = true;
                btnPackageNavigate.Visible = true;
            }

            if (User.Roles.Contains("Trainer"))
            {
                btnBrowseNavigate.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            panelManage.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelManage.Controls.Add(childForm);
            panelManage.Tag = childForm;
            childForm.Show();
        }

        // Nút chuyển form sang form quản lý nhân sự
        private void btnEmployeeNavigate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmEmployee());
        }

        // Nút chuyển form sang form quản lý báo cáo
        private void btnReportNavigate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReport());
        }

        // Nút chuyển form sang form quản lý gói tập
        private void btnPackageNavigate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPackage());
        }

        // Nút chuyển form sang form quản lý thành viên
        private void btnMemberNavigate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMember());
        }

        // Nút chuyển form sang form quản lý lịch tập
        private void btnScheduleNavigate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSchedule());
        }

        // Nút chuyển form sang form xem lích tập
        private void btnBrowseNavigate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBrowse());
        }

        // Nút đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút xem thông tin cá nhân
        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            // Todo thêm sau
        }
    }
}
