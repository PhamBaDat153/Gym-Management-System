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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbox_maGt = new System.Windows.Forms.TextBox();
            this.txtbox_pp = new System.Windows.Forms.TextBox();
            this.txtbox_coa = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbox_status = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbox_tenG = new System.Windows.Forms.ComboBox();
            this.cbox_tenGT = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.txtbox_price = new System.Windows.Forms.TextBox();
            this.txtbox_maGT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtbox_coach = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.rbtn_notActive = new System.Windows.Forms.RadioButton();
            this.rbtn_active = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_renew = new System.Windows.Forms.Button();
            this.tabCtrl_find_infoP.SuspendLayout();
            this.TabCtrl_find.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(131, 301);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(143, 37);
            this.btn_find.TabIndex = 3;
            this.btn_find.Text = "Tìm kiếm";
            this.btn_find.UseVisualStyleBackColor = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(131, 353);
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
            this.TabCtrl_find.Controls.Add(this.cbox_tenG);
            this.TabCtrl_find.Controls.Add(this.cbox_status);
            this.TabCtrl_find.Controls.Add(this.dateTimePicker1);
            this.TabCtrl_find.Controls.Add(this.txtbox_coa);
            this.TabCtrl_find.Controls.Add(this.txtbox_pp);
            this.TabCtrl_find.Controls.Add(this.btn_refresh);
            this.TabCtrl_find.Controls.Add(this.btn_find);
            this.TabCtrl_find.Controls.Add(this.txbox_maGt);
            this.TabCtrl_find.Controls.Add(this.label8);
            this.TabCtrl_find.Controls.Add(this.label7);
            this.TabCtrl_find.Controls.Add(this.label6);
            this.TabCtrl_find.Controls.Add(this.label5);
            this.TabCtrl_find.Controls.Add(this.label4);
            this.TabCtrl_find.Controls.Add(this.label9);
            this.TabCtrl_find.Controls.Add(this.label3);
            this.TabCtrl_find.Location = new System.Drawing.Point(4, 27);
            this.TabCtrl_find.Name = "TabCtrl_find";
            this.TabCtrl_find.Padding = new System.Windows.Forms.Padding(3);
            this.TabCtrl_find.Size = new System.Drawing.Size(407, 517);
            this.TabCtrl_find.TabIndex = 0;
            this.TabCtrl_find.Text = "Tìm kiếm ";
            this.TabCtrl_find.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã gói tập:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên gói tập:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hết hạn:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Giá trị:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tập với PT:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Trạng thái:";
            // 
            // txbox_maGt
            // 
            this.txbox_maGt.Location = new System.Drawing.Point(152, 74);
            this.txbox_maGt.Name = "txbox_maGt";
            this.txbox_maGt.Size = new System.Drawing.Size(205, 24);
            this.txbox_maGt.TabIndex = 1;
            this.txbox_maGt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtbox_pp
            // 
            this.txtbox_pp.Location = new System.Drawing.Point(152, 177);
            this.txtbox_pp.Name = "txtbox_pp";
            this.txtbox_pp.Size = new System.Drawing.Size(205, 24);
            this.txtbox_pp.TabIndex = 1;
            this.txtbox_pp.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtbox_coa
            // 
            this.txtbox_coa.Location = new System.Drawing.Point(152, 206);
            this.txtbox_coa.Name = "txtbox_coa";
            this.txtbox_coa.Size = new System.Drawing.Size(205, 24);
            this.txtbox_coa.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(153, 149);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbox_status
            // 
            this.cbox_status.FormattingEnabled = true;
            this.cbox_status.Items.AddRange(new object[] {
            "ĐÃ KÍCH HOẠT",
            "CHƯA KÍCH HOẠT"});
            this.cbox_status.Location = new System.Drawing.Point(153, 240);
            this.cbox_status.Name = "cbox_status";
            this.cbox_status.Size = new System.Drawing.Size(121, 26);
            this.cbox_status.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_tenGT);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.txtbox_price);
            this.groupBox1.Controls.Add(this.txtbox_coach);
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
            // cbox_tenG
            // 
            this.cbox_tenG.FormattingEnabled = true;
            this.cbox_tenG.Items.AddRange(new object[] {
            "YOGA",
            "GYM",
            "SPORTDANCE",
            "AEROBIC",
            "BOXING",
            "KICKBOXING"});
            this.cbox_tenG.Location = new System.Drawing.Point(153, 112);
            this.cbox_tenG.Name = "cbox_tenG";
            this.cbox_tenG.Size = new System.Drawing.Size(204, 26);
            this.cbox_tenG.TabIndex = 6;
            this.cbox_tenG.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cbox_tenGT
            // 
            this.cbox_tenGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_tenGT.FormattingEnabled = true;
            this.cbox_tenGT.Items.AddRange(new object[] {
            "YOGA",
            "GYM",
            "SPORTDANCE",
            "AEROBIC",
            "BOXING",
            "KICKBOXING"});
            this.cbox_tenGT.Location = new System.Drawing.Point(133, 87);
            this.cbox_tenGT.Name = "cbox_tenGT";
            this.cbox_tenGT.Size = new System.Drawing.Size(204, 26);
            this.cbox_tenGT.TabIndex = 14;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(132, 125);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker2.TabIndex = 13;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 18);
            this.label11.TabIndex = 8;
            this.label11.Text = "Hết hạn:";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_active);
            this.groupBox2.Controls.Add(this.rbtn_notActive);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 108);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng thái gói tập";
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
            // txtbox_coach
            // 
            this.txtbox_coach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_coach.Location = new System.Drawing.Point(132, 187);
            this.txtbox_coach.Name = "txtbox_coach";
            this.txtbox_coach.Size = new System.Drawing.Size(205, 24);
            this.txtbox_coach.TabIndex = 1;
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
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(302, 413);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 31);
            this.btn_del.TabIndex = 20;
            this.btn_del.Text = "Xóa";
            this.btn_del.UseVisualStyleBackColor = true;
            // 
            // rbtn_notActive
            // 
            this.rbtn_notActive.AutoSize = true;
            this.rbtn_notActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_notActive.Location = new System.Drawing.Point(3, 54);
            this.rbtn_notActive.Name = "rbtn_notActive";
            this.rbtn_notActive.Size = new System.Drawing.Size(166, 22);
            this.rbtn_notActive.TabIndex = 0;
            this.rbtn_notActive.TabStop = true;
            this.rbtn_notActive.Text = "CHƯA KÍCH HOẠT";
            this.rbtn_notActive.UseVisualStyleBackColor = true;
            // 
            // rbtn_active
            // 
            this.rbtn_active.AutoSize = true;
            this.rbtn_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_active.Location = new System.Drawing.Point(202, 54);
            this.rbtn_active.Name = "rbtn_active";
            this.rbtn_active.Size = new System.Drawing.Size(142, 22);
            this.rbtn_active.TabIndex = 0;
            this.rbtn_active.TabStop = true;
            this.rbtn_active.Text = "ĐÃ KÍCH HOẠT";
            this.rbtn_active.UseVisualStyleBackColor = true;
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
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(-1, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(839, 590);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng thông tin gói tập";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(833, 565);
            this.dataGridView1.TabIndex = 2;
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
            // btn_renew
            // 
            this.btn_renew.Location = new System.Drawing.Point(138, 413);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(75, 31);
            this.btn_renew.TabIndex = 20;
            this.btn_renew.Text = "Gia hạn";
            this.btn_renew.UseVisualStyleBackColor = true;
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TabControl tabCtrl_find_infoP;
        private System.Windows.Forms.TabPage TabCtrl_find;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtbox_coa;
        private System.Windows.Forms.TextBox txtbox_pp;
        private System.Windows.Forms.TextBox txbox_maGt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbox_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbox_tenG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbox_tenGT;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtbox_price;
        private System.Windows.Forms.TextBox txtbox_maGT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtbox_coach;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.RadioButton rbtn_active;
        private System.Windows.Forms.RadioButton rbtn_notActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_renew;
    }
}