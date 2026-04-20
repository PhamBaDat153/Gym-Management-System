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

        private Label lbl_toolbar_summary;
        private Label lbl_keyword;
        private TextBox txt_keyword;
        private Label lbl_chart_mode;
        private ComboBox cbo_chart_mode;
        private System.Windows.Forms.Timer keywordDebounceTimer;
        private int reloadRequestVersion;
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
            SetupFriendlyUi();
            cbo_report_type.Items.Clear();
            cbo_report_type.Items.Add("Báo cáo hội viên (MemberReport)");
            cbo_report_type.Items.Add("Báo cáo doanh thu (RevenueReport)");
            cbo_report_type.Items.Add("Báo cáo hóa đơn (Receipt)");
            cbo_report_type.SelectedIndex = 0;

            var today = DateTime.Today;
            dtp_from.Value = new DateTime(today.Year, today.Month, 1);
            dtp_to.Value = new DateTime(today.Year, 1, 1);

            rdo_mem_nam.Checked = true;
            ApplyReportTypeUi();
            await ReloadFromFilterAsync();
        }

        private void SetupFriendlyUi()
        {
            SetupInvoiceGrid();
            SetupInvoiceInfoGroup();

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
            lbl_keyword.Location = new Point(17, 181);

            txt_keyword = new TextBox();
            txt_keyword.Name = "txt_keyword";
            txt_keyword.Font = new Font("Segoe UI", 10F);
            txt_keyword.Location = new Point(147, 178);
            txt_keyword.Size = new Size(300, 30);
            txt_keyword.TextChanged += txt_keyword_TextChanged;
            keywordDebounceTimer = new System.Windows.Forms.Timer();
            keywordDebounceTimer.Interval = KeywordDebounceMs;
            keywordDebounceTimer.Tick += keywordDebounceTimer_Tick;

            lbl_chart_mode = new Label();
            lbl_chart_mode.Name = "lbl_chart_mode";
            lbl_chart_mode.AutoSize = true;
            lbl_chart_mode.Font = new Font("Segoe UI", 10F);
            lbl_chart_mode.Text = "Biểu đồ:";
            lbl_chart_mode.Location = new Point(17, 223);

            cbo_chart_mode = new ComboBox();
            cbo_chart_mode.Name = "cbo_chart_mode";
            cbo_chart_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_chart_mode.Font = new Font("Segoe UI", 10F);
            cbo_chart_mode.Items.AddRange(new object[] { "Tự động", "Biểu đồ cột", "Biểu đồ đường" });
            cbo_chart_mode.SelectedIndex = ChartModeLine;
            cbo_chart_mode.Location = new Point(147, 220);
            cbo_chart_mode.Size = new Size(300, 30);
            cbo_chart_mode.SelectedIndexChanged += cbo_chart_mode_SelectedIndexChanged;

            tab_search.Controls.Add(lbl_keyword);
            tab_search.Controls.Add(txt_keyword);
            tab_search.Controls.Add(lbl_chart_mode);
            tab_search.Controls.Add(cbo_chart_mode);

            // Màn báo cáo chỉ đọc: ẩn hoàn toàn các thao tác CRUD.
            btn_add.Visible = false;
            btn_renew.Visible = false;
            btn_del.Visible = false;
            panel_btns.Visible = false;
            SetDetailSectionReadOnly();
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

        }

        private async void cbo_report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_report_type.SelectedIndex < 0) return;
            ApplyReportTypeUi();
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
            await ReloadFromFilterAsync();
        }

        private DateTime GetFilterFrom()
        {
            int month = dtp_from.Value.Month;
            int year = dtp_to.Value.Year;
            return new DateTime(year, month, 1);
        }

        private DateTime GetFilterTo()
        {
            DateTime from = GetFilterFrom();
            return from.AddMonths(1).AddDays(-1);
        }

        private async Task ReloadFromFilterAsync()
        {
            int requestVersion = Interlocked.Increment(ref reloadRequestVersion);
            DateTime from = GetFilterFrom();
            DateTime toExclusive = GetFilterTo().AddDays(1);
            string keyword = (txt_keyword == null ? string.Empty : txt_keyword.Text.Trim());
            string likeKeyword = "%" + keyword + "%";

            if (cbo_report_type.SelectedIndex == KindMember)
            {
                var cmd = new SqlCommand(
                    "SELECT member_id, member_name, age, phone_number, email, gender, register_date " +
                    "FROM dbo.Member " +
                    "WHERE register_date >= @from AND register_date < @toExclusive " +
                    "AND (@kw = '' OR member_name LIKE @kwLike OR phone_number LIKE @kwLike OR email LIKE @kwLike) " +
                    "ORDER BY register_date DESC, member_name");
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                cmd.Parameters.AddWithValue("@kw", keyword);
                cmd.Parameters.AddWithValue("@kwLike", likeKeyword);
                await LoadMemberGridAsync(cmd);
            }
            else if (cbo_report_type.SelectedIndex == KindRevenue)
            {
                var cmd = new SqlCommand(
                    "SELECT p.package_id, p.package_name, p.price, p.duration, p.with_trainer, " +
                    "COUNT(r.receipt_id) AS sold_count, ISNULL(SUM(CAST(r.total_amount AS BIGINT)), 0) AS total_amount, MAX(r.payment_date) AS last_sale_date " +
                    "FROM dbo.Package p " +
                    "LEFT JOIN dbo.Receipt r ON r.package_id = p.package_id AND r.payment_date >= @from AND r.payment_date < @toExclusive " +
                    "WHERE p.is_active = 1 AND (@kw = '' OR p.package_name LIKE @kwLike) " +
                    "GROUP BY p.package_id, p.package_name, p.price, p.duration, p.with_trainer " +
                    "ORDER BY p.package_name");
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
                    "AND (@kw = '' OR CONVERT(NVARCHAR(36), r.receipt_id) LIKE @kwLike OR m.member_name LIKE @kwLike OR p.package_name LIKE @kwLike OR pm.method_name LIKE @kwLike) " +
                    "ORDER BY r.payment_date DESC");
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                cmd.Parameters.AddWithValue("@kw", keyword);
                cmd.Parameters.AddWithValue("@kwLike", likeKeyword);
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
                        int ordAge = reader.GetOrdinal("age");
                        int ordPhone = reader.GetOrdinal("phone_number");
                        int ordEmail = reader.GetOrdinal("email");
                        int ordGender = reader.GetOrdinal("gender");
                        int ordDate = reader.GetOrdinal("register_date");

                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetGuid(ordId);
                            int rowIndex = dgv_member.Rows.Add();
                            var row = dgv_member.Rows[rowIndex];
                            row.Cells["mem_report_id"].Value = id.ToString();
                            row.Cells["mem_total"].Value = reader.GetString(ordName);
                            row.Cells["mem_new"].Value = reader.GetInt32(ordAge);
                            row.Cells["mem_loss"].Value = reader.IsDBNull(ordPhone) ? string.Empty : reader.GetString(ordPhone);
                            row.Cells["mem_age"].Value = reader.IsDBNull(ordEmail) ? string.Empty : reader.GetString(ordEmail);
                            bool g = reader.GetBoolean(ordGender);
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
                        int ordId = reader.GetOrdinal("package_id");
                        int ordName = reader.GetOrdinal("package_name");
                        int ordPrice = reader.GetOrdinal("price");
                        int ordDuration = reader.GetOrdinal("duration");
                        int ordWithTrainer = reader.GetOrdinal("with_trainer");
                        int ordSold = reader.GetOrdinal("sold_count");
                        int ordAmt = reader.GetOrdinal("total_amount");
                        int ordDate = reader.GetOrdinal("last_sale_date");

                        while (await reader.ReadAsync())
                        {
                            var id = reader.GetGuid(ordId);
                            int rowIndex = dgv_revenue.Rows.Add();
                            var row = dgv_revenue.Rows[rowIndex];
                            row.Cells["rev_report_id"].Value = id.ToString();
                            row.Cells["rev_best"].Value = reader.GetString(ordName);
                            row.Cells["rev_least"].Value = reader.GetInt32(ordPrice).ToString("N0", CultureInfo.InvariantCulture);
                            row.Cells["rev_sold"].Value = reader.GetInt32(ordSold);
                            row.Cells["rev_amount"].Value = Convert.ToInt64(reader.GetValue(ordAmt), CultureInfo.InvariantCulture).ToString("N0", CultureInfo.InvariantCulture);
                            row.Cells["rev_cost"].Value = reader.GetInt32(ordDuration);
                            row.Cells["rev_profit"].Value = reader.GetBoolean(ordWithTrainer) ? "Có" : "Không";
                            row.Cells["rev_date"].Value = reader.IsDBNull(ordDate) ? "-" : reader.GetDateTime(ordDate).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            row.Tag = id;
                        }
                    }
                }
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
            chart_report.Series.Clear();
            chart_report.Titles.Clear();
            chart_report.Annotations.Clear();
            chart_report.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart_report.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chart_report.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart_report.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart_report.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;
            chart_report.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            chart_report.ChartAreas[0].AxisX.Interval = 1;
            chart_report.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;
            chart_report.ChartAreas[0].AxisY2.Title = string.Empty;

            DateTime from = GetFilterFrom();
            DateTime toExclusive = GetFilterTo().AddDays(1);
            string keyword = (txt_keyword == null ? string.Empty : txt_keyword.Text.Trim());
            string likeKeyword = "%" + keyword + "%";

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
                            cmd.CommandText =
                                "SELECT register_date, gender, COUNT(*) AS total_count FROM dbo.Member " +
                                "WHERE register_date >= @from AND register_date < @toExclusive " +
                                "AND (@kw = '' OR member_name LIKE @kwLike OR phone_number LIKE @kwLike OR email LIKE @kwLike) " +
                                "GROUP BY register_date, gender " +
                                "ORDER BY register_date";
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                            cmd.Parameters.AddWithValue("@kw", keyword);
                            cmd.Parameters.AddWithValue("@kwLike", likeKeyword);

                            var chartType = ResolveChartType();
                            var sMale = new Series("Đăng ký Nam") { ChartType = chartType };
                            var sFemale = new Series("Đăng ký Nữ") { ChartType = chartType };
                            sMale.ChartArea = chart_report.ChartAreas[0].Name;
                            sFemale.ChartArea = chart_report.ChartAreas[0].Name;

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                while (await r.ReadAsync())
                                {
                                    var d = r.GetDateTime(0).Date;
                                    bool isMale = r.GetBoolean(1);
                                    int count = r.GetInt32(2);
                                    Series targetSeries = isMale ? sMale : sFemale;
                                    int pointIndex = targetSeries.Points.AddXY(d, count);
                                    string axisLabel = d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    targetSeries.Points[pointIndex].AxisLabel = axisLabel;
                                    totalPoints++;
                                }
                            }

                            chart_report.Series.Add(sMale);
                            chart_report.Series.Add(sFemale);
                        }
                    }
                    else if (cbo_report_type.SelectedIndex == KindRevenue)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText =
                                "SELECT p.package_name, COUNT(r.receipt_id) AS sold_count, ISNULL(SUM(CAST(r.total_amount AS BIGINT)), 0) AS total_amount " +
                                "FROM dbo.Package p " +
                                "LEFT JOIN dbo.Receipt r ON r.package_id = p.package_id AND r.payment_date >= @from AND r.payment_date < @toExclusive " +
                                "WHERE p.is_active = 1 AND (@kw = '' OR p.package_name LIKE @kwLike) " +
                                "GROUP BY p.package_name " +
                                "ORDER BY p.package_name";
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                            cmd.Parameters.AddWithValue("@kw", keyword);
                            cmd.Parameters.AddWithValue("@kwLike", likeKeyword);

                            var chartType = ResolveChartType();
                            var sSold = new Series("Số lượng bán") { ChartType = chartType, YAxisType = AxisType.Secondary };
                            var sAmount = new Series("Tổng thu") { ChartType = chartType };
                            sSold.ChartArea = chart_report.ChartAreas[0].Name;
                            sAmount.ChartArea = chart_report.ChartAreas[0].Name;

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                while (await r.ReadAsync())
                                {
                                    string packageName = r.GetString(0);
                                    int soldCount = r.GetInt32(1);
                                    double totalAmount = Convert.ToDouble(r.GetValue(2), CultureInfo.InvariantCulture);
                                    int pSold = sSold.Points.AddXY(packageName, soldCount);
                                    int pAmount = sAmount.Points.AddXY(packageName, totalAmount);
                                    sSold.Points[pSold].AxisLabel = packageName;
                                    sAmount.Points[pAmount].AxisLabel = packageName;
                                    totalPoints++;
                                }
                            }

                            sSold.ToolTip = "Số lượng bán - #VALX: #VALY{N0}";
                            sAmount.ToolTip = "Tổng thu - #VALX: #VALY{N0} VNĐ";
                            chart_report.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                            chart_report.ChartAreas[0].AxisY2.Title = "Số lượng bán";
                            chart_report.ChartAreas[0].AxisY2.LabelStyle.Format = "N0";
                            chart_report.Series.Add(sSold);
                            chart_report.Series.Add(sAmount);
                        }
                    }
                    else
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText =
                                "SELECT r.payment_date, COUNT(*) AS invoice_count, SUM(r.total_amount) AS total_amount " +
                                "FROM dbo.Receipt r " +
                                "INNER JOIN dbo.Member m ON m.member_id = r.member_id " +
                                "INNER JOIN dbo.Package p ON p.package_id = r.package_id " +
                                "INNER JOIN dbo.PaymentMethod pm ON pm.method_id = r.payment_method " +
                                "WHERE r.payment_date >= @from AND r.payment_date < @toExclusive " +
                                "AND (@kw = '' OR CONVERT(NVARCHAR(36), r.receipt_id) LIKE @kwLike OR m.member_name LIKE @kwLike OR p.package_name LIKE @kwLike OR pm.method_name LIKE @kwLike) " +
                                "GROUP BY r.payment_date " +
                                "ORDER BY r.payment_date";
                            cmd.Parameters.AddWithValue("@from", from);
                            cmd.Parameters.AddWithValue("@toExclusive", toExclusive);
                            cmd.Parameters.AddWithValue("@kw", keyword);
                            cmd.Parameters.AddWithValue("@kwLike", likeKeyword);

                            var chartType = ResolveChartType();
                            var sCount = new Series("Số hóa đơn") { ChartType = chartType, YAxisType = AxisType.Secondary };
                            var sAmount = new Series("Tổng tiền") { ChartType = chartType };
                            sCount.ChartArea = chart_report.ChartAreas[0].Name;
                            sAmount.ChartArea = chart_report.ChartAreas[0].Name;

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                while (await r.ReadAsync())
                                {
                                    var d = r.GetDateTime(0).Date;
                                    int count = r.GetInt32(1);
                                    double amount = Convert.ToDouble(r.GetValue(2), CultureInfo.InvariantCulture);
                                    int pCount = sCount.Points.AddXY(d, count);
                                    int pAmount = sAmount.Points.AddXY(d, amount);
                                    string axisLabel = d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    sCount.Points[pCount].AxisLabel = axisLabel;
                                    sAmount.Points[pAmount].AxisLabel = axisLabel;
                                    totalPoints++;
                                }
                            }

                            chart_report.Series.Add(sCount);
                            chart_report.Series.Add(sAmount);
                            chart_report.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                            chart_report.ChartAreas[0].AxisY2.Title = "Số hóa đơn";
                            chart_report.ChartAreas[0].AxisY2.LabelStyle.Format = "N0";
                        }
                    }
                }

                chart_report.ChartAreas[0].AxisX.Title = cbo_report_type.SelectedIndex == KindRevenue ? "Gói tập" : "Ngày báo cáo";
                chart_report.ChartAreas[0].AxisY.Title = cbo_report_type.SelectedIndex == KindMember ? "Số lượng" : "VNĐ";
                chart_report.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                chart_report.Legends[0].Enabled = chart_report.Series.Count > 0;
                chart_report.ChartAreas[0].AxisX.Interval = totalPoints > 40 ? 4 : totalPoints > 20 ? 2 : 1;

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

        private void UpdateSummary()
        {
            if (lbl_toolbar_summary == null) return;

            DateTime from = GetFilterFrom();
            string period = from.ToString("MM/yyyy", CultureInfo.InvariantCulture);

            if (cbo_report_type.SelectedIndex == KindMember)
            {
                int rows = dgv_member.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                int totalMale = 0;
                int totalFemale = 0;
                foreach (DataGridViewRow row in dgv_member.Rows)
                {
                    if (row.IsNewRow) continue;
                    string gender = row.Cells["mem_gender"].Value?.ToString();
                    if (gender == "Nam") totalMale++;
                    else if (gender == "Nữ") totalFemale++;
                }
                lbl_toolbar_summary.Text = "Kỳ: " + period + " | " + rows + " hội viên | Nam: " + totalMale + " | Nữ: " + totalFemale;
            }
            else if (cbo_report_type.SelectedIndex == KindRevenue)
            {
                int rows = dgv_revenue.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                long totalAmount = 0;
                int totalSold = 0;
                foreach (DataGridViewRow row in dgv_revenue.Rows)
                {
                    if (row.IsNewRow) continue;
                    totalAmount += ConvertToInt(row.Cells["rev_amount"].Value);
                    totalSold += ConvertToInt(row.Cells["rev_sold"].Value);
                }
                lbl_toolbar_summary.Text = "Kỳ: " + period + " | " + rows + " gói hoạt động | Tổng lượt bán: " + totalSold + " | Tổng thu: " + totalAmount.ToString("N0", CultureInfo.InvariantCulture) + " VNĐ";
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
                        sb.AppendLine(CsvLine("Mã báo cáo", "Tổng HV", "HV mới", "HV mất", "Tuổi TB", "Giới tính chủ yếu", "Ngày báo cáo"));
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
                        sb.AppendLine(CsvLine("Mã báo cáo", "Gói bán chạy", "Gói bán ế", "Tổng gói bán", "Tổng thu", "Tổng chi", "Lợi nhuận", "Ngày báo cáo"));
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
