using Client.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Client.Forms.ReportManage
{
    public partial class frmReport : Form
    {
        private const int KindMember = 0;
        private const int KindRevenue = 1;
        private const int KindInvoice = 2;
        private const int ChartModeAuto = 0;
        private const int ChartModeColumn = 1;
        private const int ChartModeLine = 2;
        private const int KeywordDebounceMs = 350;
        private const string MainChartAreaName = "MainArea";
        private const string MainLegendName = "MainLegend";

        private Label lbl_toolbar_summary;
        private Label lbl_keyword;
        private TextBox txt_keyword;
        private Label lbl_invoice_member_keyword;
        private TextBox txt_invoice_member_keyword;
        private Label lbl_invoice_package_keyword;
        private TextBox txt_invoice_package_keyword;
        private Label lbl_chart_mode;
        private ComboBox cbo_chart_mode;
        private System.Windows.Forms.Timer keywordDebounceTimer;
        private int reloadRequestVersion;
        private bool isInitializingReportForm;
        private DataGridView dgv_invoice;
        private GroupBox groupBox_invoice;
        private TextBox txt_inv_receipt_id;
        private TextBox txt_inv_member;
        private TextBox txt_inv_package;
        private TextBox txt_inv_amount;
        private TextBox txt_inv_method;
        private DateTimePicker dtp_inv_date;

        public frmReport()
        {
            InitializeComponent();
        }

        private async void frmReport_Load(object sender, EventArgs e)
        {
            isInitializingReportForm = true;
            SetupFriendlyUi();
            cbo_report_type.Items.Clear();
            cbo_report_type.Items.Add("Báo cáo hội viên (MemberReport)");
            cbo_report_type.Items.Add("Báo cáo doanh thu (RevenueReport)");
            cbo_report_type.Items.Add("Báo cáo hóa đơn (Receipt)");
            cbo_report_type.SelectedIndex = 0;

            var today = DateTime.Today;
            dtp_from.Value = new DateTime(today.Year, today.Month, 1);
            dtp_to.Value = new DateTime(today.Year, 1, 1);
            dtp_to.MaxDate = today;

            rdo_mem_nam.Checked = true;
            ApplyReportTypeUi();
            isInitializingReportForm = false;
            await ReloadFromFilterAsync();
        }

        private void SetupFriendlyUi()
        {
            SetupInvoiceGrid();
            SetupInvoiceInfoGroup();
            ConfigureMemberDetailMode();
            ConfigureRevenueDetailMode();

            lbl_toolbar_summary = new Label();
            lbl_toolbar_summary.Name = "lbl_toolbar_summary";
            lbl_toolbar_summary.AutoSize = false;
            lbl_toolbar_summary.TextAlign = ContentAlignment.MiddleLeft;
            lbl_toolbar_summary.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lbl_toolbar_summary.Location = new Point(500, 10);
            lbl_toolbar_summary.Size = new Size(Math.Max(220, panel_toolbar.Width - 710), 30);
            lbl_toolbar_summary.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            lbl_toolbar_summary.ForeColor = Color.FromArgb(36, 64, 98);
            panel_toolbar.Controls.Add(lbl_toolbar_summary);
            lbl_toolbar_summary.BringToFront();

            lbl_keyword = new Label();
            lbl_keyword.Name = "lbl_keyword";
            lbl_keyword.AutoSize = true;
            lbl_keyword.Font = new Font("Segoe UI", 10F);
            lbl_keyword.Text = "Từ khóa:";
            lbl_keyword.Location = new Point(17, 169);

            txt_keyword = new TextBox();
            txt_keyword.Name = "txt_keyword";
            txt_keyword.Font = new Font("Segoe UI", 10F);
            txt_keyword.Location = new Point(147, 166);
            txt_keyword.Size = new Size(300, 30);
            txt_keyword.TextChanged += txt_keyword_TextChanged;

            lbl_invoice_member_keyword = new Label();
            lbl_invoice_member_keyword.Name = "lbl_invoice_member_keyword";
            lbl_invoice_member_keyword.AutoSize = true;
            lbl_invoice_member_keyword.Font = new Font("Segoe UI", 10F);
            lbl_invoice_member_keyword.Text = "Tên hội viên:";
            lbl_invoice_member_keyword.Location = new Point(17, 205);
            lbl_invoice_member_keyword.Visible = false;

            txt_invoice_member_keyword = new TextBox();
            txt_invoice_member_keyword.Name = "txt_invoice_member_keyword";
            txt_invoice_member_keyword.Font = new Font("Segoe UI", 10F);
            txt_invoice_member_keyword.Location = new Point(147, 202);
            txt_invoice_member_keyword.Size = new Size(300, 30);
            txt_invoice_member_keyword.TextChanged += txt_keyword_TextChanged;
            txt_invoice_member_keyword.Visible = false;

            lbl_invoice_package_keyword = new Label();
            lbl_invoice_package_keyword.Name = "lbl_invoice_package_keyword";
            lbl_invoice_package_keyword.AutoSize = true;
            lbl_invoice_package_keyword.Font = new Font("Segoe UI", 10F);
            lbl_invoice_package_keyword.Text = "Tên gói:";
            lbl_invoice_package_keyword.Location = new Point(17, 241);
            lbl_invoice_package_keyword.Visible = false;

            txt_invoice_package_keyword = new TextBox();
            txt_invoice_package_keyword.Name = "txt_invoice_package_keyword";
            txt_invoice_package_keyword.Font = new Font("Segoe UI", 10F);
            txt_invoice_package_keyword.Location = new Point(147, 238);
            txt_invoice_package_keyword.Size = new Size(300, 30);
            txt_invoice_package_keyword.TextChanged += txt_keyword_TextChanged;
            txt_invoice_package_keyword.Visible = false;

            keywordDebounceTimer = new System.Windows.Forms.Timer();
            keywordDebounceTimer.Interval = KeywordDebounceMs;
            keywordDebounceTimer.Tick += keywordDebounceTimer_Tick;

            lbl_chart_mode = new Label();
            lbl_chart_mode.Name = "lbl_chart_mode";
            lbl_chart_mode.AutoSize = true;
            lbl_chart_mode.Font = new Font("Segoe UI", 10F);
            lbl_chart_mode.Text = "Biểu đồ:";
            lbl_chart_mode.Location = new Point(17, 205);

            cbo_chart_mode = new ComboBox();
            cbo_chart_mode.Name = "cbo_chart_mode";
            cbo_chart_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_chart_mode.Font = new Font("Segoe UI", 10F);
            cbo_chart_mode.Items.AddRange(new object[] { "Tự động", "Biểu đồ cột", "Biểu đồ đường" });
            cbo_chart_mode.SelectedIndex = ChartModeLine;
            cbo_chart_mode.Location = new Point(147, 202);
            cbo_chart_mode.Size = new Size(300, 30);
            cbo_chart_mode.SelectedIndexChanged += cbo_chart_mode_SelectedIndexChanged;

            tab_search.Controls.Add(lbl_keyword);
            tab_search.Controls.Add(txt_keyword);
            tab_search.Controls.Add(lbl_invoice_member_keyword);
            tab_search.Controls.Add(txt_invoice_member_keyword);
            tab_search.Controls.Add(lbl_invoice_package_keyword);
            tab_search.Controls.Add(txt_invoice_package_keyword);
            tab_search.Controls.Add(lbl_chart_mode);
            tab_search.Controls.Add(cbo_chart_mode);

            // Màn báo cáo chỉ đọc: ẩn hoàn toàn các thao tác CRUD.
            btn_add.Visible = false;
            btn_renew.Visible = false;
            btn_del.Visible = false;
            panel_btns.Visible = false;
            SetDetailSectionReadOnly();
        }

        private void ConfigureMemberDetailMode()
        {
            if (groupBox_member != null) groupBox_member.Text = "Báo cáo chi tiết hội viên";
            if (lbl_mem_total != null) lbl_mem_total.Text = "Họ và tên";
            if (lbl_mem_new != null) lbl_mem_new.Text = "Số điện thoại";
            if (lbl_mem_loss != null) lbl_mem_loss.Text = "Email";
            if (lbl_mem_age != null) lbl_mem_age.Text = "Tuổi";
            if (lbl_mem_date != null) lbl_mem_date.Text = "Ngày đăng ký";
            if (grp_gender_common != null) grp_gender_common.Text = "Giới tính";

            if (mem_total != null) mem_total.HeaderText = "Họ và tên";
            if (mem_new != null) mem_new.HeaderText = "Số điện thoại";
            if (mem_loss != null) mem_loss.HeaderText = "Email";
            if (mem_age != null) mem_age.HeaderText = "Tuổi";
            if (mem_package_days != null) mem_package_days.HeaderText = "Thời hạn gói (ngày)";
            if (mem_gender != null) mem_gender.HeaderText = "Giới tính";
            if (mem_date != null) mem_date.HeaderText = "Ngày đăng ký";
        }

        private void ConfigureRevenueDetailMode()
        {
            if (groupBox_revenue != null) groupBox_revenue.Text = "Báo cáo doanh thu theo gói";
            if (lbl_rev_best != null) lbl_rev_best.Text = "Tên gói tập";
            if (lbl_rev_least != null) lbl_rev_least.Text = "Khoảng thời gian bán";
            if (lbl_rev_sold != null) lbl_rev_sold.Text = "Số lượng đã bán";
            if (lbl_rev_amount != null) lbl_rev_amount.Text = "Tổng doanh thu";
            if (lbl_rev_cost != null) lbl_rev_cost.Text = "Tổng chi phí";
            if (lbl_rev_profit != null) lbl_rev_profit.Text = "Lợi nhuận";
            if (lbl_rev_date != null) lbl_rev_date.Text = "Lần bán gần nhất";

            if (rev_best != null) rev_best.HeaderText = "Tên gói tập";
            if (rev_least != null) rev_least.HeaderText = "Khoảng thời gian bán";
            if (rev_sold != null) rev_sold.HeaderText = "Số lượng bán";
            if (rev_amount != null) rev_amount.HeaderText = "Tổng doanh thu";
            if (rev_cost != null) rev_cost.HeaderText = "Tổng chi phí";
            if (rev_profit != null) rev_profit.HeaderText = "Lợi nhuận";
            if (rev_date != null) rev_date.HeaderText = "Lần bán gần nhất";
        }

        private void SetupInvoiceGrid()
        {
            dgv_invoice = new DataGridView();
            dgv_invoice.Name = "dgv_invoice";
            dgv_invoice.Dock = DockStyle.Fill;
            dgv_invoice.AllowUserToAddRows = false;
            dgv_invoice.AllowUserToDeleteRows = false;
            dgv_invoice.ReadOnly = true;
            dgv_invoice.MultiSelect = false;
            dgv_invoice.RowHeadersVisible = false;
            dgv_invoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_invoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_invoice.Visible = false;

            dgv_invoice.Columns.Add("inv_receipt_id", "Mã hóa đơn");
            dgv_invoice.Columns.Add("inv_member", "Hội viên");
            dgv_invoice.Columns.Add("inv_package", "Gói tập");
            dgv_invoice.Columns.Add("inv_amount", "Thành tiền");
            dgv_invoice.Columns.Add("inv_method", "Phương thức");
            dgv_invoice.Columns.Add("inv_date", "Ngày thanh toán");
            dgv_invoice.CellClick += dgv_invoice_CellClick;

            panel_grid_host.Controls.Add(dgv_invoice);
            dgv_invoice.BringToFront();
        }

        private void SetupInvoiceInfoGroup()
        {
            groupBox_invoice = new GroupBox();
            groupBox_invoice.Name = "groupBox_invoice";
            groupBox_invoice.Text = "Báo cáo hóa đơn (Receipt)";
            groupBox_invoice.Font = groupBox_revenue.Font;
            groupBox_invoice.Dock = DockStyle.Fill;
            groupBox_invoice.Visible = false;

            txt_inv_receipt_id = new TextBox { ReadOnly = true, Font = new Font("Segoe UI", 10F), Location = new Point(220, 24), Size = new Size(420, 27) };
            txt_inv_member = new TextBox { ReadOnly = true, Font = new Font("Segoe UI", 10F), Location = new Point(220, 52), Size = new Size(420, 27) };
            txt_inv_package = new TextBox { ReadOnly = true, Font = new Font("Segoe UI", 10F), Location = new Point(220, 80), Size = new Size(420, 27) };
            txt_inv_amount = new TextBox { ReadOnly = true, Font = new Font("Segoe UI", 10F), Location = new Point(220, 108), Size = new Size(420, 27) };
            txt_inv_method = new TextBox { ReadOnly = true, Font = new Font("Segoe UI", 10F), Location = new Point(220, 136), Size = new Size(420, 27) };
            dtp_inv_date = new DateTimePicker { Enabled = false, Font = new Font("Segoe UI", 10F), Format = DateTimePickerFormat.Short, Location = new Point(220, 164), Size = new Size(420, 27) };

            groupBox_invoice.Controls.Add(new Label { Text = "Mã hóa đơn", AutoSize = true, Font = new Font("Segoe UI", 10F), Location = new Point(24, 28) });
            groupBox_invoice.Controls.Add(new Label { Text = "Hội viên", AutoSize = true, Font = new Font("Segoe UI", 10F), Location = new Point(24, 56) });
            groupBox_invoice.Controls.Add(new Label { Text = "Gói tập", AutoSize = true, Font = new Font("Segoe UI", 10F), Location = new Point(24, 84) });
            groupBox_invoice.Controls.Add(new Label { Text = "Thành tiền", AutoSize = true, Font = new Font("Segoe UI", 10F), Location = new Point(24, 112) });
            groupBox_invoice.Controls.Add(new Label { Text = "Phương thức", AutoSize = true, Font = new Font("Segoe UI", 10F), Location = new Point(24, 140) });
            groupBox_invoice.Controls.Add(new Label { Text = "Ngày thanh toán", AutoSize = true, Font = new Font("Segoe UI", 10F), Location = new Point(24, 168) });
            groupBox_invoice.Controls.Add(txt_inv_receipt_id);
            groupBox_invoice.Controls.Add(txt_inv_member);
            groupBox_invoice.Controls.Add(txt_inv_package);
            groupBox_invoice.Controls.Add(txt_inv_amount);
            groupBox_invoice.Controls.Add(txt_inv_method);
            groupBox_invoice.Controls.Add(dtp_inv_date);

            panel_info_body.Controls.Add(groupBox_invoice);
        }

        private void SetDetailSectionReadOnly()
        {
            txt_mem_total.ReadOnly = true;
            txt_mem_new.ReadOnly = true;
            txt_mem_loss.ReadOnly = true;
            txt_mem_avg_age.ReadOnly = true;
            rdo_mem_nam.Enabled = false;
            rdo_mem_nu.Enabled = false;
            dtp_mem_date.Enabled = false;

            txt_rev_best.ReadOnly = true;
            txt_rev_least.ReadOnly = true;
            txt_rev_sold.ReadOnly = true;
            txt_rev_amount.ReadOnly = true;
            txt_rev_cost.ReadOnly = true;
            txt_rev_profit.ReadOnly = true;
            dtp_rev_date.Enabled = false;
        }

        private void ApplyReportTypeUi()
        {
            bool member = cbo_report_type.SelectedIndex == KindMember;
            bool revenue = cbo_report_type.SelectedIndex == KindRevenue;
            bool invoice = cbo_report_type.SelectedIndex == KindInvoice;

            dgv_member.Visible = member;
            dgv_revenue.Visible = revenue;
            if (dgv_invoice != null) dgv_invoice.Visible = invoice;
            groupBox_member.Visible = member;
            groupBox_revenue.Visible = revenue;
            if (groupBox_invoice != null) groupBox_invoice.Visible = invoice;
            if (member)
                groupBox_member.BringToFront();
            else if (revenue)
                groupBox_revenue.BringToFront();
            else if (invoice && groupBox_invoice != null)
                groupBox_invoice.BringToFront();

            bool allowYearlyAggregate = member || revenue || invoice;
            if (chk_yearly_aggregate != null)
            {
                chk_yearly_aggregate.Visible = allowYearlyAggregate;
                if (!allowYearlyAggregate) chk_yearly_aggregate.Checked = false;
            }
            if (lbl_keyword != null) lbl_keyword.Text = invoice ? "Mã/Phương thức:" : "Từ khóa:";
            if (lbl_invoice_member_keyword != null)
            {
                lbl_invoice_member_keyword.Visible = invoice;
                lbl_invoice_member_keyword.Location = new Point(17, 197);
            }
            if (txt_invoice_member_keyword != null)
            {
                txt_invoice_member_keyword.Visible = invoice;
                txt_invoice_member_keyword.Location = new Point(147, 194);
            }
            if (lbl_invoice_package_keyword != null)
            {
                lbl_invoice_package_keyword.Visible = invoice;
                lbl_invoice_package_keyword.Location = new Point(17, 229);
            }
            if (txt_invoice_package_keyword != null)
            {
                txt_invoice_package_keyword.Visible = invoice;
                txt_invoice_package_keyword.Location = new Point(147, 226);
            }
            if (lbl_chart_mode != null) lbl_chart_mode.Location = invoice ? new Point(17, 261) : new Point(17, 205);
            if (cbo_chart_mode != null) cbo_chart_mode.Location = invoice ? new Point(147, 258) : new Point(147, 202);
            ApplyTimeFilterUiState();

        }

        private async void cbo_report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_report_type.SelectedIndex < 0) return;
            ApplyReportTypeUi();
            if (isInitializingReportForm) return;
            await ReloadFromFilterAsync();
        }

        private void tabCtrl_find_info_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void btn_find_Click(object sender, EventArgs e)
        {
            await ReloadFromFilterAsync();
        }

        private async void btn_refresh_Click(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            dtp_from.Value = new DateTime(today.Year, today.Month, 1);
            dtp_to.Value = new DateTime(today.Year, 1, 1);
            if (chk_yearly_aggregate != null) chk_yearly_aggregate.Checked = false;
            if (txt_keyword != null) txt_keyword.Clear();
            if (txt_invoice_member_keyword != null) txt_invoice_member_keyword.Clear();
            if (txt_invoice_package_keyword != null) txt_invoice_package_keyword.Clear();
            await ReloadFromFilterAsync();
        }

        private DateTime GetFilterFrom()
        {
            if (dtp_from == null || dtp_to == null) return DateTime.Today;
            int month = dtp_from.Value.Month;
            int year = Math.Min(dtp_to.Value.Year, DateTime.Today.Year);
            if (IsYearlyAggregateEnabled()) return new DateTime(year, 1, 1);
            return new DateTime(year, month, 1);
        }

        private DateTime GetFilterTo()
        {
            DateTime from = GetFilterFrom();
            if (IsYearlyAggregateEnabled()) return from.AddYears(1).AddDays(-1);
            return from.AddMonths(1).AddDays(-1);
        }

        private bool IsYearlyAggregateEnabled()
        {
            if (chk_yearly_aggregate == null || !chk_yearly_aggregate.Checked) return false;
            return cbo_report_type != null && (cbo_report_type.SelectedIndex == KindMember || cbo_report_type.SelectedIndex == KindRevenue || cbo_report_type.SelectedIndex == KindInvoice);
        }

        private void ApplyTimeFilterUiState()
        {
            bool aggregateByYear = IsYearlyAggregateEnabled();
            if (dtp_from != null) dtp_from.Enabled = !aggregateByYear;
            if (lbl_from != null) lbl_from.Enabled = !aggregateByYear;
        }

        private async Task ReloadFromFilterAsync()
        {
            if (!CanRunReportLogic()) return;
            if (dtp_to != null && dtp_to.Value.Year > DateTime.Today.Year)
                dtp_to.Value = DateTime.Today;
            int requestVersion = Interlocked.Increment(ref reloadRequestVersion);
            DateTime from = GetFilterFrom();
            DateTime toExclusive = GetFilterTo().AddDays(1);
            string keyword = (txt_keyword == null ? string.Empty : txt_keyword.Text.Trim());
            string likeKeyword = "%" + keyword + "%";
            string invoiceMemberKeyword = (txt_invoice_member_keyword == null ? string.Empty : txt_invoice_member_keyword.Text.Trim());
            string invoicePackageKeyword = (txt_invoice_package_keyword == null ? string.Empty : txt_invoice_package_keyword.Text.Trim());
            string likeInvoiceMemberKeyword = "%" + invoiceMemberKeyword + "%";
            string likeInvoicePackageKeyword = "%" + invoicePackageKeyword + "%";

            if (cbo_report_type.SelectedIndex == KindMember)
            {
                var cmd = new SqlCommand(
                    "SELECT m.member_id, m.member_name, m.phone_number, m.email, m.age, " +
                    "ISNULL(last_pkg.package_duration_days, 0) AS package_duration_days, m.gender, m.register_date " +
                    "FROM dbo.Member m " +
                    "OUTER APPLY ( " +
                    "    SELECT TOP 1 p.duration * 30 AS package_duration_days " +
                    "    FROM dbo.Receipt r " +
                    "    INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                    "    WHERE r.member_id = m.member_id " +
                    "    ORDER BY r.payment_date DESC " +
                    ") last_pkg " +
                    "WHERE m.register_date >= @from AND m.register_date < @toExclusive " +
                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), m.member_id) LIKE @kwLike " +
                    "OR m.member_name LIKE @kwLike OR m.phone_number LIKE @kwLike OR m.email LIKE @kwLike) " +
                    "ORDER BY m.register_date DESC, m.member_name ASC");
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                cmd.Parameters.AddWithValue("@kw", keyword);
                cmd.Parameters.AddWithValue("@kwLike", likeKeyword);
                await LoadMemberGridAsync(cmd);
            }
            else if (cbo_report_type.SelectedIndex == KindRevenue)
            {
                var cmd = new SqlCommand(
                    "SELECT p.package_id AS report_id, p.package_name, COUNT(r.receipt_id) AS total_package_sold, " +
                    "ISNULL(SUM(r.total_amount), 0) AS total_amount, MIN(r.payment_date) AS first_sale_date, MAX(r.payment_date) AS last_sale_date " +
                    "FROM dbo.Package p " +
                    "LEFT JOIN dbo.Receipt r ON r.package_id = p.package_id " +
                    "AND r.payment_date >= @from AND r.payment_date < @toExclusive " +
                    "WHERE (@kw = '' OR CONVERT(NVARCHAR(36), p.package_id) LIKE @kwLike OR p.package_name LIKE @kwLike) " +
                    "GROUP BY p.package_id, p.package_name " +
                    "ORDER BY total_package_sold DESC, p.package_name ASC");
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                cmd.Parameters.AddWithValue("@kw", keyword);
                cmd.Parameters.AddWithValue("@kwLike", likeKeyword);
                await LoadRevenueGridAsync(cmd);
            }
            else
            {
                var cmd = new SqlCommand(
                    "SELECT r.receipt_id, m.member_name, p.package_name, r.total_amount, pm.method_name, r.payment_date " +
                    "FROM dbo.Receipt r " +
                    "INNER JOIN dbo.Member m ON m.member_id = r.member_id " +
                    "INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                    "INNER JOIN dbo.PaymentMethod pm ON pm.method_id = r.payment_method " +
                    "WHERE r.payment_date >= @from AND r.payment_date < @toExclusive " +
                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), r.receipt_id) LIKE @kwLike OR pm.method_name LIKE @kwLike) " +
                    "AND (@memberKw = '' OR m.member_name LIKE @memberKwLike) " +
                    "AND (@packageKw = '' OR p.package_name LIKE @packageKwLike) " +
                    "ORDER BY r.payment_date DESC");
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                cmd.Parameters.AddWithValue("@kw", keyword);
                cmd.Parameters.AddWithValue("@kwLike", likeKeyword);
                cmd.Parameters.AddWithValue("@memberKw", invoiceMemberKeyword);
                cmd.Parameters.AddWithValue("@memberKwLike", likeInvoiceMemberKeyword);
                cmd.Parameters.AddWithValue("@packageKw", invoicePackageKeyword);
                cmd.Parameters.AddWithValue("@packageKwLike", likeInvoicePackageKeyword);
                await LoadInvoiceGridAsync(cmd);
            }

            if (requestVersion != reloadRequestVersion) return;
            await RefreshChartAsync();
            if (requestVersion != reloadRequestVersion) return;
            UpdateSummary();
        }

        private async Task LoadMemberGridAsync(SqlCommand cmd)
        {
            dgv_member.Rows.Clear();
            try
            {
                using (var conn = GymManagementSystemContext.Connect())
                {
                    cmd.Connection = conn;
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        int ordId = reader.GetOrdinal("member_id");
                        int ordName = reader.GetOrdinal("member_name");
                        int ordPhone = reader.GetOrdinal("phone_number");
                        int ordEmail = reader.GetOrdinal("email");
                        int ordAge = reader.GetOrdinal("age");
                        int ordPackageDays = reader.GetOrdinal("package_duration_days");
                        int ordGender = reader.GetOrdinal("gender");
                        int ordDate = reader.GetOrdinal("register_date");

                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetGuid(ordId);
                            int rowIndex = dgv_member.Rows.Add();
                            var row = dgv_member.Rows[rowIndex];
                            row.Cells["mem_report_id"].Value = id.ToString();
                            row.Cells["mem_total"].Value = reader.GetString(ordName);
                            row.Cells["mem_new"].Value = reader.IsDBNull(ordPhone) ? string.Empty : reader.GetString(ordPhone);
                            row.Cells["mem_loss"].Value = reader.IsDBNull(ordEmail) ? string.Empty : reader.GetString(ordEmail);
                            row.Cells["mem_age"].Value = reader.GetInt32(ordAge);
                            row.Cells["mem_package_days"].Value = reader.IsDBNull(ordPackageDays) ? 0 : reader.GetInt32(ordPackageDays);
                            bool g = !reader.IsDBNull(ordGender) && reader.GetBoolean(ordGender);
                            row.Cells["mem_gender"].Value = g ? "Nam" : "Nữ";
                            row.Cells["mem_date"].Value = reader.GetDateTime(ordDate).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            row.Tag = id;
                        }
                    }
                }
                dgv_member.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo hội viên.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRevenueGridAsync(SqlCommand cmd)
        {
            dgv_revenue.Rows.Clear();
            try
            {
                using (var conn = GymManagementSystemContext.Connect())
                {
                    cmd.Connection = conn;
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        int ordId = reader.GetOrdinal("report_id");
                        int ordPackage = reader.GetOrdinal("package_name");
                        int ordSold = reader.GetOrdinal("total_package_sold");
                        int ordAmt = reader.GetOrdinal("total_amount");
                        int ordFirstSale = reader.GetOrdinal("first_sale_date");
                        int ordLastSale = reader.GetOrdinal("last_sale_date");

                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetGuid(ordId);
                            int rowIndex = dgv_revenue.Rows.Add();
                            var row = dgv_revenue.Rows[rowIndex];
                            row.Cells["rev_report_id"].Value = id.ToString();
                            row.Cells["rev_best"].Value = reader.GetString(ordPackage);
                            int sold = reader.GetInt32(ordSold);
                            long amount = Convert.ToInt64(reader.GetValue(ordAmt), CultureInfo.InvariantCulture);
                            DateTime? firstSale = reader.IsDBNull(ordFirstSale) ? (DateTime?)null : reader.GetDateTime(ordFirstSale);
                            DateTime? lastSale = reader.IsDBNull(ordLastSale) ? (DateTime?)null : reader.GetDateTime(ordLastSale);
                            row.Cells["rev_least"].Value = (firstSale.HasValue && lastSale.HasValue)
                                ? firstSale.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " - " + lastSale.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                                : "-";
                            row.Cells["rev_sold"].Value = sold;
                            row.Cells["rev_amount"].Value = amount.ToString("N0", CultureInfo.InvariantCulture);
                            row.Cells["rev_cost"].Value = "0";
                            row.Cells["rev_profit"].Value = amount.ToString("N0", CultureInfo.InvariantCulture);
                            row.Cells["rev_date"].Value = lastSale.HasValue ? lastSale.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : "-";
                            row.Tag = id;
                        }
                    }
                }
                dgv_revenue.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo doanh thu.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadInvoiceGridAsync(SqlCommand cmd)
        {
            if (dgv_invoice == null) return;
            dgv_invoice.Rows.Clear();
            try
            {
                using (var conn = GymManagementSystemContext.Connect())
                {
                    cmd.Connection = conn;
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        int ordId = reader.GetOrdinal("receipt_id");
                        int ordMember = reader.GetOrdinal("member_name");
                        int ordPackage = reader.GetOrdinal("package_name");
                        int ordAmount = reader.GetOrdinal("total_amount");
                        int ordMethod = reader.GetOrdinal("method_name");
                        int ordDate = reader.GetOrdinal("payment_date");

                        while (await reader.ReadAsync())
                        {
                            int rowIndex = dgv_invoice.Rows.Add();
                            var row = dgv_invoice.Rows[rowIndex];
                            row.Cells["inv_receipt_id"].Value = reader.GetGuid(ordId).ToString();
                            row.Cells["inv_member"].Value = reader.GetString(ordMember);
                            row.Cells["inv_package"].Value = reader.GetString(ordPackage);
                            row.Cells["inv_amount"].Value = reader.GetInt32(ordAmount).ToString("N0", CultureInfo.InvariantCulture);
                            row.Cells["inv_method"].Value = reader.GetString(ordMethod);
                            row.Cells["inv_date"].Value = reader.GetDateTime(ordDate).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                }
                dgv_invoice.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được báo cáo hóa đơn.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RefreshChartAsync()
        {
            if (!CanRunReportLogic() || chart_report == null) return;

            var chartArea = EnsureMainChartArea();
            var legend = EnsureMainLegend();
            chart_report.Series.Clear();
            chart_report.Titles.Clear();
            chart_report.Annotations.Clear();
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.IsStaggered = false;
            chartArea.AxisX.LabelStyle.Angle = 0;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY2.Enabled = AxisEnabled.False;
            chartArea.AxisY2.Title = string.Empty;

            DateTime from = GetFilterFrom();
            DateTime toExclusive = GetFilterTo().AddDays(1);
            string keyword = (txt_keyword == null ? string.Empty : txt_keyword.Text.Trim());
            string likeKeyword = "%" + keyword + "%";
            string invoiceMemberKeyword = (txt_invoice_member_keyword == null ? string.Empty : txt_invoice_member_keyword.Text.Trim());
            string invoicePackageKeyword = (txt_invoice_package_keyword == null ? string.Empty : txt_invoice_package_keyword.Text.Trim());
            string likeInvoiceMemberKeyword = "%" + invoiceMemberKeyword + "%";
            string likeInvoicePackageKeyword = "%" + invoicePackageKeyword + "%";

            try
            {
                int totalPoints = 0;
                using (var conn = GymManagementSystemContext.Connect())
                {
                    await conn.OpenAsync();
                    if (cbo_report_type.SelectedIndex == KindMember)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            bool aggregateByYear = IsYearlyAggregateEnabled();
                            if (aggregateByYear)
                            {
                                cmd.CommandText =
                                    "SELECT DATEPART(MONTH, m.register_date) AS report_month, COUNT(*) AS total_member " +
                                    "FROM dbo.Member m " +
                                    "WHERE m.register_date >= @from AND m.register_date < @toExclusive " +
                                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), m.member_id) LIKE @kwLike " +
                                    "OR m.member_name LIKE @kwLike OR m.phone_number LIKE @kwLike OR m.email LIKE @kwLike) " +
                                    "GROUP BY DATEPART(MONTH, m.register_date) " +
                                    "ORDER BY DATEPART(MONTH, m.register_date)";
                            }
                            else
                            {
                                cmd.CommandText =
                                    "SELECT CAST(m.register_date AS DATE) AS report_date, COUNT(*) AS total_member " +
                                    "FROM dbo.Member m " +
                                    "WHERE m.register_date >= @from AND m.register_date < @toExclusive " +
                                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), m.member_id) LIKE @kwLike " +
                                    "OR m.member_name LIKE @kwLike OR m.phone_number LIKE @kwLike OR m.email LIKE @kwLike) " +
                                    "GROUP BY CAST(m.register_date AS DATE) " +
                                    "ORDER BY CAST(m.register_date AS DATE)";
                            }
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                            cmd.Parameters.AddWithValue("@kw", keyword);
                            cmd.Parameters.AddWithValue("@kwLike", likeKeyword);

                            var chartType = ResolveChartType();
                            var sTotal = new Series("Tổng hội viên") { ChartType = chartType };
                            sTotal.ChartArea = chartArea.Name;
                            sTotal.Legend = legend.Name;

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                while (await r.ReadAsync())
                                {
                                    string axisLabel;
                                    object xValue;
                                    if (aggregateByYear)
                                    {
                                        int monthNumber = r.GetInt32(0);
                                        axisLabel = "Tháng " + monthNumber.ToString(CultureInfo.InvariantCulture);
                                        xValue = axisLabel;
                                    }
                                    else
                                    {
                                        var d = r.GetDateTime(0).Date;
                                        axisLabel = d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        xValue = d;
                                    }

                                    int pTotal = sTotal.Points.AddXY(xValue, r.GetInt32(1));
                                    sTotal.Points[pTotal].AxisLabel = axisLabel;
                                    totalPoints++;
                                }
                            }

                            chart_report.Series.Add(sTotal);
                        }
                    }
                    else if (cbo_report_type.SelectedIndex == KindRevenue)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            bool aggregateByYear = IsYearlyAggregateEnabled();
                            if (aggregateByYear)
                            {
                                cmd.CommandText =
                                    "SELECT DATEPART(MONTH, r.payment_date) AS report_month, COUNT(*) AS sold_count, ISNULL(SUM(r.total_amount), 0) AS total_amount " +
                                    "FROM dbo.Receipt r " +
                                    "INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                                    "WHERE r.payment_date >= @from AND r.payment_date < @toExclusive " +
                                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), p.package_id) LIKE @kwLike OR p.package_name LIKE @kwLike) " +
                                    "GROUP BY DATEPART(MONTH, r.payment_date) " +
                                    "ORDER BY DATEPART(MONTH, r.payment_date)";
                            }
                            else
                            {
                                cmd.CommandText =
                                    "SELECT CAST(r.payment_date AS DATE) AS report_date, COUNT(*) AS sold_count, ISNULL(SUM(r.total_amount), 0) AS total_amount " +
                                    "FROM dbo.Receipt r " +
                                    "INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                                    "WHERE r.payment_date >= @from AND r.payment_date < @toExclusive " +
                                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), p.package_id) LIKE @kwLike OR p.package_name LIKE @kwLike) " +
                                    "GROUP BY CAST(r.payment_date AS DATE) " +
                                    "ORDER BY CAST(r.payment_date AS DATE)";
                            }
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                            cmd.Parameters.AddWithValue("@kw", keyword);
                            cmd.Parameters.AddWithValue("@kwLike", likeKeyword);

                            var chartType = ResolveChartType();
                            var sSold = new Series("Số lượng bán") { ChartType = chartType, YAxisType = AxisType.Secondary };
                            var sAmount = new Series("Tổng doanh thu") { ChartType = chartType };
                            sAmount.ChartArea = chartArea.Name;
                            sSold.ChartArea = chartArea.Name;
                            sAmount.Legend = legend.Name;
                            sSold.Legend = legend.Name;

                            sAmount.IsValueShownAsLabel = true;
                            sSold.IsValueShownAsLabel = true;
                            sAmount.SmartLabelStyle.Enabled = true;
                            sSold.SmartLabelStyle.Enabled = true;

                            sAmount["PointWidth"] = "0.8";
                            sSold["PointWidth"] = "0.8";
                            sAmount["DrawingStyle"] = "Default";
                            sSold["DrawingStyle"] = "Default";

                            sAmount.ToolTip = "Doanh thu - #VALX: #VALY{N0} VNĐ";
                            sSold.ToolTip = "Số lượng bán - #VALX: #VALY{N0}";

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                while (await r.ReadAsync())
                                {
                                    string axisLabel;
                                    object xValue;
                                    if (aggregateByYear)
                                    {
                                        int monthNumber = r.GetInt32(0);
                                        axisLabel = "Tháng " + monthNumber.ToString(CultureInfo.InvariantCulture);
                                        xValue = axisLabel;
                                    }
                                    else
                                    {
                                        DateTime reportDate = r.GetDateTime(0).Date;
                                        axisLabel = reportDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        xValue = reportDate;
                                    }
                                    int soldCount = r.GetInt32(1);
                                    double totalAmount = Convert.ToDouble(r.GetValue(2), CultureInfo.InvariantCulture);
                                    if (soldCount <= 0)
                                    {
                                        // Không đưa gói chưa bán lên biểu đồ doanh thu.
                                        continue;
                                    }

                                    int pAmount = sAmount.Points.AddXY(xValue, totalAmount);
                                    int pSold = sSold.Points.AddXY(xValue, soldCount);
                                    sAmount.Points[pAmount].AxisLabel = axisLabel;
                                    sSold.Points[pSold].AxisLabel = axisLabel;
                                    sAmount.Points[pAmount].Label = FormatCompactValue(totalAmount);
                                    sSold.Points[pSold].Label = soldCount.ToString(CultureInfo.InvariantCulture);
                                    totalPoints++;
                                }
                            }

                            chartArea.AxisY2.Enabled = AxisEnabled.True;
                            chartArea.AxisY2.Title = "Số lượng bán";
                            chartArea.AxisY2.LabelStyle.Format = "N0";
                            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                            chartArea.AxisX.LabelStyle.Angle = totalPoints > 8 ? -35 : 0;

                            chart_report.Series.Add(sAmount);
                            chart_report.Series.Add(sSold);
                        }
                    }
                    else
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            bool aggregateByYear = IsYearlyAggregateEnabled();
                            if (aggregateByYear)
                            {
                                cmd.CommandText =
                                    "SELECT DATEPART(MONTH, r.payment_date) AS report_month, COUNT(*) AS invoice_count, SUM(r.total_amount) AS total_amount " +
                                    "FROM dbo.Receipt r " +
                                    "INNER JOIN dbo.Member m ON m.member_id = r.member_id " +
                                    "INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                                    "INNER JOIN dbo.PaymentMethod pm ON pm.method_id = r.payment_method " +
                                    "WHERE r.payment_date >= @from AND r.payment_date < @toExclusive " +
                                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), r.receipt_id) LIKE @kwLike OR pm.method_name LIKE @kwLike) " +
                                    "AND (@memberKw = '' OR m.member_name LIKE @memberKwLike) " +
                                    "AND (@packageKw = '' OR p.package_name LIKE @packageKwLike) " +
                                    "GROUP BY DATEPART(MONTH, r.payment_date) " +
                                    "ORDER BY DATEPART(MONTH, r.payment_date)";
                            }
                            else
                            {
                                cmd.CommandText =
                                    "SELECT r.payment_date, COUNT(*) AS invoice_count, SUM(r.total_amount) AS total_amount " +
                                    "FROM dbo.Receipt r " +
                                    "INNER JOIN dbo.Member m ON m.member_id = r.member_id " +
                                    "INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                                    "INNER JOIN dbo.PaymentMethod pm ON pm.method_id = r.payment_method " +
                                    "WHERE r.payment_date >= @from AND r.payment_date < @toExclusive " +
                                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), r.receipt_id) LIKE @kwLike OR pm.method_name LIKE @kwLike) " +
                                    "AND (@memberKw = '' OR m.member_name LIKE @memberKwLike) " +
                                    "AND (@packageKw = '' OR p.package_name LIKE @packageKwLike) " +
                                    "GROUP BY r.payment_date " +
                                    "ORDER BY r.payment_date";
                            }
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                            cmd.Parameters.AddWithValue("@kw", keyword);
                            cmd.Parameters.AddWithValue("@kwLike", likeKeyword);
                            cmd.Parameters.AddWithValue("@memberKw", invoiceMemberKeyword);
                            cmd.Parameters.AddWithValue("@memberKwLike", likeInvoiceMemberKeyword);
                            cmd.Parameters.AddWithValue("@packageKw", invoicePackageKeyword);
                            cmd.Parameters.AddWithValue("@packageKwLike", likeInvoicePackageKeyword);

                            var chartType = ResolveChartType();
                            var sCount = new Series("Số hóa đơn") { ChartType = chartType, YAxisType = AxisType.Secondary };
                            var sAmount = new Series("Tổng tiền") { ChartType = chartType };
                            sCount.ChartArea = chartArea.Name;
                            sAmount.ChartArea = chartArea.Name;
                            sCount.Legend = legend.Name;
                            sAmount.Legend = legend.Name;

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                while (await r.ReadAsync())
                                {
                                    string axisLabel;
                                    object xValue;
                                    if (aggregateByYear)
                                    {
                                        int monthNumber = r.GetInt32(0);
                                        axisLabel = "Tháng " + monthNumber.ToString(CultureInfo.InvariantCulture);
                                        xValue = axisLabel;
                                    }
                                    else
                                    {
                                        var d = r.GetDateTime(0).Date;
                                        axisLabel = d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        xValue = d;
                                    }
                                    int count = r.GetInt32(1);
                                    double amount = Convert.ToDouble(r.GetValue(2), CultureInfo.InvariantCulture);
                                    int pCount = sCount.Points.AddXY(xValue, count);
                                    int pAmount = sAmount.Points.AddXY(xValue, amount);
                                    sCount.Points[pCount].AxisLabel = axisLabel;
                                    sAmount.Points[pAmount].AxisLabel = axisLabel;
                                    totalPoints++;
                                }
                            }

                            chart_report.Series.Add(sCount);
                            chart_report.Series.Add(sAmount);
                            chartArea.AxisY2.Enabled = AxisEnabled.True;
                            chartArea.AxisY2.Title = "Số hóa đơn";
                            chartArea.AxisY2.LabelStyle.Format = "N0";
                        }
                    }
                }

                chartArea.AxisX.Title = IsYearlyAggregateEnabled() ? "Tháng" : "Ngày báo cáo";
                chartArea.AxisY.Title = cbo_report_type.SelectedIndex == KindMember ? "Số lượng" : "VNĐ";
                chartArea.AxisY.LabelStyle.Format = "N0";
                legend.Enabled = chart_report.Series.Count > 0;
                chartArea.AxisX.Interval = totalPoints > 40 ? 4 : totalPoints > 20 ? 2 : 1;

                if (totalPoints == 0)
                {
                    var noData = new Title("Không có dữ liệu phù hợp bộ lọc hiện tại");
                    noData.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
                    noData.ForeColor = Color.DimGray;
                    chart_report.Titles.Add(noData);
                }
            }
            catch (Exception ex)
            {
                // Biểu đồ phụ — không chặn thao tác chính
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private SeriesChartType ResolveChartType()
        {
            if (cbo_chart_mode == null) return SeriesChartType.Column;
            if (cbo_chart_mode.SelectedIndex == ChartModeColumn) return SeriesChartType.Column;
            if (cbo_chart_mode.SelectedIndex == ChartModeLine) return SeriesChartType.Line;
            return SeriesChartType.Column;
        }

        private ChartArea EnsureMainChartArea()
        {
            if (chart_report.ChartAreas.Count == 0)
            {
                chart_report.ChartAreas.Add(new ChartArea(MainChartAreaName));
            }

            var area = chart_report.ChartAreas.FindByName(MainChartAreaName) ?? chart_report.ChartAreas[0];
            if (string.IsNullOrWhiteSpace(area.Name))
            {
                area.Name = MainChartAreaName;
            }

            return area;
        }

        private Legend EnsureMainLegend()
        {
            if (chart_report.Legends.Count == 0)
            {
                chart_report.Legends.Add(new Legend(MainLegendName));
            }

            var legend = chart_report.Legends.FindByName(MainLegendName) ?? chart_report.Legends[0];
            if (string.IsNullOrWhiteSpace(legend.Name))
            {
                legend.Name = MainLegendName;
            }

            return legend;
        }

        private bool CanRunReportLogic()
        {
            if (IsDisposed || Disposing) return false;
            if (cbo_report_type == null || dtp_from == null || dtp_to == null) return false;
            if (dgv_member == null || dgv_revenue == null || chart_report == null) return false;
            return true;
        }

        private void UpdateSummary()
        {
            if (!CanRunReportLogic() || lbl_toolbar_summary == null) return;

            DateTime from = GetFilterFrom();
            string period = from.ToString("MM/yyyy", CultureInfo.InvariantCulture);
            if (IsYearlyAggregateEnabled())
                period = "Năm " + from.ToString("yyyy", CultureInfo.InvariantCulture);

            if (cbo_report_type.SelectedIndex == KindMember)
            {
                int rows = dgv_member.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                int totalPackageDays = 0;
                foreach (DataGridViewRow row in dgv_member.Rows)
                {
                    if (row.IsNewRow) continue;
                    totalPackageDays += ConvertToInt(row.Cells["mem_package_days"].Value);
                }
                lbl_toolbar_summary.Text = "Kỳ: " + period + " | Tổng hội viên: " + rows.ToString("N0", CultureInfo.InvariantCulture) + " | Tổng thời hạn gói: " + totalPackageDays.ToString("N0", CultureInfo.InvariantCulture) + " ngày";
            }
            else if (cbo_report_type.SelectedIndex == KindRevenue)
            {
                int rows = dgv_revenue.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                long totalRevenue = 0;
                int totalSold = 0;
                foreach (DataGridViewRow row in dgv_revenue.Rows)
                {
                    if (row.IsNewRow) continue;
                    totalSold += ConvertToInt(row.Cells["rev_sold"].Value);
                    totalRevenue += ConvertToInt(row.Cells["rev_amount"].Value);
                }
                lbl_toolbar_summary.Text = "Kỳ: " + period + " | Tổng gói trong kỳ: " + rows.ToString("N0", CultureInfo.InvariantCulture) + " | Tổng lượt bán: " + totalSold.ToString("N0", CultureInfo.InvariantCulture) + " | Tổng doanh thu: " + totalRevenue.ToString("N0", CultureInfo.InvariantCulture) + " VNĐ";
            }
            else
            {
                int rows = dgv_invoice == null ? 0 : dgv_invoice.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                long totalAmount = 0;
                if (dgv_invoice != null)
                {
                    foreach (DataGridViewRow row in dgv_invoice.Rows)
                    {
                        if (row.IsNewRow) continue;
                        totalAmount += ConvertToInt(row.Cells["inv_amount"].Value);
                    }
                }
                lbl_toolbar_summary.Text = "Kỳ: " + period + " | " + rows + " hóa đơn | Tổng thanh toán: " + totalAmount.ToString("N0", CultureInfo.InvariantCulture) + " VNĐ";
            }
        }

        private static int ConvertToInt(object value)
        {
            if (value == null) return 0;
            int parsed;
            return int.TryParse(value.ToString().Trim().Replace(".", "").Replace(",", ""), NumberStyles.Integer, CultureInfo.InvariantCulture, out parsed) ? parsed : 0;
        }

        private static string FormatCompactValue(double value)
        {
            double abs = Math.Abs(value);
            if (abs >= 1000000000d) return (value / 1000000000d).ToString("0.#", CultureInfo.InvariantCulture) + "B";
            if (abs >= 1000000d) return (value / 1000000d).ToString("0.#", CultureInfo.InvariantCulture) + "M";
            if (abs >= 1000d) return (value / 1000d).ToString("0.#", CultureInfo.InvariantCulture) + "K";
            return value.ToString("0", CultureInfo.InvariantCulture);
        }

        private void dgv_member_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv_member.Rows[e.RowIndex];
            tabCtrl_find_info.SelectedIndex = 1;
            txt_mem_total.Text = row.Cells["mem_total"].Value?.ToString();
            txt_mem_new.Text = row.Cells["mem_new"].Value?.ToString();
            txt_mem_loss.Text = row.Cells["mem_loss"].Value?.ToString();
            txt_mem_avg_age.Text = row.Cells["mem_age"].Value?.ToString();
            string g = row.Cells["mem_gender"].Value?.ToString();
            rdo_mem_nam.Checked = g == "Nam";
            rdo_mem_nu.Checked = g == "Nữ";
            if (DateTime.TryParseExact(row.Cells["mem_date"].Value?.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                dtp_mem_date.Value = dt;
        }

        private void dgv_revenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv_revenue.Rows[e.RowIndex];
            tabCtrl_find_info.SelectedIndex = 1;
            txt_rev_best.Text = row.Cells["rev_best"].Value?.ToString();
            txt_rev_least.Text = row.Cells["rev_least"].Value?.ToString();
            txt_rev_sold.Text = row.Cells["rev_sold"].Value?.ToString();
            txt_rev_amount.Text = row.Cells["rev_amount"].Value?.ToString()?.Replace(".", "").Replace(",", "");
            txt_rev_cost.Text = row.Cells["rev_cost"].Value?.ToString()?.Replace(".", "").Replace(",", "");
            txt_rev_profit.Text = row.Cells["rev_profit"].Value?.ToString()?.Replace(".", "").Replace(",", "");
            if (DateTime.TryParseExact(row.Cells["rev_date"].Value?.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                dtp_rev_date.Value = dt;
        }

        private void dgv_invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_invoice == null) return;
            var row = dgv_invoice.Rows[e.RowIndex];
            tabCtrl_find_info.SelectedIndex = 1;
            if (txt_inv_receipt_id != null) txt_inv_receipt_id.Text = row.Cells["inv_receipt_id"].Value?.ToString();
            if (txt_inv_member != null) txt_inv_member.Text = row.Cells["inv_member"].Value?.ToString();
            if (txt_inv_package != null) txt_inv_package.Text = row.Cells["inv_package"].Value?.ToString();
            if (txt_inv_amount != null) txt_inv_amount.Text = row.Cells["inv_amount"].Value?.ToString();
            if (txt_inv_method != null) txt_inv_method.Text = row.Cells["inv_method"].Value?.ToString();
            if (dtp_inv_date != null && DateTime.TryParseExact(row.Cells["inv_date"].Value?.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                dtp_inv_date.Value = dt;
        }

        private Guid? GetSelectedReportId()
        {
            if (cbo_report_type.SelectedIndex == KindMember)
            {
                if (dgv_member.CurrentRow == null) return null;
                var row = dgv_member.CurrentRow;
                if (row.Tag is Guid g) return g;
                if (Guid.TryParse(row.Cells["mem_report_id"].Value?.ToString(), out Guid id)) return id;
            }
            else
            {
                if (dgv_revenue.CurrentRow == null) return null;
                var row = dgv_revenue.CurrentRow;
                if (row.Tag is Guid g) return g;
                if (Guid.TryParse(row.Cells["rev_report_id"].Value?.ToString(), out Guid id)) return id;
            }
            return null;
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if (cbo_report_type.SelectedIndex == KindMember)
            {
                if (!TryParseInt(txt_mem_total.Text, out int total) ||
                    !TryParseInt(txt_mem_new.Text, out int nnew) ||
                    !TryParseInt(txt_mem_loss.Text, out int loss) ||
                    !TryParseInt(txt_mem_avg_age.Text, out int age))
                {
                    MessageBox.Show("Vui lòng nhập đủ số liệu hợp lệ (số nguyên).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool commonGender = rdo_mem_nam.Checked;
                Guid id = Guid.NewGuid();
                try
                {
                    using (var conn = GymManagementSystemContext.Connect())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "INSERT INTO dbo.MemberReport (report_id, total_member, monthly_new_member, monthly_loss_member, average_age, common_gender, report_date) " +
                            "VALUES (@id, @total, @nnew, @loss, @age, @gender, @rdate)";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@nnew", nnew);
                        cmd.Parameters.AddWithValue("@loss", loss);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@gender", commonGender);
                        cmd.Parameters.AddWithValue("@rdate", dtp_mem_date.Value.Date);
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Đã thêm báo cáo hội viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = ReloadFromFilterAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string best = txt_rev_best.Text.Trim();
                string least = txt_rev_least.Text.Trim();
                if (string.IsNullOrEmpty(best) || string.IsNullOrEmpty(least))
                {
                    MessageBox.Show("Vui lòng nhập tên gói bán chạy và gói bán ít.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TryParseInt(txt_rev_sold.Text, out int sold) ||
                    !TryParseInt(txt_rev_amount.Text, out int amount) ||
                    !TryParseInt(txt_rev_cost.Text, out int cost) ||
                    !TryParseInt(txt_rev_profit.Text, out int profit))
                {
                    MessageBox.Show("Các trường số phải là số nguyên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Guid id = Guid.NewGuid();
                try
                {
                    using (var conn = GymManagementSystemContext.Connect())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "INSERT INTO dbo.RevenueReport (report_id, best_sell_package, least_sell_package, total_package_sold, total_amount, total_cost, net_profit, report_date) " +
                            "VALUES (@id, @best, @least, @sold, @amount, @cost, @profit, @rdate)";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@best", best);
                        cmd.Parameters.AddWithValue("@least", least);
                        cmd.Parameters.AddWithValue("@sold", sold);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@cost", cost);
                        cmd.Parameters.AddWithValue("@profit", profit);
                        cmd.Parameters.AddWithValue("@rdate", dtp_rev_date.Value.Date);
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Đã thêm báo cáo doanh thu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = ReloadFromFilterAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btn_renew_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedReportId();
            if (!sel.HasValue)
            {
                MessageBox.Show("Chọn một dòng trong bảng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbo_report_type.SelectedIndex == KindMember)
            {
                if (!TryParseInt(txt_mem_total.Text, out int total) ||
                    !TryParseInt(txt_mem_new.Text, out int nnew) ||
                    !TryParseInt(txt_mem_loss.Text, out int loss) ||
                    !TryParseInt(txt_mem_avg_age.Text, out int age))
                {
                    MessageBox.Show("Vui lòng nhập đủ số liệu hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool commonGender = rdo_mem_nam.Checked;
                try
                {
                    using (var conn = GymManagementSystemContext.Connect())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE dbo.MemberReport SET total_member=@total, monthly_new_member=@nnew, monthly_loss_member=@loss, average_age=@age, common_gender=@gender, report_date=@rdate WHERE report_id=@id";
                        cmd.Parameters.AddWithValue("@id", sel.Value);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@nnew", nnew);
                        cmd.Parameters.AddWithValue("@loss", loss);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@gender", commonGender);
                        cmd.Parameters.AddWithValue("@rdate", dtp_mem_date.Value.Date);
                        await conn.OpenAsync();
                        if (await cmd.ExecuteNonQueryAsync() > 0)
                        {
                            MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _ = ReloadFromFilterAsync();
                        }
                        else
                            MessageBox.Show("Không tìm thấy bản ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string best = txt_rev_best.Text.Trim();
                string least = txt_rev_least.Text.Trim();
                if (string.IsNullOrEmpty(best) || string.IsNullOrEmpty(least))
                {
                    MessageBox.Show("Vui lòng nhập tên gói bán chạy và gói bán ít.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TryParseInt(txt_rev_sold.Text, out int sold) ||
                    !TryParseInt(txt_rev_amount.Text, out int amount) ||
                    !TryParseInt(txt_rev_cost.Text, out int cost) ||
                    !TryParseInt(txt_rev_profit.Text, out int profit))
                {
                    MessageBox.Show("Các trường số phải hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    using (var conn = GymManagementSystemContext.Connect())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE dbo.RevenueReport SET best_sell_package=@best, least_sell_package=@least, total_package_sold=@sold, total_amount=@amount, total_cost=@cost, net_profit=@profit, report_date=@rdate WHERE report_id=@id";
                        cmd.Parameters.AddWithValue("@id", sel.Value);
                        cmd.Parameters.AddWithValue("@best", best);
                        cmd.Parameters.AddWithValue("@least", least);
                        cmd.Parameters.AddWithValue("@sold", sold);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@cost", cost);
                        cmd.Parameters.AddWithValue("@profit", profit);
                        cmd.Parameters.AddWithValue("@rdate", dtp_rev_date.Value.Date);
                        await conn.OpenAsync();
                        if (await cmd.ExecuteNonQueryAsync() > 0)
                        {
                            MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _ = ReloadFromFilterAsync();
                        }
                        else
                            MessageBox.Show("Không tìm thấy bản ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btn_del_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedReportId();
            if (!sel.HasValue)
            {
                MessageBox.Show("Chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xóa báo cáo đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (var conn = GymManagementSystemContext.Connect())
                using (var cmd = conn.CreateCommand())
                {
                    if (cbo_report_type.SelectedIndex == KindMember)
                        cmd.CommandText = "DELETE FROM dbo.MemberReport WHERE report_id=@id";
                    else
                        cmd.CommandText = "DELETE FROM dbo.RevenueReport WHERE report_id=@id";
                    cmd.Parameters.AddWithValue("@id", sel.Value);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                MessageBox.Show("Đã xóa.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = ReloadFromFilterAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool TryParseInt(string s, out int v)
        {
            s = (s ?? "").Trim().Replace(".", "").Replace(",", "");
            return int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out v);
        }

        private void txt_keyword_TextChanged(object sender, EventArgs e)
        {
            if (keywordDebounceTimer == null)
            {
                _ = ReloadFromFilterAsync();
                return;
            }

            keywordDebounceTimer.Stop();
            keywordDebounceTimer.Start();
        }

        private async void keywordDebounceTimer_Tick(object sender, EventArgs e)
        {
            keywordDebounceTimer.Stop();
            await ReloadFromFilterAsync();
        }

        private async void cbo_chart_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RefreshChartAsync();
        }

        private async void chk_yearly_aggregate_CheckedChanged(object sender, EventArgs e)
        {
            ApplyTimeFilterUiState();
            await ReloadFromFilterAsync();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel CSV (*.csv)|*.csv|Tất cả (*.*)|*.*";
                if (cbo_report_type.SelectedIndex == KindMember)
                    dlg.FileName = "BaoCaoHoiVien.csv";
                else if (cbo_report_type.SelectedIndex == KindRevenue)
                    dlg.FileName = "BaoCaoDoanhThu.csv";
                else
                    dlg.FileName = "BaoCaoHoaDon.csv";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new StringBuilder();
                    if (cbo_report_type.SelectedIndex == KindMember)
                    {
                        sb.AppendLine(CsvLine("Mã hội viên", "Họ và tên", "Số điện thoại", "Email", "Tuổi", "Giới tính", "Ngày đăng ký"));
                        foreach (DataGridViewRow row in dgv_member.Rows)
                        {
                            if (row.IsNewRow) continue;
                            sb.AppendLine(CsvLine(
                                row.Cells["mem_report_id"].Value?.ToString(),
                                row.Cells["mem_total"].Value?.ToString(),
                                row.Cells["mem_new"].Value?.ToString(),
                                row.Cells["mem_loss"].Value?.ToString(),
                                row.Cells["mem_age"].Value?.ToString(),
                                row.Cells["mem_gender"].Value?.ToString(),
                                row.Cells["mem_date"].Value?.ToString()));
                        }
                    }
                    else if (cbo_report_type.SelectedIndex == KindRevenue)
                    {
                        sb.AppendLine(CsvLine("Mã gói", "Tên gói tập", "Khoảng thời gian bán", "Số lượng bán", "Tổng doanh thu", "Tổng chi phí", "Lợi nhuận", "Lần bán gần nhất"));
                        foreach (DataGridViewRow row in dgv_revenue.Rows)
                        {
                            if (row.IsNewRow) continue;
                            sb.AppendLine(CsvLine(
                                row.Cells["rev_report_id"].Value?.ToString(),
                                row.Cells["rev_best"].Value?.ToString(),
                                row.Cells["rev_least"].Value?.ToString(),
                                row.Cells["rev_sold"].Value?.ToString(),
                                row.Cells["rev_amount"].Value?.ToString(),
                                row.Cells["rev_cost"].Value?.ToString(),
                                row.Cells["rev_profit"].Value?.ToString(),
                                row.Cells["rev_date"].Value?.ToString()));
                        }
                    }
                    else
                    {
                        sb.AppendLine(CsvLine("Mã hóa đơn", "Hội viên", "Gói tập", "Thành tiền", "Phương thức", "Ngày thanh toán"));
                        if (dgv_invoice != null)
                        {
                            foreach (DataGridViewRow row in dgv_invoice.Rows)
                            {
                                if (row.IsNewRow) continue;
                                sb.AppendLine(CsvLine(
                                    row.Cells["inv_receipt_id"].Value?.ToString(),
                                    row.Cells["inv_member"].Value?.ToString(),
                                    row.Cells["inv_package"].Value?.ToString(),
                                    row.Cells["inv_amount"].Value?.ToString(),
                                    row.Cells["inv_method"].Value?.ToString(),
                                    row.Cells["inv_date"].Value?.ToString()));
                            }
                        }
                    }

                    File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                    MessageBox.Show("Đã xuất file.\nMở bằng Excel: dùng \"Dữ liệu\" > \"Từ văn bản/CSV\" nếu cần chọn mã UTF-8.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string CsvLine(params string[] cells)
        {
            var parts = cells.Select(EscapeCsv);
            return string.Join(",", parts);
        }

        private static string EscapeCsv(string s)
        {
            if (s == null) return "\"\"";
            bool needQuote = s.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0;
            string t = s.Replace("\"", "\"\"");
            return needQuote ? "\"" + t + "\"" : t;
        }
    }
}
