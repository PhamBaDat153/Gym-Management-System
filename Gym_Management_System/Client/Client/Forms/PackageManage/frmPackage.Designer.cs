namespace Client.Forms.PackageManage
{
    partial class frmPackage
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
            this.btn_find = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tabCtrl_find_infoP = new System.Windows.Forms.TabControl();
            this.TabCtrl_find = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_renew = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_active = new System.Windows.Forms.RadioButton();
            this.rbtn_YES = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbox_price = new System.Windows.Forms.TextBox();
            this.txtbox_maGT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_package = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbox_duration = new System.Windows.Forms.TextBox();
            this.txtbox_packagename = new System.Windows.Forms.TextBox();
            this.txtbox_tenGT = new System.Windows.Forms.TextBox();
            this.rbtn_no = new System.Windows.Forms.RadioButton();
            this.rbtn_khong = new System.Windows.Forms.RadioButton();
            this.rbtn_co = new System.Windows.Forms.RadioButton();
            this.rbtn_noActive = new System.Windows.Forms.RadioButton();
            this.rbtn_cKH = new System.Windows.Forms.RadioButton();
            this.rbtn_daKH = new System.Windows.Forms.RadioButton();
            this.package_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.with_trainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCtrl_find_infoP.SuspendLayout();
            this.TabCtrl_find.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_package)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(54, 275);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(143, 37);
            this.btn_find.TabIndex = 3;
            this.btn_find.Text = "Tìm kiếm";
            this.btn_find.UseVisualStyleBackColor = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(203, 274);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(143, 38);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Làm mới bộ lọc";
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // tabCtrl_find_infoP
            // 
            this.tabCtrl_find_infoP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl_find_infoP.Controls.Add(this.TabCtrl_find);
            this.tabCtrl_find_infoP.Controls.Add(this.tabPage2);
            this.tabCtrl_find_infoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrl_find_infoP.Location = new System.Drawing.Point(832, 122);
            this.tabCtrl_find_infoP.Name = "tabCtrl_find_infoP";
            this.tabCtrl_find_infoP.SelectedIndex = 0;
            this.tabCtrl_find_infoP.Size = new System.Drawing.Size(415, 548);
            this.tabCtrl_find_infoP.TabIndex = 4;
            this.tabCtrl_find_infoP.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_find_infoP_SelectedIndexChanged);
            // 
            // TabCtrl_find
            // 
            this.TabCtrl_find.Controls.Add(this.rbtn_cKH);
            this.TabCtrl_find.Controls.Add(this.rbtn_daKH);
            this.TabCtrl_find.Controls.Add(this.rbtn_khong);
            this.TabCtrl_find.Controls.Add(this.rbtn_co);
            this.TabCtrl_find.Controls.Add(this.btn_refresh);
            this.TabCtrl_find.Controls.Add(this.btn_find);
            this.TabCtrl_find.Controls.Add(this.txtbox_tenGT);
            this.TabCtrl_find.Controls.Add(this.label8);
            this.TabCtrl_find.Controls.Add(this.label7);
            this.TabCtrl_find.Controls.Add(this.label4);
            this.TabCtrl_find.Controls.Add(this.label9);
            this.TabCtrl_find.Location = new System.Drawing.Point(4, 27);
            this.TabCtrl_find.Name = "TabCtrl_find";
            this.TabCtrl_find.Padding = new System.Windows.Forms.Padding(3);
            this.TabCtrl_find.Size = new System.Drawing.Size(407, 517);
            this.TabCtrl_find.TabIndex = 0;
            this.TabCtrl_find.Text = "Tìm kiếm ";
            this.TabCtrl_find.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Trạng thái:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tập với PT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên gói tập:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tìm kiếm gói tập";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_del);
            this.tabPage2.Controls.Add(this.btn_renew);
            this.tabPage2.Controls.Add(this.btn_add);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thông tin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(302, 413);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 31);
            this.btn_del.TabIndex = 20;
            this.btn_del.Text = "Xóa";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // btn_renew
            // 
            this.btn_renew.Location = new System.Drawing.Point(138, 413);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(75, 31);
            this.btn_renew.TabIndex = 20;
            this.btn_renew.Text = "Gia hạn";
            this.btn_renew.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(49, 413);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 31);
            this.btn_add.TabIndex = 20;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_noActive);
            this.groupBox2.Controls.Add(this.rbtn_active);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 108);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng thái gói tập";
            // 
            // rbtn_active
            // 
            this.rbtn_active.AutoSize = true;
            this.rbtn_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_active.Location = new System.Drawing.Point(232, 54);
            this.rbtn_active.Name = "rbtn_active";
            this.rbtn_active.Size = new System.Drawing.Size(142, 22);
            this.rbtn_active.TabIndex = 0;
            this.rbtn_active.TabStop = true;
            this.rbtn_active.Text = "ĐÃ KÍCH HOẠT";
            this.rbtn_active.UseVisualStyleBackColor = true;
            // 
            // rbtn_YES
            // 
            this.rbtn_YES.AutoSize = true;
            this.rbtn_YES.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_YES.Location = new System.Drawing.Point(132, 190);
            this.rbtn_YES.Name = "rbtn_YES";
            this.rbtn_YES.Size = new System.Drawing.Size(51, 22);
            this.rbtn_YES.TabIndex = 0;
            this.rbtn_YES.TabStop = true;
            this.rbtn_YES.Text = "CÓ";
            this.rbtn_YES.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbox_packagename);
            this.groupBox1.Controls.Add(this.rbtn_no);
            this.groupBox1.Controls.Add(this.rbtn_YES);
            this.groupBox1.Controls.Add(this.txtbox_duration);
            this.groupBox1.Controls.Add(this.txtbox_price);
            this.groupBox1.Controls.Add(this.txtbox_maGT);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 247);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin gói tập";
            // 
            // txtbox_price
            // 
            this.txtbox_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_price.Location = new System.Drawing.Point(132, 152);
            this.txtbox_price.Name = "txtbox_price";
            this.txtbox_price.Size = new System.Drawing.Size(205, 24);
            this.txtbox_price.TabIndex = 11;
            // 
            // txtbox_maGT
            // 
            this.txtbox_maGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_maGT.Location = new System.Drawing.Point(132, 49);
            this.txtbox_maGT.Name = "txtbox_maGT";
            this.txtbox_maGT.Size = new System.Drawing.Size(205, 24);
            this.txtbox_maGT.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(51, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Giá trị:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(24, 190);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "Tập với PT:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Thời hạn:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 18);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tên gói tập:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 18);
            this.label13.TabIndex = 10;
            this.label13.Text = "Mã gói tập:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lí gói tập";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_package);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(-1, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(839, 590);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng thông tin gói tập";
            // 
            // dgv_package
            // 
            this.dgv_package.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_package.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.package_id,
            this.package_name,
            this.duration,
            this.price,
            this.with_trainer,
            this.is_active});
            this.dgv_package.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_package.Location = new System.Drawing.Point(3, 22);
            this.dgv_package.Name = "dgv_package";
            this.dgv_package.Size = new System.Drawing.Size(833, 565);
            this.dgv_package.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(2, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1245, 17);
            this.panel1.TabIndex = 6;
            // 
            // txtbox_duration
            // 
            this.txtbox_duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_duration.Location = new System.Drawing.Point(132, 122);
            this.txtbox_duration.Name = "txtbox_duration";
            this.txtbox_duration.Size = new System.Drawing.Size(59, 24);
            this.txtbox_duration.TabIndex = 13;
            // 
            // txtbox_packagename
            // 
            this.txtbox_packagename.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_packagename.Location = new System.Drawing.Point(132, 87);
            this.txtbox_packagename.Name = "txtbox_packagename";
            this.txtbox_packagename.Size = new System.Drawing.Size(205, 24);
            this.txtbox_packagename.TabIndex = 13;
            // 
            // txtbox_tenGT
            // 
            this.txtbox_tenGT.Location = new System.Drawing.Point(152, 79);
            this.txtbox_tenGT.Name = "txtbox_tenGT";
            this.txtbox_tenGT.Size = new System.Drawing.Size(205, 24);
            this.txtbox_tenGT.TabIndex = 1;
            this.txtbox_tenGT.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // rbtn_no
            // 
            this.rbtn_no.AutoSize = true;
            this.rbtn_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_no.Location = new System.Drawing.Point(220, 190);
            this.rbtn_no.Name = "rbtn_no";
            this.rbtn_no.Size = new System.Drawing.Size(87, 22);
            this.rbtn_no.TabIndex = 0;
            this.rbtn_no.TabStop = true;
            this.rbtn_no.Text = "KHÔNG";
            this.rbtn_no.UseVisualStyleBackColor = true;
            // 
            // rbtn_khong
            // 
            this.rbtn_khong.AutoSize = true;
            this.rbtn_khong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_khong.Location = new System.Drawing.Point(241, 111);
            this.rbtn_khong.Name = "rbtn_khong";
            this.rbtn_khong.Size = new System.Drawing.Size(87, 22);
            this.rbtn_khong.TabIndex = 6;
            this.rbtn_khong.TabStop = true;
            this.rbtn_khong.Text = "KHÔNG";
            this.rbtn_khong.UseVisualStyleBackColor = true;
            // 
            // rbtn_co
            // 
            this.rbtn_co.AutoSize = true;
            this.rbtn_co.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_co.Location = new System.Drawing.Point(153, 111);
            this.rbtn_co.Name = "rbtn_co";
            this.rbtn_co.Size = new System.Drawing.Size(51, 22);
            this.rbtn_co.TabIndex = 7;
            this.rbtn_co.TabStop = true;
            this.rbtn_co.Text = "CÓ";
            this.rbtn_co.UseVisualStyleBackColor = true;
            // 
            // rbtn_noActive
            // 
            this.rbtn_noActive.AutoSize = true;
            this.rbtn_noActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_noActive.Location = new System.Drawing.Point(44, 54);
            this.rbtn_noActive.Name = "rbtn_noActive";
            this.rbtn_noActive.Size = new System.Drawing.Size(166, 22);
            this.rbtn_noActive.TabIndex = 1;
            this.rbtn_noActive.TabStop = true;
            this.rbtn_noActive.Text = "CHƯA KÍCH HOẠT";
            this.rbtn_noActive.UseVisualStyleBackColor = true;
            // 
            // rbtn_cKH
            // 
            this.rbtn_cKH.AutoSize = true;
            this.rbtn_cKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_cKH.Location = new System.Drawing.Point(152, 163);
            this.rbtn_cKH.Name = "rbtn_cKH";
            this.rbtn_cKH.Size = new System.Drawing.Size(166, 22);
            this.rbtn_cKH.TabIndex = 9;
            this.rbtn_cKH.TabStop = true;
            this.rbtn_cKH.Text = "CHƯA KÍCH HOẠT";
            this.rbtn_cKH.UseVisualStyleBackColor = true;
            // 
            // rbtn_daKH
            // 
            this.rbtn_daKH.AutoSize = true;
            this.rbtn_daKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_daKH.Location = new System.Drawing.Point(152, 191);
            this.rbtn_daKH.Name = "rbtn_daKH";
            this.rbtn_daKH.Size = new System.Drawing.Size(142, 22);
            this.rbtn_daKH.TabIndex = 8;
            this.rbtn_daKH.TabStop = true;
            this.rbtn_daKH.Text = "ĐÃ KÍCH HOẠT";
            this.rbtn_daKH.UseVisualStyleBackColor = true;
            // 
            // package_id
            // 
            this.package_id.HeaderText = "Mã Gói Tập";
            this.package_id.Name = "package_id";
            // 
            // package_name
            // 
            this.package_name.HeaderText = "Tên Gói Tập";
            this.package_name.Name = "package_name";
            // 
            // duration
            // 
            this.duration.HeaderText = "Thời hạn";
            this.duration.Name = "duration";
            // 
            // price
            // 
            this.price.HeaderText = "Giá trị";
            this.price.Name = "price";
            // 
            // with_trainer
            // 
            this.with_trainer.HeaderText = "PT";
            this.with_trainer.Name = "with_trainer";
            // 
            // is_active
            // 
            this.is_active.HeaderText = "Trạng thái";
            this.is_active.Name = "is_active";
            // 
            // frmPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 695);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabCtrl_find_infoP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPackage";
            this.Text = "frmPackage";
            this.Load += new System.EventHandler(this.frmPackage_Load);
            this.tabCtrl_find_infoP.ResumeLayout(false);
            this.TabCtrl_find.ResumeLayout(false);
            this.TabCtrl_find.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_package)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TabControl tabCtrl_find_infoP;
        private System.Windows.Forms.TabPage TabCtrl_find;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbox_price;
        private System.Windows.Forms.TextBox txtbox_maGT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.RadioButton rbtn_active;
        private System.Windows.Forms.RadioButton rbtn_YES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_package;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_renew;
        private System.Windows.Forms.TextBox txtbox_tenGT;
        private System.Windows.Forms.TextBox txtbox_packagename;
        private System.Windows.Forms.TextBox txtbox_duration;
        private System.Windows.Forms.RadioButton rbtn_khong;
        private System.Windows.Forms.RadioButton rbtn_co;
        private System.Windows.Forms.RadioButton rbtn_noActive;
        private System.Windows.Forms.RadioButton rbtn_no;
        private System.Windows.Forms.RadioButton rbtn_cKH;
        private System.Windows.Forms.RadioButton rbtn_daKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn with_trainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_active;
    }
}