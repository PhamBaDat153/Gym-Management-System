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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_find = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tabCtrl_find_infoP = new System.Windows.Forms.TabControl();
            this.TabCtrl_find = new System.Windows.Forms.TabPage();
            this.cbox_isKH = new System.Windows.Forms.CheckBox();
            this.cbox_n = new System.Windows.Forms.CheckBox();
            this.cbox_y = new System.Windows.Forms.CheckBox();
            this.cbox_notKH = new System.Windows.Forms.CheckBox();
            this.txtbox_tenGT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_renew = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbox_daKH = new System.Windows.Forms.CheckBox();
            this.cbox_cKH = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbox_khong = new System.Windows.Forms.CheckBox();
            this.txtbox_packagename = new System.Windows.Forms.TextBox();
            this.cbox_co = new System.Windows.Forms.CheckBox();
            this.txtbox_duration = new System.Windows.Forms.TextBox();
            this.txtbox_price = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_package = new System.Windows.Forms.DataGridView();
            this.package_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.with_trainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
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
            this.btn_find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_find.BackColor = System.Drawing.Color.Tomato;
            this.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_find.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_find.Location = new System.Drawing.Point(552, 113);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(109, 37);
            this.btn_find.TabIndex = 3;
            this.btn_find.Text = "Tìm kiếm";
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refresh.ForeColor = System.Drawing.Color.Coral;
            this.btn_refresh.Location = new System.Drawing.Point(552, 163);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(109, 38);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Làm mới bộ lọc";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // tabCtrl_find_infoP
            // 
            this.tabCtrl_find_infoP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tabCtrl_find_infoP.Controls.Add(this.TabCtrl_find);
            this.tabCtrl_find_infoP.Controls.Add(this.tabPage2);
            this.tabCtrl_find_infoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrl_find_infoP.Location = new System.Drawing.Point(154, 444);
            this.tabCtrl_find_infoP.Name = "tabCtrl_find_infoP";
            this.tabCtrl_find_infoP.SelectedIndex = 0;
            this.tabCtrl_find_infoP.Size = new System.Drawing.Size(835, 276);
            this.tabCtrl_find_infoP.TabIndex = 4;
            this.tabCtrl_find_infoP.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_find_infoP_SelectedIndexChanged);
            // 
            // TabCtrl_find
            // 
            this.TabCtrl_find.Controls.Add(this.btn_find);
            this.TabCtrl_find.Controls.Add(this.btn_refresh);
            this.TabCtrl_find.Controls.Add(this.cbox_isKH);
            this.TabCtrl_find.Controls.Add(this.cbox_n);
            this.TabCtrl_find.Controls.Add(this.panel5);
            this.TabCtrl_find.Controls.Add(this.panel4);
            this.TabCtrl_find.Controls.Add(this.cbox_y);
            this.TabCtrl_find.Controls.Add(this.cbox_notKH);
            this.TabCtrl_find.Controls.Add(this.txtbox_tenGT);
            this.TabCtrl_find.Controls.Add(this.label8);
            this.TabCtrl_find.Controls.Add(this.label7);
            this.TabCtrl_find.Controls.Add(this.label4);
            this.TabCtrl_find.Controls.Add(this.label9);
            this.TabCtrl_find.Location = new System.Drawing.Point(4, 27);
            this.TabCtrl_find.Name = "TabCtrl_find";
            this.TabCtrl_find.Padding = new System.Windows.Forms.Padding(3);
            this.TabCtrl_find.Size = new System.Drawing.Size(827, 245);
            this.TabCtrl_find.TabIndex = 0;
            this.TabCtrl_find.Text = "Tìm kiếm ";
            this.TabCtrl_find.UseVisualStyleBackColor = true;
            // 
            // cbox_isKH
            // 
            this.cbox_isKH.AutoSize = true;
            this.cbox_isKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_isKH.Location = new System.Drawing.Point(151, 189);
            this.cbox_isKH.Name = "cbox_isKH";
            this.cbox_isKH.Size = new System.Drawing.Size(130, 20);
            this.cbox_isKH.TabIndex = 21;
            this.cbox_isKH.Text = "ĐÃ KÍCH HOẠT";
            this.cbox_isKH.UseVisualStyleBackColor = true;
            // 
            // cbox_n
            // 
            this.cbox_n.AutoSize = true;
            this.cbox_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_n.Location = new System.Drawing.Point(239, 113);
            this.cbox_n.Name = "cbox_n";
            this.cbox_n.Size = new System.Drawing.Size(79, 20);
            this.cbox_n.TabIndex = 22;
            this.cbox_n.Text = "KHÔNG";
            this.cbox_n.UseVisualStyleBackColor = true;
            // 
            // cbox_y
            // 
            this.cbox_y.AutoSize = true;
            this.cbox_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_y.Location = new System.Drawing.Point(152, 114);
            this.cbox_y.Name = "cbox_y";
            this.cbox_y.Size = new System.Drawing.Size(47, 20);
            this.cbox_y.TabIndex = 21;
            this.cbox_y.Text = "CÓ";
            this.cbox_y.UseVisualStyleBackColor = true;
            // 
            // cbox_notKH
            // 
            this.cbox_notKH.AutoSize = true;
            this.cbox_notKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_notKH.Location = new System.Drawing.Point(151, 163);
            this.cbox_notKH.Name = "cbox_notKH";
            this.cbox_notKH.Size = new System.Drawing.Size(152, 20);
            this.cbox_notKH.TabIndex = 21;
            this.cbox_notKH.Text = "CHƯA KÍCH HOẠT";
            this.cbox_notKH.UseVisualStyleBackColor = true;
            // 
            // txtbox_tenGT
            // 
            this.txtbox_tenGT.Location = new System.Drawing.Point(152, 79);
            this.txtbox_tenGT.Name = "txtbox_tenGT";
            this.txtbox_tenGT.Size = new System.Drawing.Size(205, 24);
            this.txtbox_tenGT.TabIndex = 1;
            this.txtbox_tenGT.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.label9.Location = new System.Drawing.Point(47, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tìm kiếm gói tập";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.btn_del);
            this.tabPage2.Controls.Add(this.btn_renew);
            this.tabPage2.Controls.Add(this.btn_add);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(827, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thông tin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.Red;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_del.Location = new System.Drawing.Point(742, 147);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 31);
            this.btn_del.TabIndex = 20;
            this.btn_del.Text = "Xóa";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_renew
            // 
            this.btn_renew.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_renew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_renew.Location = new System.Drawing.Point(572, 138);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(75, 31);
            this.btn_renew.TabIndex = 20;
            this.btn_renew.Text = "Gia hạn";
            this.btn_renew.UseVisualStyleBackColor = false;
            this.btn_renew.Click += new System.EventHandler(this.btn_renew_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Location = new System.Drawing.Point(475, 138);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 31);
            this.btn_add.TabIndex = 20;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_daKH);
            this.groupBox2.Controls.Add(this.cbox_cKH);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(413, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 108);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng thái gói tập";
            // 
            // cbox_daKH
            // 
            this.cbox_daKH.AutoSize = true;
            this.cbox_daKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_daKH.Location = new System.Drawing.Point(186, 57);
            this.cbox_daKH.Name = "cbox_daKH";
            this.cbox_daKH.Size = new System.Drawing.Size(130, 20);
            this.cbox_daKH.TabIndex = 21;
            this.cbox_daKH.Text = "ĐÃ KÍCH HOẠT";
            this.cbox_daKH.UseVisualStyleBackColor = true;
            // 
            // cbox_cKH
            // 
            this.cbox_cKH.AutoSize = true;
            this.cbox_cKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_cKH.Location = new System.Drawing.Point(17, 57);
            this.cbox_cKH.Name = "cbox_cKH";
            this.cbox_cKH.Size = new System.Drawing.Size(152, 20);
            this.cbox_cKH.TabIndex = 21;
            this.cbox_cKH.Text = "CHƯA KÍCH HOẠT";
            this.cbox_cKH.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.cbox_khong);
            this.groupBox1.Controls.Add(this.txtbox_packagename);
            this.groupBox1.Controls.Add(this.cbox_co);
            this.groupBox1.Controls.Add(this.txtbox_duration);
            this.groupBox1.Controls.Add(this.txtbox_price);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 247);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin gói tập";
            // 
            // cbox_khong
            // 
            this.cbox_khong.AutoSize = true;
            this.cbox_khong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_khong.Location = new System.Drawing.Point(229, 152);
            this.cbox_khong.Name = "cbox_khong";
            this.cbox_khong.Size = new System.Drawing.Size(79, 20);
            this.cbox_khong.TabIndex = 22;
            this.cbox_khong.Text = "KHÔNG";
            this.cbox_khong.UseVisualStyleBackColor = true;
            // 
            // txtbox_packagename
            // 
            this.txtbox_packagename.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_packagename.Location = new System.Drawing.Point(132, 49);
            this.txtbox_packagename.Name = "txtbox_packagename";
            this.txtbox_packagename.Size = new System.Drawing.Size(205, 24);
            this.txtbox_packagename.TabIndex = 13;
            // 
            // cbox_co
            // 
            this.cbox_co.AutoSize = true;
            this.cbox_co.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_co.Location = new System.Drawing.Point(139, 152);
            this.cbox_co.Name = "cbox_co";
            this.cbox_co.Size = new System.Drawing.Size(47, 20);
            this.cbox_co.TabIndex = 21;
            this.cbox_co.Text = "CÓ";
            this.cbox_co.UseVisualStyleBackColor = true;
            // 
            // txtbox_duration
            // 
            this.txtbox_duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_duration.Location = new System.Drawing.Point(132, 84);
            this.txtbox_duration.Name = "txtbox_duration";
            this.txtbox_duration.Size = new System.Drawing.Size(59, 24);
            this.txtbox_duration.TabIndex = 13;
            // 
            // txtbox_price
            // 
            this.txtbox_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_price.Location = new System.Drawing.Point(132, 114);
            this.txtbox_price.Name = "txtbox_price";
            this.txtbox_price.Size = new System.Drawing.Size(205, 24);
            this.txtbox_price.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(51, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Giá trị:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(24, 152);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 18);
            this.label18.TabIndex = 0;
            this.label18.Text = "Tập với PT:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Thời hạn:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 18);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tên gói tập:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lí gói tập";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_package);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(2, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1139, 324);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng thông tin gói tập";
            // 
            // dgv_package
            // 
            this.dgv_package.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_package.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_package.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.dgv_package.RowHeadersVisible = false;
            this.dgv_package.Size = new System.Drawing.Size(1133, 299);
            this.dgv_package.TabIndex = 2;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(-1, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 10);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Location = new System.Drawing.Point(-1, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(46, 10);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel3.Location = new System.Drawing.Point(249, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(905, 10);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel4.Location = new System.Drawing.Point(476, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(112, 260);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel5.Location = new System.Drawing.Point(594, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(41, 260);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel6.Location = new System.Drawing.Point(0, 33);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(905, 10);
            this.panel6.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel7.Location = new System.Drawing.Point(413, 64);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(398, 10);
            this.panel7.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel8.Location = new System.Drawing.Point(-7, 428);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1167, 10);
            this.panel8.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel9.Location = new System.Drawing.Point(-7, 737);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1164, 10);
            this.panel9.TabIndex = 6;
            // 
            // frmPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 813);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_package;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_renew;
        private System.Windows.Forms.TextBox txtbox_tenGT;
        private System.Windows.Forms.TextBox txtbox_packagename;
        private System.Windows.Forms.TextBox txtbox_duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn package_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn with_trainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_active;
        private System.Windows.Forms.CheckBox cbox_daKH;
        private System.Windows.Forms.CheckBox cbox_cKH;
        private System.Windows.Forms.CheckBox cbox_khong;
        private System.Windows.Forms.CheckBox cbox_co;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbox_n;
        private System.Windows.Forms.CheckBox cbox_y;
        private System.Windows.Forms.CheckBox cbox_isKH;
        private System.Windows.Forms.CheckBox cbox_notKH;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
    }
}