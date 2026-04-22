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
using Client.Services;

namespace Client.Forms.Dashboard
{
    public partial class Dashboard : Form
    {
        private void RefreshUserHeader()
        {
            if (lb_tenDangNhapvaChucVu == null) return;

            string displayName = string.IsNullOrWhiteSpace(User.EmployeeName)
                ? (string.IsNullOrWhiteSpace(User.LoginKey) ? "-" : User.LoginKey.Trim())
                : User.EmployeeName.Trim();
            string role = (User.Roles == null || User.Roles.Count == 0) ? "-" : string.Join(", ", User.Roles.Distinct());
            lb_tenDangNhapvaChucVu.Text = "Người dùng: " + displayName + " | Chức vụ: " + role;
        }

        private static bool IsHttpUrl(string value)
        {
            return Uri.TryCreate(value, UriKind.Absolute, out Uri uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        public Dashboard()
        {
            InitializeComponent();
            User.Changed += (_, __) =>
            {
                if (!IsHandleCreated) return;
                try
                {
                    BeginInvoke((Action)(() =>
                    {
                        RefreshUserHeader();
                        RefreshUserImage();
                    }));
                }
                catch
                {
                    // best-effort
                }
            };
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Qua ngày sẽ tự trừ ngày còn lại cho hội viên (chạy 1 lần/ngày).
            MemberDurationService.UpdateRemainingDurationsOncePerDay();

            OpenChildForm(new frmDefault());
            pictureUser.SizeMode = PictureBoxSizeMode.Zoom;

            RefreshUserHeader();

            string imageUrl = User.ImageUrl;
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                SetNavigationVisibility();
                return;
            }

            if (IsHttpUrl(imageUrl))
            {
                try
                {
                    pictureUser.Load(imageUrl);
                }
                catch
                {
                    pictureUser.Image = Properties.Resources.defaultUser;
                }
            }
            else if (File.Exists(imageUrl))
            {
                using (Image img = Image.FromFile(imageUrl))
                {
                    pictureUser.Image = new Bitmap(img);
                }
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
            pictureBox2.Visible= false;
            pictureBox3.Visible=false;
            pictureBox4.Visible=false;
            pictureBox5.Visible=false;
            pictureBox6.Visible=false;
            pictureBox7.Visible=false;

            if (User.Roles.Contains("Admin"))
            {
                btnBrowseNavigate.Visible = true;
                btnMemberNavigate.Visible = true;
                btnPackageNavigate.Visible = true;
                btnEmployeeNavigate.Visible = true;
                btnReportNavigate.Visible = true;
                btnScheduleNavigate.Visible = true;
                pictureBox2.Visible=true;
                pictureBox3.Visible=true;
                pictureBox4.Visible=true;
                pictureBox5.Visible = true;
                pictureBox6.Visible=true;
                pictureBox7.Visible=true;
                return;
            }

            if (User.Roles.Contains("Manager"))
            {
                btnPackageNavigate.Visible = true;
                btnEmployeeNavigate.Visible = true;
                btnReportNavigate.Visible = true;
                btnScheduleNavigate.Visible = true;
                btnMemberNavigate.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
            }

            if (User.Roles.Contains("Receptionist"))
            {
                btnMemberNavigate.Visible = true;
                btnPackageNavigate.Visible = true;
                pictureBox5.Visible = true;
                pictureBox4.Visible = true;

            }

            if (User.Roles.Contains("Trainer"))
            {
                btnBrowseNavigate.Visible = true;
                pictureBox7.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Dispose form con cũ (nếu có) để tránh rò rỉ bộ nhớ,
            // thay vì dùng `using` tại nơi gọi (sẽ Dispose quá sớm).
            // Lưu ý: không dispose từng control rồi lại Controls.Clear() (dễ bị dispose hai lần).
            Control old = panelManage.Controls.Count > 0 ? panelManage.Controls[0] : null;
            panelManage.Controls.Clear();
            if (old != null)
            {
                try
                {
                    if (old is Form oldForm)
                    {
                        try { oldForm.Close(); } catch { }
                        oldForm.Dispose();
                    }
                    else
                    {
                        old.Dispose();
                    }
                }
                catch
                {
                    // Best-effort cleanup
                }
            }

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
            using (frmUserInfo form = new frmUserInfo())
            {
                form.ShowDialog(this);
            }
            RefreshUserHeader();
            RefreshUserImage();
        }

        private void RefreshUserImage()
        {
            string imageUrl = User.ImageUrl;
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                pictureUser.Image = Properties.Resources.defaultUser;
                return;
            }

            if (IsHttpUrl(imageUrl))
            {
                try
                {
                    pictureUser.Load(imageUrl);
                }
                catch
                {
                    pictureUser.Image = Properties.Resources.defaultUser;
                }
            }
            else if (File.Exists(imageUrl))
            {
                using (Image img = Image.FromFile(imageUrl))
                {
                    pictureUser.Image = new Bitmap(img);
                }
            }
            else
            {
                pictureUser.Image = Properties.Resources.defaultUser;
            }
        }

        // Nút chuyển form sang form trang chủ
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDefault());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
