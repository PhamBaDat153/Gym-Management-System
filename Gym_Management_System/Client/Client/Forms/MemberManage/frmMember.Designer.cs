namespace Client.Forms.MemberManage
{
    partial class frmMember
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitBottom = new System.Windows.Forms.SplitContainer();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.chkMemberActive = new System.Windows.Forms.CheckBox();
            this.chkHasTrainer = new System.Windows.Forms.CheckBox();
            this.numRemaining = new System.Windows.Forms.NumericUpDown();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.dtpRegister = new System.Windows.Forms.DateTimePicker();
            this.lblRegister = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblDob = new System.Windows.Forms.Label();
            this.grpGender = new System.Windows.Forms.GroupBox();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpPackage = new System.Windows.Forms.GroupBox();
            this.btnRegisterPackage = new System.Windows.Forms.Button();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPackage = new System.Windows.Forms.ComboBox();
            this.lblPkg = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitBottom)).BeginInit();
            this.splitBottom.Panel1.SuspendLayout();
            this.splitBottom.Panel2.SuspendLayout();
            this.splitBottom.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRemaining)).BeginInit();
            this.grpGender.SuspendLayout();
            this.grpPackage.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý hội viên";
            // 
            // splitBottom
            // 
            this.splitBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitBottom.Location = new System.Drawing.Point(15, 353);
            this.splitBottom.Margin = new System.Windows.Forms.Padding(2);
            this.splitBottom.Name = "splitBottom";
            // 
            // splitBottom.Panel1
            // 
            this.splitBottom.Panel1.Controls.Add(this.grpInfo);
            // 
            // splitBottom.Panel2
            // 
            this.splitBottom.Panel2.Controls.Add(this.grpPackage);
            this.splitBottom.Size = new System.Drawing.Size(951, 243);
            this.splitBottom.SplitterDistance = 470;
            this.splitBottom.SplitterWidth = 3;
            this.splitBottom.TabIndex = 10;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnAdd);
            this.grpInfo.Controls.Add(this.btnUpdate);
            this.grpInfo.Controls.Add(this.chkMemberActive);
            this.grpInfo.Controls.Add(this.btnDelete);
            this.grpInfo.Controls.Add(this.chkHasTrainer);
            this.grpInfo.Controls.Add(this.btnClear);
            this.grpInfo.Controls.Add(this.numRemaining);
            this.grpInfo.Controls.Add(this.lblRemaining);
            this.grpInfo.Controls.Add(this.dtpRegister);
            this.grpInfo.Controls.Add(this.lblRegister);
            this.grpInfo.Controls.Add(this.txtEmail);
            this.grpInfo.Controls.Add(this.lblEmail);
            this.grpInfo.Controls.Add(this.txtPhone);
            this.grpInfo.Controls.Add(this.lblPhone);
            this.grpInfo.Controls.Add(this.dtpDOB);
            this.grpInfo.Controls.Add(this.lblDob);
            this.grpInfo.Controls.Add(this.grpGender);
            this.grpInfo.Controls.Add(this.txtMemberName);
            this.grpInfo.Controls.Add(this.lblName);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grpInfo.Size = new System.Drawing.Size(470, 243);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin hội viên";
            // 
            // chkMemberActive
            // 
            this.chkMemberActive.AutoSize = true;
            this.chkMemberActive.Checked = true;
            this.chkMemberActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMemberActive.Location = new System.Drawing.Point(276, 175);
            this.chkMemberActive.Margin = new System.Windows.Forms.Padding(2);
            this.chkMemberActive.Name = "chkMemberActive";
            this.chkMemberActive.Size = new System.Drawing.Size(138, 17);
            this.chkMemberActive.TabIndex = 13;
            this.chkMemberActive.Text = "Hội viên còn hoạt động";
            this.chkMemberActive.UseVisualStyleBackColor = true;
            // 
            // chkHasTrainer
            // 
            this.chkHasTrainer.AutoSize = true;
            this.chkHasTrainer.Location = new System.Drawing.Point(276, 146);
            this.chkHasTrainer.Margin = new System.Windows.Forms.Padding(2);
            this.chkHasTrainer.Name = "chkHasTrainer";
            this.chkHasTrainer.Size = new System.Drawing.Size(86, 17);
            this.chkHasTrainer.TabIndex = 12;
            this.chkHasTrainer.Text = "Có HLV kèm";
            this.chkHasTrainer.UseVisualStyleBackColor = true;
            // 
            // numRemaining
            // 
            this.numRemaining.Location = new System.Drawing.Point(105, 176);
            this.numRemaining.Margin = new System.Windows.Forms.Padding(2);
            this.numRemaining.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRemaining.Name = "numRemaining";
            this.numRemaining.Size = new System.Drawing.Size(121, 20);
            this.numRemaining.TabIndex = 11;
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(12, 177);
            this.lblRemaining.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(89, 13);
            this.lblRemaining.TabIndex = 10;
            this.lblRemaining.Text = "Ngày còn lại (gói)";
            // 
            // dtpRegister
            // 
            this.dtpRegister.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegister.Location = new System.Drawing.Point(105, 146);
            this.dtpRegister.Margin = new System.Windows.Forms.Padding(2);
            this.dtpRegister.Name = "dtpRegister";
            this.dtpRegister.Size = new System.Drawing.Size(120, 20);
            this.dtpRegister.TabIndex = 9;
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Location = new System.Drawing.Point(12, 148);
            this.lblRegister.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(74, 13);
            this.lblRegister.TabIndex = 8;
            this.lblRegister.Text = "Ngày đăng ký";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(85, 118);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(329, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 120);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(85, 89);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(151, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 91);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(70, 13);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(310, 59);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(91, 20);
            this.dtpDOB.TabIndex = 3;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(250, 61);
            this.lblDob.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(54, 13);
            this.lblDob.TabIndex = 2;
            this.lblDob.Text = "Ngày sinh";
            // 
            // grpGender
            // 
            this.grpGender.Controls.Add(this.rdoNu);
            this.grpGender.Controls.Add(this.rdoNam);
            this.grpGender.Location = new System.Drawing.Point(85, 47);
            this.grpGender.Margin = new System.Windows.Forms.Padding(2);
            this.grpGender.Name = "grpGender";
            this.grpGender.Padding = new System.Windows.Forms.Padding(2);
            this.grpGender.Size = new System.Drawing.Size(150, 36);
            this.grpGender.TabIndex = 1;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Giới tính";
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(75, 15);
            this.rdoNu.Margin = new System.Windows.Forms.Padding(2);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(39, 17);
            this.rdoNu.TabIndex = 1;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Checked = true;
            this.rdoNam.Location = new System.Drawing.Point(9, 15);
            this.rdoNam.Margin = new System.Windows.Forms.Padding(2);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(47, 17);
            this.rdoNam.TabIndex = 0;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(85, 24);
            this.txtMemberName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(329, 20);
            this.txtMemberName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 26);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ tên";
            // 
            // grpPackage
            // 
            this.grpPackage.Controls.Add(this.btnRegisterPackage);
            this.grpPackage.Controls.Add(this.cmbPayment);
            this.grpPackage.Controls.Add(this.lblPayment);
            this.grpPackage.Controls.Add(this.cmbPackage);
            this.grpPackage.Controls.Add(this.lblPkg);
            this.grpPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPackage.Location = new System.Drawing.Point(0, 0);
            this.grpPackage.Margin = new System.Windows.Forms.Padding(2);
            this.grpPackage.Name = "grpPackage";
            this.grpPackage.Padding = new System.Windows.Forms.Padding(2);
            this.grpPackage.Size = new System.Drawing.Size(478, 243);
            this.grpPackage.TabIndex = 3;
            this.grpPackage.TabStop = false;
            this.grpPackage.Text = "Đăng ký gói tập cho hội viên đã chọn";
            // 
            // btnRegisterPackage
            // 
            this.btnRegisterPackage.Location = new System.Drawing.Point(310, 135);
            this.btnRegisterPackage.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegisterPackage.Name = "btnRegisterPackage";
            this.btnRegisterPackage.Size = new System.Drawing.Size(150, 26);
            this.btnRegisterPackage.TabIndex = 4;
            this.btnRegisterPackage.Text = "Đăng ký / gia hạn gói";
            this.btnRegisterPackage.UseVisualStyleBackColor = true;
            this.btnRegisterPackage.Click += new System.EventHandler(this.btnRegisterPackage_Click);
            // 
            // cmbPayment
            // 
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Location = new System.Drawing.Point(114, 84);
            this.cmbPayment.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(346, 21);
            this.cmbPayment.TabIndex = 3;
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(4, 91);
            this.lblPayment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(107, 13);
            this.lblPayment.TabIndex = 2;
            this.lblPayment.Text = "Hình thức thanh toán";
            // 
            // cmbPackage
            // 
            this.cmbPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPackage.FormattingEnabled = true;
            this.cmbPackage.Location = new System.Drawing.Point(114, 28);
            this.cmbPackage.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPackage.Name = "cmbPackage";
            this.cmbPackage.Size = new System.Drawing.Size(346, 21);
            this.cmbPackage.TabIndex = 1;
            // 
            // lblPkg
            // 
            this.lblPkg.AutoSize = true;
            this.lblPkg.Location = new System.Drawing.Point(60, 31);
            this.lblPkg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPkg.Name = "lblPkg";
            this.lblPkg.Size = new System.Drawing.Size(41, 13);
            this.lblPkg.TabIndex = 0;
            this.lblPkg.Text = "Gói tập";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(347, 205);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm HV";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(275, 205);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(203, 205);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(131, 205);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.lblFilter);
            this.panelTop.Controls.Add(this.cmbFilter);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnExportCsv);
            this.panelTop.Location = new System.Drawing.Point(15, 48);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(951, 32);
            this.panelTop.TabIndex = 8;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(2, 5);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm (tên hoặc SĐT)";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(106, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(166, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(276, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(344, 5);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(10, 5, 2, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(55, 13);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Trạng thái";
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Còn hạn (đang hoạt động)",
            "Hết hạn",
            "Sắp hết hạn (≤7 ngày)"});
            this.cmbFilter.Location = new System.Drawing.Point(403, 2);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(181, 21);
            this.cmbFilter.TabIndex = 4;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(588, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 21);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Tải lại DS";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(660, 2);
            this.btnExportCsv.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(90, 21);
            this.btnExportCsv.TabIndex = 6;
            this.btnExportCsv.Text = "Xuất CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(15, 84);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.RowTemplate.Height = 24;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(951, 260);
            this.dgvMembers.TabIndex = 7;
            this.dgvMembers.SelectionChanged += new System.EventHandler(this.dgvMembers_SelectionChanged);
            // 
            // frmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 695);
            this.Controls.Add(this.splitBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMember";
            this.Text = "Quản lý hội viên";
            this.Load += new System.EventHandler(this.frmMember_Load);
            this.splitBottom.Panel1.ResumeLayout(false);
            this.splitBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBottom)).EndInit();
            this.splitBottom.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRemaining)).EndInit();
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.grpPackage.ResumeLayout(false);
            this.grpPackage.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitBottom;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.CheckBox chkMemberActive;
        private System.Windows.Forms.CheckBox chkHasTrainer;
        private System.Windows.Forms.NumericUpDown numRemaining;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.DateTimePicker dtpRegister;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.GroupBox grpGender;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpPackage;
        private System.Windows.Forms.Button btnRegisterPackage;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPackage;
        private System.Windows.Forms.Label lblPkg;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.DataGridView dgvMembers;
    }
}