namespace Client.Forms.Dashboard
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEmployeeNavigate = new System.Windows.Forms.Button();
            this.btnReportNavigate = new System.Windows.Forms.Button();
            this.btnPackageNavigate = new System.Windows.Forms.Button();
            this.btnMemberNavigate = new System.Windows.Forms.Button();
            this.btnScheduleNavigate = new System.Windows.Forms.Button();
            this.btnBrowseNavigate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.pictureUser = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelManage = new System.Windows.Forms.Panel();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTrangChu);
            this.flowLayoutPanel1.Controls.Add(this.btnEmployeeNavigate);
            this.flowLayoutPanel1.Controls.Add(this.btnReportNavigate);
            this.flowLayoutPanel1.Controls.Add(this.btnPackageNavigate);
            this.flowLayoutPanel1.Controls.Add(this.btnMemberNavigate);
            this.flowLayoutPanel1.Controls.Add(this.btnScheduleNavigate);
            this.flowLayoutPanel1.Controls.Add(this.btnBrowseNavigate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(191, 1033);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnEmployeeNavigate
            // 
            this.btnEmployeeNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmployeeNavigate.Location = new System.Drawing.Point(5, 58);
            this.btnEmployeeNavigate.Name = "btnEmployeeNavigate";
            this.btnEmployeeNavigate.Size = new System.Drawing.Size(183, 47);
            this.btnEmployeeNavigate.TabIndex = 0;
            this.btnEmployeeNavigate.Text = "Quản lý nhân sự";
            this.btnEmployeeNavigate.UseVisualStyleBackColor = true;
            this.btnEmployeeNavigate.Click += new System.EventHandler(this.btnEmployeeNavigate_Click);
            // 
            // btnReportNavigate
            // 
            this.btnReportNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportNavigate.Location = new System.Drawing.Point(5, 111);
            this.btnReportNavigate.Name = "btnReportNavigate";
            this.btnReportNavigate.Size = new System.Drawing.Size(183, 47);
            this.btnReportNavigate.TabIndex = 1;
            this.btnReportNavigate.Text = "Quản lý báo cáo";
            this.btnReportNavigate.UseVisualStyleBackColor = true;
            this.btnReportNavigate.Click += new System.EventHandler(this.btnReportNavigate_Click);
            // 
            // btnPackageNavigate
            // 
            this.btnPackageNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackageNavigate.Location = new System.Drawing.Point(5, 164);
            this.btnPackageNavigate.Name = "btnPackageNavigate";
            this.btnPackageNavigate.Size = new System.Drawing.Size(183, 47);
            this.btnPackageNavigate.TabIndex = 2;
            this.btnPackageNavigate.Text = "Quản lý gói tập";
            this.btnPackageNavigate.UseVisualStyleBackColor = true;
            this.btnPackageNavigate.Click += new System.EventHandler(this.btnPackageNavigate_Click);
            // 
            // btnMemberNavigate
            // 
            this.btnMemberNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMemberNavigate.Location = new System.Drawing.Point(5, 217);
            this.btnMemberNavigate.Name = "btnMemberNavigate";
            this.btnMemberNavigate.Size = new System.Drawing.Size(183, 47);
            this.btnMemberNavigate.TabIndex = 3;
            this.btnMemberNavigate.Text = "Quản lý thành viên";
            this.btnMemberNavigate.UseVisualStyleBackColor = true;
            this.btnMemberNavigate.Click += new System.EventHandler(this.btnMemberNavigate_Click);
            // 
            // btnScheduleNavigate
            // 
            this.btnScheduleNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScheduleNavigate.Location = new System.Drawing.Point(5, 270);
            this.btnScheduleNavigate.Name = "btnScheduleNavigate";
            this.btnScheduleNavigate.Size = new System.Drawing.Size(183, 47);
            this.btnScheduleNavigate.TabIndex = 4;
            this.btnScheduleNavigate.Text = "Quản lý lịch tập";
            this.btnScheduleNavigate.UseVisualStyleBackColor = true;
            this.btnScheduleNavigate.Click += new System.EventHandler(this.btnScheduleNavigate_Click);
            // 
            // btnBrowseNavigate
            // 
            this.btnBrowseNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseNavigate.Location = new System.Drawing.Point(5, 323);
            this.btnBrowseNavigate.Name = "btnBrowseNavigate";
            this.btnBrowseNavigate.Size = new System.Drawing.Size(183, 47);
            this.btnBrowseNavigate.TabIndex = 5;
            this.btnBrowseNavigate.Text = "Xem lịch tập";
            this.btnBrowseNavigate.UseVisualStyleBackColor = true;
            this.btnBrowseNavigate.Click += new System.EventHandler(this.btnBrowseNavigate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnShowInfo);
            this.panel1.Controls.Add(this.pictureUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(191, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1711, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(261, 62);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(169, 33);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Location = new System.Drawing.Point(86, 61);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(169, 33);
            this.btnShowInfo.TabIndex = 3;
            this.btnShowInfo.Text = "Thông tin cá nhân";
            this.btnShowInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowInfo.UseVisualStyleBackColor = true;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // pictureUser
            // 
            this.pictureUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureUser.Image = global::Client.Properties.Resources.defaultUser;
            this.pictureUser.Location = new System.Drawing.Point(5, 5);
            this.pictureUser.Name = "pictureUser";
            this.pictureUser.Size = new System.Drawing.Size(69, 90);
            this.pictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUser.TabIndex = 0;
            this.pictureUser.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hệ Thống Quản Lý Phòng Gym";
            // 
            // panelManage
            // 
            this.panelManage.AutoSize = true;
            this.panelManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelManage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelManage.Location = new System.Drawing.Point(191, 100);
            this.panelManage.Name = "panelManage";
            this.panelManage.Padding = new System.Windows.Forms.Padding(3);
            this.panelManage.Size = new System.Drawing.Size(1711, 933);
            this.panelManage.TabIndex = 2;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrangChu.Location = new System.Drawing.Point(5, 5);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(183, 47);
            this.btnTrangChu.TabIndex = 6;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.panelManage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(3840, 2160);
            this.MinimumSize = new System.Drawing.Size(1918, 1018);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Phòng Gym - Trang Chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelManage;
        private System.Windows.Forms.Button btnEmployeeNavigate;
        private System.Windows.Forms.Button btnReportNavigate;
        private System.Windows.Forms.Button btnPackageNavigate;
        private System.Windows.Forms.Button btnMemberNavigate;
        private System.Windows.Forms.Button btnScheduleNavigate;
        private System.Windows.Forms.Button btnBrowseNavigate;
        private System.Windows.Forms.PictureBox pictureUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnShowInfo;
        private System.Windows.Forms.Button btnTrangChu;
    }
}