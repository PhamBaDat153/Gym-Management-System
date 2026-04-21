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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_find = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tabCtrl_find_infoP = new System.Windows.Forms.TabControl();
            this.TabCtrl_find = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbox_isKH = new System.Windows.Forms.CheckBox();
            this.cbox_notKH = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbox_n = new System.Windows.Forms.CheckBox();
            this.cbox_y = new System.Windows.Forms.CheckBox();
            this.txtbox_tenGT = new System.Windows.Forms.TextBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_package = new System.Windows.Forms.DataGridView();
            this.package_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.with_trainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCtrl_find_infoP.SuspendLayout();
            this.TabCtrl_find.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.btn_find.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(167)))), ((int)(((byte)(206)))));
            this.btn_find.FlatAppearance.BorderSize = 0;
            this.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_find.ForeColor = System.Drawing.Color.White;
            this.btn_find.Location = new System.Drawing.Point(512, 73);
            this.btn_find.Margin = new System.Windows.Forms.Padding(4);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(217, 58);
            this.btn_find.TabIndex = 3;
            this.btn_find.Text = "Tìm kiếm";
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(211)))), ((int)(((byte)(226)))));
            this.btn_refresh.FlatAppearance.BorderSize = 0;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(148)))));
            this.btn_refresh.Location = new System.Drawing.Point(512, 151);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(217, 58);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Làm mới bộ lọc";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // tabCtrl_find_infoP
            // 
            this.tabCtrl_find_infoP.Controls.Add(this.TabCtrl_find);
            this.tabCtrl_find_infoP.Controls.Add(this.tabPage2);
            this.tabCtrl_find_infoP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabCtrl_find_infoP.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabCtrl_find_infoP.Location = new System.Drawing.Point(0, 636);
            this.tabCtrl_find_infoP.Margin = new System.Windows.Forms.Padding(4);
            this.tabCtrl_find_infoP.Name = "tabCtrl_find_infoP";
            this.tabCtrl_find_infoP.SelectedIndex = 0;
            this.tabCtrl_find_infoP.Size = new System.Drawing.Size(1541, 334);
            this.tabCtrl_find_infoP.TabIndex = 4;
            this.tabCtrl_find_infoP.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_find_infoP_SelectedIndexChanged);
            // 
            // TabCtrl_find
            // 
            this.TabCtrl_find.Controls.Add(this.groupBox5);
            this.TabCtrl_find.Controls.Add(this.groupBox4);
            this.TabCtrl_find.Controls.Add(this.btn_find);
            this.TabCtrl_find.Controls.Add(this.btn_refresh);
            this.TabCtrl_find.Controls.Add(this.txtbox_tenGT);
            this.TabCtrl_find.Controls.Add(this.label4);
            this.TabCtrl_find.Controls.Add(this.label9);
            this.TabCtrl_find.Location = new System.Drawing.Point(4, 33);
            this.TabCtrl_find.Margin = new System.Windows.Forms.Padding(4);
            this.TabCtrl_find.Name = "TabCtrl_find";
            this.TabCtrl_find.Padding = new System.Windows.Forms.Padding(4);
            this.TabCtrl_find.Size = new System.Drawing.Size(1533, 297);
            this.TabCtrl_find.TabIndex = 0;
            this.TabCtrl_find.Text = "Tìm kiếm ";
            this.TabCtrl_find.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabCtrl_find.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbox_isKH);
            this.groupBox5.Controls.Add(this.cbox_notKH);
            this.groupBox5.Location = new System.Drawing.Point(188, 109);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(301, 100);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trạng thái";
            // 
            // cbox_isKH
            // 
            this.cbox_isKH.AutoSize = true;
            this.cbox_isKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_isKH.Location = new System.Drawing.Point(21, 33);
            this.cbox_isKH.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_isKH.Name = "cbox_isKH";
            this.cbox_isKH.Size = new System.Drawing.Size(163, 24);
            this.cbox_isKH.TabIndex = 21;
            this.cbox_isKH.Text = "ĐÃ KÍCH HOẠT";
            this.cbox_isKH.UseVisualStyleBackColor = true;
            this.cbox_isKH.CheckedChanged += new System.EventHandler(this.cbox_isKH_CheckedChanged);
            // 
            // cbox_notKH
            // 
            this.cbox_notKH.AutoSize = true;
            this.cbox_notKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_notKH.Location = new System.Drawing.Point(21, 65);
            this.cbox_notKH.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_notKH.Name = "cbox_notKH";
            this.cbox_notKH.Size = new System.Drawing.Size(190, 24);
            this.cbox_notKH.TabIndex = 21;
            this.cbox_notKH.Text = "CHƯA KÍCH HOẠT";
            this.cbox_notKH.UseVisualStyleBackColor = true;
            this.cbox_notKH.CheckedChanged += new System.EventHandler(this.cbox_notKH_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbox_n);
            this.groupBox4.Controls.Add(this.cbox_y);
            this.groupBox4.Location = new System.Drawing.Point(8, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 100);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tập với PT";
            // 
            // cbox_n
            // 
            this.cbox_n.AutoSize = true;
            this.cbox_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_n.Location = new System.Drawing.Point(13, 65);
            this.cbox_n.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_n.Name = "cbox_n";
            this.cbox_n.Size = new System.Drawing.Size(98, 24);
            this.cbox_n.TabIndex = 22;
            this.cbox_n.Text = "KHÔNG";
            this.cbox_n.UseVisualStyleBackColor = true;
            this.cbox_n.CheckedChanged += new System.EventHandler(this.cbox_n_CheckedChanged);
            // 
            // cbox_y
            // 
            this.cbox_y.AutoSize = true;
            this.cbox_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_y.Location = new System.Drawing.Point(13, 33);
            this.cbox_y.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_y.Name = "cbox_y";
            this.cbox_y.Size = new System.Drawing.Size(58, 24);
            this.cbox_y.TabIndex = 21;
            this.cbox_y.Text = "CÓ";
            this.cbox_y.UseVisualStyleBackColor = true;
            this.cbox_y.CheckedChanged += new System.EventHandler(this.cbox_y_CheckedChanged);
            // 
            // txtbox_tenGT
            // 
            this.txtbox_tenGT.Location = new System.Drawing.Point(147, 73);
            this.txtbox_tenGT.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_tenGT.Name = "txtbox_tenGT";
            this.txtbox_tenGT.Size = new System.Drawing.Size(342, 29);
            this.txtbox_tenGT.TabIndex = 1;
            this.txtbox_tenGT.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên gói tập:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(148)))));
            this.label9.Location = new System.Drawing.Point(15, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 36);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1533, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thông tin";
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(148)))));
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.ForeColor = System.Drawing.Color.White;
            this.btn_del.Location = new System.Drawing.Point(551, 259);
            this.btn_del.Margin = new System.Windows.Forms.Padding(4);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(316, 38);
            this.btn_del.TabIndex = 20;
            this.btn_del.Text = "Xóa";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_renew
            // 
            this.btn_renew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(167)))), ((int)(((byte)(206)))));
            this.btn_renew.FlatAppearance.BorderSize = 0;
            this.btn_renew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_renew.ForeColor = System.Drawing.Color.White;
            this.btn_renew.Location = new System.Drawing.Point(551, 206);
            this.btn_renew.Margin = new System.Windows.Forms.Padding(4);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(316, 38);
            this.btn_renew.TabIndex = 20;
            this.btn_renew.Text = "Cập nhật";
            this.btn_renew.UseVisualStyleBackColor = false;
            this.btn_renew.Click += new System.EventHandler(this.btn_renew_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(167)))), ((int)(((byte)(206)))));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(551, 153);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(316, 38);
            this.btn_add.TabIndex = 20;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_daKH);
            this.groupBox2.Controls.Add(this.cbox_cKH);
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(148)))));
            this.groupBox2.Location = new System.Drawing.Point(551, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(316, 128);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng thái gói tập";
            // 
            // cbox_daKH
            // 
            this.cbox_daKH.AutoSize = true;
            this.cbox_daKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_daKH.Location = new System.Drawing.Point(18, 87);
            this.cbox_daKH.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_daKH.Name = "cbox_daKH";
            this.cbox_daKH.Size = new System.Drawing.Size(163, 24);
            this.cbox_daKH.TabIndex = 21;
            this.cbox_daKH.Text = "ĐÃ KÍCH HOẠT";
            this.cbox_daKH.UseVisualStyleBackColor = true;
            this.cbox_daKH.CheckedChanged += new System.EventHandler(this.cbox_daKH_CheckedChanged);
            // 
            // cbox_cKH
            // 
            this.cbox_cKH.AutoSize = true;
            this.cbox_cKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_cKH.Location = new System.Drawing.Point(18, 55);
            this.cbox_cKH.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_cKH.Name = "cbox_cKH";
            this.cbox_cKH.Size = new System.Drawing.Size(190, 24);
            this.cbox_cKH.TabIndex = 21;
            this.cbox_cKH.Text = "CHƯA KÍCH HOẠT";
            this.cbox_cKH.UseVisualStyleBackColor = true;
            this.cbox_cKH.CheckedChanged += new System.EventHandler(this.cbox_cKH_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_khong);
            this.groupBox1.Controls.Add(this.txtbox_packagename);
            this.groupBox1.Controls.Add(this.cbox_co);
            this.groupBox1.Controls.Add(this.txtbox_duration);
            this.groupBox1.Controls.Add(this.txtbox_price);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(148)))));
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(535, 304);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin gói tập";
            // 
            // cbox_khong
            // 
            this.cbox_khong.AutoSize = true;
            this.cbox_khong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_khong.Location = new System.Drawing.Point(350, 189);
            this.cbox_khong.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_khong.Name = "cbox_khong";
            this.cbox_khong.Size = new System.Drawing.Size(98, 24);
            this.cbox_khong.TabIndex = 22;
            this.cbox_khong.Text = "KHÔNG";
            this.cbox_khong.UseVisualStyleBackColor = true;
            this.cbox_khong.CheckedChanged += new System.EventHandler(this.cbox_khong_CheckedChanged);
            // 
            // txtbox_packagename
            // 
            this.txtbox_packagename.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_packagename.Location = new System.Drawing.Point(176, 61);
            this.txtbox_packagename.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_packagename.Name = "txtbox_packagename";
            this.txtbox_packagename.Size = new System.Drawing.Size(272, 29);
            this.txtbox_packagename.TabIndex = 13;
            // 
            // cbox_co
            // 
            this.cbox_co.AutoSize = true;
            this.cbox_co.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_co.Location = new System.Drawing.Point(185, 189);
            this.cbox_co.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_co.Name = "cbox_co";
            this.cbox_co.Size = new System.Drawing.Size(58, 24);
            this.cbox_co.TabIndex = 21;
            this.cbox_co.Text = "CÓ";
            this.cbox_co.UseVisualStyleBackColor = true;
            this.cbox_co.CheckedChanged += new System.EventHandler(this.cbox_co_CheckedChanged);
            // 
            // txtbox_duration
            // 
            this.txtbox_duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_duration.Location = new System.Drawing.Point(176, 102);
            this.txtbox_duration.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_duration.Name = "txtbox_duration";
            this.txtbox_duration.Size = new System.Drawing.Size(272, 29);
            this.txtbox_duration.TabIndex = 13;
            // 
            // txtbox_price
            // 
            this.txtbox_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_price.Location = new System.Drawing.Point(176, 143);
            this.txtbox_price.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_price.Name = "txtbox_price";
            this.txtbox_price.Size = new System.Drawing.Size(272, 29);
            this.txtbox_price.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(68, 146);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 24);
            this.label10.TabIndex = 7;
            this.label10.Text = "Giá trị:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(32, 187);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 24);
            this.label18.TabIndex = 0;
            this.label18.Text = "Tập với PT:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(52, 105);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 24);
            this.label11.TabIndex = 8;
            this.label11.Text = "Thời hạn:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 64);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 24);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tên gói tập:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dgv_package);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(148)))));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1541, 636);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng thông tin gói tập";
            // 
            // dgv_package
            // 
            this.dgv_package.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_package.BackgroundColor = System.Drawing.Color.White;
            this.dgv_package.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_package.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_package.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_package.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.package_id,
            this.package_name,
            this.duration,
            this.price,
            this.with_trainer,
            this.is_active});
            this.dgv_package.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_package.Location = new System.Drawing.Point(4, 27);
            this.dgv_package.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_package.Name = "dgv_package";
            this.dgv_package.RowHeadersVisible = false;
            this.dgv_package.RowHeadersWidth = 51;
            this.dgv_package.Size = new System.Drawing.Size(1533, 605);
            this.dgv_package.TabIndex = 2;
            // 
            // package_id
            // 
            this.package_id.HeaderText = "Mã Gói Tập";
            this.package_id.MinimumWidth = 6;
            this.package_id.Name = "package_id";
            // 
            // package_name
            // 
            this.package_name.HeaderText = "Tên Gói Tập";
            this.package_name.MinimumWidth = 6;
            this.package_name.Name = "package_name";
            // 
            // duration
            // 
            this.duration.HeaderText = "Thời hạn";
            this.duration.MinimumWidth = 6;
            this.duration.Name = "duration";
            // 
            // price
            // 
            this.price.HeaderText = "Giá trị";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            // 
            // with_trainer
            // 
            this.with_trainer.HeaderText = "PT";
            this.with_trainer.MinimumWidth = 6;
            this.with_trainer.Name = "with_trainer";
            // 
            // is_active
            // 
            this.is_active.HeaderText = "Trạng thái";
            this.is_active.MinimumWidth = 6;
            this.is_active.Name = "is_active";
            // 
            // frmPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1541, 970);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabCtrl_find_infoP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPackage";
            this.Text = "frmPackage";
            this.Load += new System.EventHandler(this.frmPackage_Load);
            this.tabCtrl_find_infoP.ResumeLayout(false);
            this.TabCtrl_find.ResumeLayout(false);
            this.TabCtrl_find.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_package)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TabControl tabCtrl_find_infoP;
        private System.Windows.Forms.TabPage TabCtrl_find;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_package;
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
        private System.Windows.Forms.CheckBox cbox_n;
        private System.Windows.Forms.CheckBox cbox_y;
        private System.Windows.Forms.CheckBox cbox_isKH;
        private System.Windows.Forms.CheckBox cbox_notKH;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}