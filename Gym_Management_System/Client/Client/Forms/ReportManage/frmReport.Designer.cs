namespace Client.Forms.ReportManage
{
    partial class frmReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel_toolbar = new System.Windows.Forms.Panel();
            this.btn_export = new System.Windows.Forms.Button();
            this.cbo_report_type = new System.Windows.Forms.ComboBox();
            this.lbl_report_type = new System.Windows.Forms.Label();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.panel_grid_host = new System.Windows.Forms.Panel();
            this.dgv_revenue = new System.Windows.Forms.DataGridView();
            this.rev_report_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_best = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_least = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_member = new System.Windows.Forms.DataGridView();
            this.mem_report_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mem_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mem_new = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mem_loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mem_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mem_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mem_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart_report = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabCtrl_find_info = new System.Windows.Forms.TabControl();
            this.tab_search = new System.Windows.Forms.TabPage();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.lbl_to = new System.Windows.Forms.Label();
            this.lbl_from = new System.Windows.Forms.Label();
            this.lbl_search_title = new System.Windows.Forms.Label();
            this.tab_info = new System.Windows.Forms.TabPage();
            this.panel_info_body = new System.Windows.Forms.Panel();
            this.groupBox_revenue = new System.Windows.Forms.GroupBox();
            this.dtp_rev_date = new System.Windows.Forms.DateTimePicker();
            this.txt_rev_profit = new System.Windows.Forms.TextBox();
            this.txt_rev_cost = new System.Windows.Forms.TextBox();
            this.txt_rev_amount = new System.Windows.Forms.TextBox();
            this.txt_rev_sold = new System.Windows.Forms.TextBox();
            this.txt_rev_least = new System.Windows.Forms.TextBox();
            this.txt_rev_best = new System.Windows.Forms.TextBox();
            this.lbl_rev_date = new System.Windows.Forms.Label();
            this.lbl_rev_profit = new System.Windows.Forms.Label();
            this.lbl_rev_cost = new System.Windows.Forms.Label();
            this.lbl_rev_amount = new System.Windows.Forms.Label();
            this.lbl_rev_sold = new System.Windows.Forms.Label();
            this.lbl_rev_least = new System.Windows.Forms.Label();
            this.lbl_rev_best = new System.Windows.Forms.Label();
            this.groupBox_member = new System.Windows.Forms.GroupBox();
            this.grp_gender_common = new System.Windows.Forms.GroupBox();
            this.rdo_mem_nu = new System.Windows.Forms.RadioButton();
            this.rdo_mem_nam = new System.Windows.Forms.RadioButton();
            this.dtp_mem_date = new System.Windows.Forms.DateTimePicker();
            this.txt_mem_avg_age = new System.Windows.Forms.TextBox();
            this.txt_mem_loss = new System.Windows.Forms.TextBox();
            this.txt_mem_new = new System.Windows.Forms.TextBox();
            this.txt_mem_total = new System.Windows.Forms.TextBox();
            this.lbl_mem_date = new System.Windows.Forms.Label();
            this.lbl_mem_age = new System.Windows.Forms.Label();
            this.lbl_mem_loss = new System.Windows.Forms.Label();
            this.lbl_mem_new = new System.Windows.Forms.Label();
            this.lbl_mem_total = new System.Windows.Forms.Label();
            this.panel_btns = new System.Windows.Forms.Panel();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_renew = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.splitContainer_bottom = new System.Windows.Forms.SplitContainer();
            this.panel_toolbar.SuspendLayout();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            this.panel_grid_host.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_revenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_member)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_report)).BeginInit();
            this.tabCtrl_find_info.SuspendLayout();
            this.tab_search.SuspendLayout();
            this.tab_info.SuspendLayout();
            this.panel_info_body.SuspendLayout();
            this.groupBox_revenue.SuspendLayout();
            this.groupBox_member.SuspendLayout();
            this.grp_gender_common.SuspendLayout();
            this.panel_btns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bottom)).BeginInit();
            this.splitContainer_bottom.Panel1.SuspendLayout();
            this.splitContainer_bottom.Panel2.SuspendLayout();
            this.splitContainer_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_toolbar
            // 
            this.panel_toolbar.Controls.Add(this.btn_export);
            this.panel_toolbar.Controls.Add(this.cbo_report_type);
            this.panel_toolbar.Controls.Add(this.lbl_report_type);
            this.panel_toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_toolbar.Location = new System.Drawing.Point(4, 29);
            this.panel_toolbar.Name = "panel_toolbar";
            this.panel_toolbar.Padding = new System.Windows.Forms.Padding(0, 6, 8, 6);
            this.panel_toolbar.Size = new System.Drawing.Size(1274, 52);
            this.panel_toolbar.TabIndex = 0;
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.BackColor = System.Drawing.Color.LightGreen;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_export.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_export.Location = new System.Drawing.Point(1073, 8);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(196, 34);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "Xuất Excel (CSV)";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // cbo_report_type
            // 
            this.cbo_report_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_report_type.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.cbo_report_type.FormattingEnabled = true;
            this.cbo_report_type.Location = new System.Drawing.Point(160, 10);
            this.cbo_report_type.Name = "cbo_report_type";
            this.cbo_report_type.Size = new System.Drawing.Size(320, 31);
            this.cbo_report_type.TabIndex = 1;
            this.cbo_report_type.SelectedIndexChanged += new System.EventHandler(this.cbo_report_type_SelectedIndexChanged);
            // 
            // lbl_report_type
            // 
            this.lbl_report_type.AutoSize = true;
            this.lbl_report_type.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lbl_report_type.Location = new System.Drawing.Point(8, 13);
            this.lbl_report_type.Name = "lbl_report_type";
            this.lbl_report_type.Size = new System.Drawing.Size(124, 25);
            this.lbl_report_type.TabIndex = 0;
            this.lbl_report_type.Text = "Loại báo cáo:";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.splitContainer_main);
            this.groupBox_main.Controls.Add(this.panel_toolbar);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_main.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_main.Location = new System.Drawing.Point(0, 0);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_main.Size = new System.Drawing.Size(1282, 332);
            this.groupBox_main.TabIndex = 0;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "Bảng dữ liệu";
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main.Location = new System.Drawing.Point(4, 81);
            this.splitContainer_main.Name = "splitContainer_main";
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.Controls.Add(this.panel_grid_host);
            this.splitContainer_main.Panel2Collapsed = true;
            this.splitContainer_main.Size = new System.Drawing.Size(1274, 247);
            this.splitContainer_main.SplitterDistance = 695;
            this.splitContainer_main.TabIndex = 1;
            // 
            // panel_grid_host
            // 
            this.panel_grid_host.Controls.Add(this.dgv_revenue);
            this.panel_grid_host.Controls.Add(this.dgv_member);
            this.panel_grid_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_grid_host.Location = new System.Drawing.Point(0, 0);
            this.panel_grid_host.Name = "panel_grid_host";
            this.panel_grid_host.Size = new System.Drawing.Size(1274, 247);
            this.panel_grid_host.TabIndex = 0;
            // 
            // dgv_revenue
            // 
            this.dgv_revenue.AllowUserToAddRows = false;
            this.dgv_revenue.AllowUserToDeleteRows = false;
            this.dgv_revenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_revenue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_revenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_revenue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rev_report_id,
            this.rev_best,
            this.rev_least,
            this.rev_sold,
            this.rev_amount,
            this.rev_cost,
            this.rev_profit,
            this.rev_date});
            this.dgv_revenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_revenue.Location = new System.Drawing.Point(0, 0);
            this.dgv_revenue.MultiSelect = false;
            this.dgv_revenue.Name = "dgv_revenue";
            this.dgv_revenue.RowHeadersVisible = false;
            this.dgv_revenue.RowHeadersWidth = 51;
            this.dgv_revenue.RowTemplate.Height = 24;
            this.dgv_revenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_revenue.Size = new System.Drawing.Size(1274, 247);
            this.dgv_revenue.TabIndex = 1;
            this.dgv_revenue.Visible = false;
            this.dgv_revenue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_revenue_CellClick);
            // 
            // rev_report_id
            // 
            this.rev_report_id.HeaderText = "Mã báo cáo";
            this.rev_report_id.MinimumWidth = 220;
            this.rev_report_id.Name = "rev_report_id";
            this.rev_report_id.ReadOnly = true;
            this.rev_report_id.Visible = false;
            // 
            // rev_best
            // 
            this.rev_best.HeaderText = "Gói bán chạy";
            this.rev_best.MinimumWidth = 180;
            this.rev_best.Name = "rev_best";
            this.rev_best.ReadOnly = true;
            // 
            // rev_least
            // 
            this.rev_least.HeaderText = "Gói bán ế";
            this.rev_least.MinimumWidth = 180;
            this.rev_least.Name = "rev_least";
            this.rev_least.ReadOnly = true;
            // 
            // rev_sold
            // 
            this.rev_sold.HeaderText = "Tổng gói bán";
            this.rev_sold.MinimumWidth = 120;
            this.rev_sold.Name = "rev_sold";
            this.rev_sold.ReadOnly = true;
            // 
            // rev_amount
            // 
            this.rev_amount.HeaderText = "Tổng thu";
            this.rev_amount.MinimumWidth = 140;
            this.rev_amount.Name = "rev_amount";
            this.rev_amount.ReadOnly = true;
            // 
            // rev_cost
            // 
            this.rev_cost.HeaderText = "Tổng chi";
            this.rev_cost.MinimumWidth = 140;
            this.rev_cost.Name = "rev_cost";
            this.rev_cost.ReadOnly = true;
            // 
            // rev_profit
            // 
            this.rev_profit.HeaderText = "Lợi nhuận";
            this.rev_profit.MinimumWidth = 140;
            this.rev_profit.Name = "rev_profit";
            this.rev_profit.ReadOnly = true;
            // 
            // rev_date
            // 
            this.rev_date.HeaderText = "Ngày báo cáo";
            this.rev_date.MinimumWidth = 130;
            this.rev_date.Name = "rev_date";
            this.rev_date.ReadOnly = true;
            // 
            // dgv_member
            // 
            this.dgv_member.AllowUserToAddRows = false;
            this.dgv_member.AllowUserToDeleteRows = false;
            this.dgv_member.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_member.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_member.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mem_report_id,
            this.mem_total,
            this.mem_new,
            this.mem_loss,
            this.mem_age,
            this.mem_gender,
            this.mem_date});
            this.dgv_member.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_member.Location = new System.Drawing.Point(0, 0);
            this.dgv_member.MultiSelect = false;
            this.dgv_member.Name = "dgv_member";
            this.dgv_member.RowHeadersVisible = false;
            this.dgv_member.RowHeadersWidth = 51;
            this.dgv_member.RowTemplate.Height = 24;
            this.dgv_member.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_member.Size = new System.Drawing.Size(1274, 247);
            this.dgv_member.TabIndex = 0;
            this.dgv_member.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_member_CellClick);
            // 
            // mem_report_id
            // 
            this.mem_report_id.HeaderText = "Mã báo cáo";
            this.mem_report_id.MinimumWidth = 220;
            this.mem_report_id.Name = "mem_report_id";
            this.mem_report_id.ReadOnly = true;
            this.mem_report_id.Visible = false;
            // 
            // mem_total
            // 
            this.mem_total.HeaderText = "Tổng HV";
            this.mem_total.MinimumWidth = 110;
            this.mem_total.Name = "mem_total";
            this.mem_total.ReadOnly = true;
            // 
            // mem_new
            // 
            this.mem_new.HeaderText = "HV mới (tháng)";
            this.mem_new.MinimumWidth = 130;
            this.mem_new.Name = "mem_new";
            this.mem_new.ReadOnly = true;
            // 
            // mem_loss
            // 
            this.mem_loss.HeaderText = "HV mất (tháng)";
            this.mem_loss.MinimumWidth = 130;
            this.mem_loss.Name = "mem_loss";
            this.mem_loss.ReadOnly = true;
            // 
            // mem_age
            // 
            this.mem_age.HeaderText = "Tuổi TB";
            this.mem_age.MinimumWidth = 90;
            this.mem_age.Name = "mem_age";
            this.mem_age.ReadOnly = true;
            // 
            // mem_gender
            // 
            this.mem_gender.HeaderText = "Giới tính chủ yếu";
            this.mem_gender.MinimumWidth = 140;
            this.mem_gender.Name = "mem_gender";
            this.mem_gender.ReadOnly = true;
            // 
            // mem_date
            // 
            this.mem_date.HeaderText = "Ngày báo cáo";
            this.mem_date.MinimumWidth = 130;
            this.mem_date.Name = "mem_date";
            this.mem_date.ReadOnly = true;
            // 
            // chart_report
            // 
            chartArea2.Name = "MainArea";
            this.chart_report.ChartAreas.Add(chartArea2);
            this.chart_report.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_report.Legends.Add(legend2);
            this.chart_report.Location = new System.Drawing.Point(0, 0);
            this.chart_report.Name = "chart_report";
            this.chart_report.Size = new System.Drawing.Size(637, 361);
            this.chart_report.TabIndex = 0;
            this.chart_report.Text = "chart_report";
            // 
            // tabCtrl_find_info
            // 
            this.tabCtrl_find_info.Controls.Add(this.tab_search);
            this.tabCtrl_find_info.Controls.Add(this.tab_info);
            this.tabCtrl_find_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl_find_info.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabCtrl_find_info.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl_find_info.Name = "tabCtrl_find_info";
            this.tabCtrl_find_info.SelectedIndex = 0;
            this.tabCtrl_find_info.Size = new System.Drawing.Size(641, 361);
            this.tabCtrl_find_info.TabIndex = 1;
            this.tabCtrl_find_info.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_find_info_SelectedIndexChanged);
            // 
            // tab_search
            // 
            this.tab_search.Controls.Add(this.btn_refresh);
            this.tab_search.Controls.Add(this.btn_find);
            this.tab_search.Controls.Add(this.dtp_to);
            this.tab_search.Controls.Add(this.dtp_from);
            this.tab_search.Controls.Add(this.lbl_to);
            this.tab_search.Controls.Add(this.lbl_from);
            this.tab_search.Controls.Add(this.lbl_search_title);
            this.tab_search.Location = new System.Drawing.Point(4, 32);
            this.tab_search.Name = "tab_search";
            this.tab_search.Padding = new System.Windows.Forms.Padding(4);
            this.tab_search.Size = new System.Drawing.Size(633, 325);
            this.tab_search.TabIndex = 0;
            this.tab_search.Text = "Tìm kiếm";
            this.tab_search.UseVisualStyleBackColor = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refresh.ForeColor = System.Drawing.Color.Coral;
            this.btn_refresh.Location = new System.Drawing.Point(385, 96);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(240, 42);
            this.btn_refresh.TabIndex = 6;
            this.btn_refresh.Text = "Làm mới bộ lọc";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_find
            // 
            this.btn_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_find.BackColor = System.Drawing.Color.Tomato;
            this.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_find.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_find.Location = new System.Drawing.Point(385, 42);
            this.btn_find.Margin = new System.Windows.Forms.Padding(4);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(240, 42);
            this.btn_find.TabIndex = 5;
            this.btn_find.Text = "Tìm kiếm";
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "yyyy";
            this.dtp_to.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(147, 130);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.ShowUpDown = true;
            this.dtp_to.Size = new System.Drawing.Size(180, 30);
            this.dtp_to.TabIndex = 4;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "MM";
            this.dtp_from.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(147, 82);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.ShowUpDown = true;
            this.dtp_from.Size = new System.Drawing.Size(120, 30);
            this.dtp_from.TabIndex = 3;
            // 
            // lbl_to
            // 
            this.lbl_to.AutoSize = true;
            this.lbl_to.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_to.Location = new System.Drawing.Point(17, 133);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(51, 23);
            this.lbl_to.TabIndex = 2;
            this.lbl_to.Text = "Năm:";
            // 
            // lbl_from
            // 
            this.lbl_from.AutoSize = true;
            this.lbl_from.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_from.Location = new System.Drawing.Point(17, 85);
            this.lbl_from.Name = "lbl_from";
            this.lbl_from.Size = new System.Drawing.Size(62, 23);
            this.lbl_from.TabIndex = 1;
            this.lbl_from.Text = "Tháng:";
            // 
            // lbl_search_title
            // 
            this.lbl_search_title.AutoSize = true;
            this.lbl_search_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_search_title.Location = new System.Drawing.Point(15, 15);
            this.lbl_search_title.Name = "lbl_search_title";
            this.lbl_search_title.Size = new System.Drawing.Size(272, 37);
            this.lbl_search_title.TabIndex = 0;
            this.lbl_search_title.Text = "Lọc theo kỳ báo cáo";
            // 
            // tab_info
            // 
            this.tab_info.Controls.Add(this.panel_info_body);
            this.tab_info.Controls.Add(this.panel_btns);
            this.tab_info.Location = new System.Drawing.Point(4, 32);
            this.tab_info.Name = "tab_info";
            this.tab_info.Padding = new System.Windows.Forms.Padding(4);
            this.tab_info.Size = new System.Drawing.Size(633, 325);
            this.tab_info.TabIndex = 1;
            this.tab_info.Text = "Thông tin";
            this.tab_info.UseVisualStyleBackColor = true;
            // 
            // panel_info_body
            // 
            this.panel_info_body.Controls.Add(this.groupBox_revenue);
            this.panel_info_body.Controls.Add(this.groupBox_member);
            this.panel_info_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_info_body.Location = new System.Drawing.Point(4, 4);
            this.panel_info_body.Name = "panel_info_body";
            this.panel_info_body.Size = new System.Drawing.Size(625, 261);
            this.panel_info_body.TabIndex = 3;
            // 
            // groupBox_revenue
            // 
            this.groupBox_revenue.Controls.Add(this.dtp_rev_date);
            this.groupBox_revenue.Controls.Add(this.txt_rev_profit);
            this.groupBox_revenue.Controls.Add(this.txt_rev_cost);
            this.groupBox_revenue.Controls.Add(this.txt_rev_amount);
            this.groupBox_revenue.Controls.Add(this.txt_rev_sold);
            this.groupBox_revenue.Controls.Add(this.txt_rev_least);
            this.groupBox_revenue.Controls.Add(this.txt_rev_best);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_date);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_profit);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_cost);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_amount);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_sold);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_least);
            this.groupBox_revenue.Controls.Add(this.lbl_rev_best);
            this.groupBox_revenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_revenue.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.groupBox_revenue.Location = new System.Drawing.Point(0, 0);
            this.groupBox_revenue.Name = "groupBox_revenue";
            this.groupBox_revenue.Size = new System.Drawing.Size(625, 261);
            this.groupBox_revenue.TabIndex = 1;
            this.groupBox_revenue.TabStop = false;
            this.groupBox_revenue.Text = "Báo cáo doanh thu (Revenue Report)";
            this.groupBox_revenue.Visible = false;
            // 
            // dtp_rev_date
            // 
            this.dtp_rev_date.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtp_rev_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_rev_date.Location = new System.Drawing.Point(1140, 101);
            this.dtp_rev_date.Name = "dtp_rev_date";
            this.dtp_rev_date.Size = new System.Drawing.Size(200, 30);
            this.dtp_rev_date.TabIndex = 13;
            // 
            // txt_rev_profit
            // 
            this.txt_rev_profit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_rev_profit.Location = new System.Drawing.Point(1140, 62);
            this.txt_rev_profit.Name = "txt_rev_profit";
            this.txt_rev_profit.Size = new System.Drawing.Size(200, 30);
            this.txt_rev_profit.TabIndex = 12;
            // 
            // txt_rev_cost
            // 
            this.txt_rev_cost.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_rev_cost.Location = new System.Drawing.Point(229, 193);
            this.txt_rev_cost.Name = "txt_rev_cost";
            this.txt_rev_cost.Size = new System.Drawing.Size(200, 30);
            this.txt_rev_cost.TabIndex = 11;
            // 
            // txt_rev_amount
            // 
            this.txt_rev_amount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_rev_amount.Location = new System.Drawing.Point(229, 154);
            this.txt_rev_amount.Name = "txt_rev_amount";
            this.txt_rev_amount.Size = new System.Drawing.Size(200, 30);
            this.txt_rev_amount.TabIndex = 10;
            // 
            // txt_rev_sold
            // 
            this.txt_rev_sold.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_rev_sold.Location = new System.Drawing.Point(229, 115);
            this.txt_rev_sold.Name = "txt_rev_sold";
            this.txt_rev_sold.Size = new System.Drawing.Size(200, 30);
            this.txt_rev_sold.TabIndex = 9;
            // 
            // txt_rev_least
            // 
            this.txt_rev_least.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_rev_least.Location = new System.Drawing.Point(229, 79);
            this.txt_rev_least.Name = "txt_rev_least";
            this.txt_rev_least.Size = new System.Drawing.Size(280, 30);
            this.txt_rev_least.TabIndex = 8;
            // 
            // txt_rev_best
            // 
            this.txt_rev_best.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_rev_best.Location = new System.Drawing.Point(229, 40);
            this.txt_rev_best.Name = "txt_rev_best";
            this.txt_rev_best.Size = new System.Drawing.Size(280, 30);
            this.txt_rev_best.TabIndex = 7;
            // 
            // lbl_rev_date
            // 
            this.lbl_rev_date.AutoSize = true;
            this.lbl_rev_date.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_date.Location = new System.Drawing.Point(980, 104);
            this.lbl_rev_date.Name = "lbl_rev_date";
            this.lbl_rev_date.Size = new System.Drawing.Size(116, 23);
            this.lbl_rev_date.TabIndex = 6;
            this.lbl_rev_date.Text = "Ngày báo cáo";
            // 
            // lbl_rev_profit
            // 
            this.lbl_rev_profit.AutoSize = true;
            this.lbl_rev_profit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_profit.Location = new System.Drawing.Point(980, 65);
            this.lbl_rev_profit.Name = "lbl_rev_profit";
            this.lbl_rev_profit.Size = new System.Drawing.Size(86, 23);
            this.lbl_rev_profit.TabIndex = 5;
            this.lbl_rev_profit.Text = "Lợi nhuận";
            // 
            // lbl_rev_cost
            // 
            this.lbl_rev_cost.AutoSize = true;
            this.lbl_rev_cost.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_cost.Location = new System.Drawing.Point(33, 196);
            this.lbl_rev_cost.Name = "lbl_rev_cost";
            this.lbl_rev_cost.Size = new System.Drawing.Size(76, 23);
            this.lbl_rev_cost.TabIndex = 4;
            this.lbl_rev_cost.Text = "Tổng chi";
            // 
            // lbl_rev_amount
            // 
            this.lbl_rev_amount.AutoSize = true;
            this.lbl_rev_amount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_amount.Location = new System.Drawing.Point(33, 157);
            this.lbl_rev_amount.Name = "lbl_rev_amount";
            this.lbl_rev_amount.Size = new System.Drawing.Size(80, 23);
            this.lbl_rev_amount.TabIndex = 3;
            this.lbl_rev_amount.Text = "Tổng thu";
            // 
            // lbl_rev_sold
            // 
            this.lbl_rev_sold.AutoSize = true;
            this.lbl_rev_sold.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_sold.Location = new System.Drawing.Point(33, 118);
            this.lbl_rev_sold.Name = "lbl_rev_sold";
            this.lbl_rev_sold.Size = new System.Drawing.Size(136, 23);
            this.lbl_rev_sold.TabIndex = 2;
            this.lbl_rev_sold.Text = "Tổng gói đã bán";
            // 
            // lbl_rev_least
            // 
            this.lbl_rev_least.AutoSize = true;
            this.lbl_rev_least.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_least.Location = new System.Drawing.Point(33, 82);
            this.lbl_rev_least.Name = "lbl_rev_least";
            this.lbl_rev_least.Size = new System.Drawing.Size(147, 23);
            this.lbl_rev_least.TabIndex = 1;
            this.lbl_rev_least.Text = "Gói bán ít nhất (*)";
            // 
            // lbl_rev_best
            // 
            this.lbl_rev_best.AutoSize = true;
            this.lbl_rev_best.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_rev_best.Location = new System.Drawing.Point(33, 43);
            this.lbl_rev_best.Name = "lbl_rev_best";
            this.lbl_rev_best.Size = new System.Drawing.Size(172, 23);
            this.lbl_rev_best.TabIndex = 0;
            this.lbl_rev_best.Text = "Gói bán chạy nhất (*)";
            // 
            // groupBox_member
            // 
            this.groupBox_member.Controls.Add(this.grp_gender_common);
            this.groupBox_member.Controls.Add(this.dtp_mem_date);
            this.groupBox_member.Controls.Add(this.txt_mem_avg_age);
            this.groupBox_member.Controls.Add(this.txt_mem_loss);
            this.groupBox_member.Controls.Add(this.txt_mem_new);
            this.groupBox_member.Controls.Add(this.txt_mem_total);
            this.groupBox_member.Controls.Add(this.lbl_mem_date);
            this.groupBox_member.Controls.Add(this.lbl_mem_age);
            this.groupBox_member.Controls.Add(this.lbl_mem_loss);
            this.groupBox_member.Controls.Add(this.lbl_mem_new);
            this.groupBox_member.Controls.Add(this.lbl_mem_total);
            this.groupBox_member.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_member.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.groupBox_member.Location = new System.Drawing.Point(0, 0);
            this.groupBox_member.Name = "groupBox_member";
            this.groupBox_member.Size = new System.Drawing.Size(625, 261);
            this.groupBox_member.TabIndex = 0;
            this.groupBox_member.TabStop = false;
            this.groupBox_member.Text = "Báo cáo hội viên (MemberReport)";
            // 
            // grp_gender_common
            // 
            this.grp_gender_common.Controls.Add(this.rdo_mem_nu);
            this.grp_gender_common.Controls.Add(this.rdo_mem_nam);
            this.grp_gender_common.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grp_gender_common.Location = new System.Drawing.Point(980, 40);
            this.grp_gender_common.Name = "grp_gender_common";
            this.grp_gender_common.Size = new System.Drawing.Size(160, 100);
            this.grp_gender_common.TabIndex = 10;
            this.grp_gender_common.TabStop = false;
            this.grp_gender_common.Text = "Giới tính chủ yếu";
            // 
            // rdo_mem_nu
            // 
            this.rdo_mem_nu.AutoSize = true;
            this.rdo_mem_nu.Location = new System.Drawing.Point(16, 62);
            this.rdo_mem_nu.Name = "rdo_mem_nu";
            this.rdo_mem_nu.Size = new System.Drawing.Size(52, 24);
            this.rdo_mem_nu.TabIndex = 1;
            this.rdo_mem_nu.TabStop = true;
            this.rdo_mem_nu.Text = "Nữ";
            this.rdo_mem_nu.UseVisualStyleBackColor = true;
            // 
            // rdo_mem_nam
            // 
            this.rdo_mem_nam.AutoSize = true;
            this.rdo_mem_nam.Location = new System.Drawing.Point(16, 32);
            this.rdo_mem_nam.Name = "rdo_mem_nam";
            this.rdo_mem_nam.Size = new System.Drawing.Size(64, 24);
            this.rdo_mem_nam.TabIndex = 0;
            this.rdo_mem_nam.TabStop = true;
            this.rdo_mem_nam.Text = "Nam";
            this.rdo_mem_nam.UseVisualStyleBackColor = true;
            // 
            // dtp_mem_date
            // 
            this.dtp_mem_date.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtp_mem_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_mem_date.Location = new System.Drawing.Point(220, 164);
            this.dtp_mem_date.Name = "dtp_mem_date";
            this.dtp_mem_date.Size = new System.Drawing.Size(280, 30);
            this.dtp_mem_date.TabIndex = 9;
            // 
            // txt_mem_avg_age
            // 
            this.txt_mem_avg_age.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_mem_avg_age.Location = new System.Drawing.Point(220, 130);
            this.txt_mem_avg_age.Name = "txt_mem_avg_age";
            this.txt_mem_avg_age.Size = new System.Drawing.Size(280, 30);
            this.txt_mem_avg_age.TabIndex = 8;
            // 
            // txt_mem_loss
            // 
            this.txt_mem_loss.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_mem_loss.Location = new System.Drawing.Point(220, 96);
            this.txt_mem_loss.Name = "txt_mem_loss";
            this.txt_mem_loss.Size = new System.Drawing.Size(280, 30);
            this.txt_mem_loss.TabIndex = 7;
            // 
            // txt_mem_new
            // 
            this.txt_mem_new.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_mem_new.Location = new System.Drawing.Point(220, 62);
            this.txt_mem_new.Name = "txt_mem_new";
            this.txt_mem_new.Size = new System.Drawing.Size(280, 30);
            this.txt_mem_new.TabIndex = 6;
            // 
            // txt_mem_total
            // 
            this.txt_mem_total.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_mem_total.Location = new System.Drawing.Point(220, 28);
            this.txt_mem_total.Name = "txt_mem_total";
            this.txt_mem_total.Size = new System.Drawing.Size(280, 30);
            this.txt_mem_total.TabIndex = 5;
            // 
            // lbl_mem_date
            // 
            this.lbl_mem_date.AutoSize = true;
            this.lbl_mem_date.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_mem_date.Location = new System.Drawing.Point(24, 167);
            this.lbl_mem_date.Name = "lbl_mem_date";
            this.lbl_mem_date.Size = new System.Drawing.Size(116, 23);
            this.lbl_mem_date.TabIndex = 4;
            this.lbl_mem_date.Text = "Ngày báo cáo";
            // 
            // lbl_mem_age
            // 
            this.lbl_mem_age.AutoSize = true;
            this.lbl_mem_age.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_mem_age.Location = new System.Drawing.Point(24, 133);
            this.lbl_mem_age.Name = "lbl_mem_age";
            this.lbl_mem_age.Size = new System.Drawing.Size(151, 23);
            this.lbl_mem_age.TabIndex = 3;
            this.lbl_mem_age.Text = "Tuổi trung bình (*)";
            // 
            // lbl_mem_loss
            // 
            this.lbl_mem_loss.AutoSize = true;
            this.lbl_mem_loss.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_mem_loss.Location = new System.Drawing.Point(24, 99);
            this.lbl_mem_loss.Name = "lbl_mem_loss";
            this.lbl_mem_loss.Size = new System.Drawing.Size(187, 23);
            this.lbl_mem_loss.TabIndex = 2;
            this.lbl_mem_loss.Text = "HV mất trong tháng (*)";
            // 
            // lbl_mem_new
            // 
            this.lbl_mem_new.AutoSize = true;
            this.lbl_mem_new.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_mem_new.Location = new System.Drawing.Point(24, 65);
            this.lbl_mem_new.Name = "lbl_mem_new";
            this.lbl_mem_new.Size = new System.Drawing.Size(164, 23);
            this.lbl_mem_new.TabIndex = 1;
            this.lbl_mem_new.Text = "HV mới trong tháng";
            // 
            // lbl_mem_total
            // 
            this.lbl_mem_total.AutoSize = true;
            this.lbl_mem_total.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_mem_total.Location = new System.Drawing.Point(24, 33);
            this.lbl_mem_total.Name = "lbl_mem_total";
            this.lbl_mem_total.Size = new System.Drawing.Size(136, 23);
            this.lbl_mem_total.TabIndex = 0;
            this.lbl_mem_total.Text = "Tổng hội viên (*)";
            // 
            // panel_btns
            // 
            this.panel_btns.Controls.Add(this.btn_del);
            this.panel_btns.Controls.Add(this.btn_renew);
            this.panel_btns.Controls.Add(this.btn_add);
            this.panel_btns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_btns.Location = new System.Drawing.Point(4, 265);
            this.panel_btns.Name = "panel_btns";
            this.panel_btns.Size = new System.Drawing.Size(625, 56);
            this.panel_btns.TabIndex = 2;
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.BackColor = System.Drawing.Color.Red;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_del.Location = new System.Drawing.Point(429, 9);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(180, 38);
            this.btn_del.TabIndex = 2;
            this.btn_del.Text = "Xóa";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_renew
            // 
            this.btn_renew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_renew.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_renew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_renew.Location = new System.Drawing.Point(233, 9);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(180, 38);
            this.btn_renew.TabIndex = 1;
            this.btn_renew.Text = "Cập nhật";
            this.btn_renew.UseVisualStyleBackColor = false;
            this.btn_renew.Click += new System.EventHandler(this.btn_renew_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Location = new System.Drawing.Point(37, 9);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(180, 38);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // splitContainer_bottom
            // 
            this.splitContainer_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer_bottom.Location = new System.Drawing.Point(0, 332);
            this.splitContainer_bottom.Name = "splitContainer_bottom";
            // 
            // splitContainer_bottom.Panel1
            // 
            this.splitContainer_bottom.Panel1.Controls.Add(this.tabCtrl_find_info);
            // 
            // splitContainer_bottom.Panel2
            // 
            this.splitContainer_bottom.Panel2.Controls.Add(this.chart_report);
            this.splitContainer_bottom.Size = new System.Drawing.Size(1282, 361);
            this.splitContainer_bottom.SplitterDistance = 641;
            this.splitContainer_bottom.TabIndex = 2;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 693);
            this.Controls.Add(this.groupBox_main);
            this.Controls.Add(this.splitContainer_bottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1300, 740);
            this.Name = "frmReport";
            this.Text = "Quản lý báo cáo";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.panel_toolbar.ResumeLayout(false);
            this.panel_toolbar.PerformLayout();
            this.groupBox_main.ResumeLayout(false);
            this.splitContainer_main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.panel_grid_host.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_revenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_member)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_report)).EndInit();
            this.tabCtrl_find_info.ResumeLayout(false);
            this.tab_search.ResumeLayout(false);
            this.tab_search.PerformLayout();
            this.tab_info.ResumeLayout(false);
            this.panel_info_body.ResumeLayout(false);
            this.groupBox_revenue.ResumeLayout(false);
            this.groupBox_revenue.PerformLayout();
            this.groupBox_member.ResumeLayout(false);
            this.groupBox_member.PerformLayout();
            this.grp_gender_common.ResumeLayout(false);
            this.grp_gender_common.PerformLayout();
            this.panel_btns.ResumeLayout(false);
            this.splitContainer_bottom.Panel1.ResumeLayout(false);
            this.splitContainer_bottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bottom)).EndInit();
            this.splitContainer_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_toolbar;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.ComboBox cbo_report_type;
        private System.Windows.Forms.Label lbl_report_type;
        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.Panel panel_grid_host;
        private System.Windows.Forms.DataGridView dgv_member;
        private System.Windows.Forms.DataGridView dgv_revenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_report;
        private System.Windows.Forms.TabControl tabCtrl_find_info;
        private System.Windows.Forms.TabPage tab_search;
        private System.Windows.Forms.TabPage tab_info;
        private System.Windows.Forms.Panel panel_info_body;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.Label lbl_from;
        private System.Windows.Forms.Label lbl_search_title;
        private System.Windows.Forms.SplitContainer splitContainer_bottom;
        private System.Windows.Forms.Panel panel_btns;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_renew;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.GroupBox groupBox_revenue;
        private System.Windows.Forms.GroupBox groupBox_member;
        private System.Windows.Forms.DateTimePicker dtp_rev_date;
        private System.Windows.Forms.TextBox txt_rev_profit;
        private System.Windows.Forms.TextBox txt_rev_cost;
        private System.Windows.Forms.TextBox txt_rev_amount;
        private System.Windows.Forms.TextBox txt_rev_sold;
        private System.Windows.Forms.TextBox txt_rev_least;
        private System.Windows.Forms.TextBox txt_rev_best;
        private System.Windows.Forms.Label lbl_rev_date;
        private System.Windows.Forms.Label lbl_rev_profit;
        private System.Windows.Forms.Label lbl_rev_cost;
        private System.Windows.Forms.Label lbl_rev_amount;
        private System.Windows.Forms.Label lbl_rev_sold;
        private System.Windows.Forms.Label lbl_rev_least;
        private System.Windows.Forms.Label lbl_rev_best;
        private System.Windows.Forms.GroupBox grp_gender_common;
        private System.Windows.Forms.RadioButton rdo_mem_nu;
        private System.Windows.Forms.RadioButton rdo_mem_nam;
        private System.Windows.Forms.DateTimePicker dtp_mem_date;
        private System.Windows.Forms.TextBox txt_mem_avg_age;
        private System.Windows.Forms.TextBox txt_mem_loss;
        private System.Windows.Forms.TextBox txt_mem_new;
        private System.Windows.Forms.TextBox txt_mem_total;
        private System.Windows.Forms.Label lbl_mem_date;
        private System.Windows.Forms.Label lbl_mem_age;
        private System.Windows.Forms.Label lbl_mem_loss;
        private System.Windows.Forms.Label lbl_mem_new;
        private System.Windows.Forms.Label lbl_mem_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_report_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_new;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_loss;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_report_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_best;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_least;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev_date;
    }
}
