using Client.DataContext;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client.Forms.Dashboard
{
    public partial class frmDefault : Form
    {
        public frmDefault()
        {
            InitializeComponent();
        }

        private async void frmDefault_Load(object sender, EventArgs e)
        {
            SetupRevenueChart();
            await ReloadDashboardAsync();
        }

        private void SetupRevenueChart()
        {
            if (chartRevenueDaily == null) return;

            chartRevenueDaily.Series.Clear();
            chartRevenueDaily.ChartAreas.Clear();
            chartRevenueDaily.Legends.Clear();
            chartRevenueDaily.Titles.Clear();

            var area = new ChartArea("Main");
            area.AxisX.IntervalType = DateTimeIntervalType.Days;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Format = "dd/MM";
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(235, 235, 235);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(235, 235, 235);
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisX.Title = "Ngày";
            area.AxisY.Title = "VNĐ";
            chartRevenueDaily.ChartAreas.Add(area);

            var legend = new Legend("Legend");
            legend.Docking = Docking.Top;
            chartRevenueDaily.Legends.Add(legend);

            var title = new Title("Doanh thu theo ngày (tháng hiện tại)");
            title.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            chartRevenueDaily.Titles.Add(title);
        }

        private async Task ReloadDashboardAsync()
        {
            DateTime today = DateTime.Today;
            DateTime from = new DateTime(today.Year, today.Month, 1);
            DateTime toExclusive = from.AddMonths(1);

            try
            {
                int totalMembers = 0;
                int newThisMonth = 0;
                int expiringSoon = 0;
                long revenueMonth = 0;

                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "SELECT " +
                            " (SELECT COUNT(*) FROM dbo.Member WHERE is_active = 1) AS total_members, " +
                            " (SELECT COUNT(*) FROM dbo.Member WHERE register_date >= @from AND register_date < @toExclusive) AS new_this_month, " +
                            " (SELECT COUNT(*) FROM dbo.Member WHERE is_expired = 0 AND is_active = 1 AND remaining_duration > 0 AND remaining_duration <= 7) AS expiring_soon, " +
                            " (SELECT ISNULL(SUM(CAST(total_amount AS BIGINT)), 0) FROM dbo.Receipt WHERE payment_date >= @from AND payment_date < @toExclusive) AS revenue_month;";
                        cmd.Parameters.AddWithValue("@from", from);
                        cmd.Parameters.AddWithValue("@toExclusive", toExclusive);

                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (await r.ReadAsync())
                            {
                                totalMembers = Convert.ToInt32(r["total_members"], CultureInfo.InvariantCulture);
                                newThisMonth = Convert.ToInt32(r["new_this_month"], CultureInfo.InvariantCulture);
                                expiringSoon = Convert.ToInt32(r["expiring_soon"], CultureInfo.InvariantCulture);
                                revenueMonth = Convert.ToInt64(r["revenue_month"], CultureInfo.InvariantCulture);
                            }
                        }
                    }

                    await LoadRevenueDailyChartAsync(conn, from, toExclusive);
                }

                if (lblTotalMembersValue != null) lblTotalMembersValue.Text = totalMembers.ToString("N0", CultureInfo.InvariantCulture);
                if (lblNewThisMonthValue != null) lblNewThisMonthValue.Text = newThisMonth.ToString("N0", CultureInfo.InvariantCulture);
                if (lblExpiringSoonValue != null) lblExpiringSoonValue.Text = expiringSoon.ToString("N0", CultureInfo.InvariantCulture);
                if (lblRevenueMonthValue != null) lblRevenueMonthValue.Text = revenueMonth.ToString("N0", CultureInfo.InvariantCulture) + " đ";
            }
            catch (Exception ex)
            {
                // Không chặn trang chủ nếu thiếu DB; vẫn giữ UI hiển thị.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async Task LoadRevenueDailyChartAsync(SqlConnection conn, DateTime from, DateTime toExclusive)
        {
            if (chartRevenueDaily == null) return;

            chartRevenueDaily.Series.Clear();

            var s = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = chartRevenueDaily.ChartAreas.Count > 0 ? chartRevenueDaily.ChartAreas[0].Name : "Main",
                IsValueShownAsLabel = false
            };
            s.ToolTip = "Ngày #VALX: #VALY{N0} đ";

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText =
                    "SELECT payment_date, ISNULL(SUM(CAST(total_amount AS BIGINT)), 0) AS sum_amount " +
                    "FROM dbo.Receipt " +
                    "WHERE payment_date >= @from AND payment_date < @toExclusive " +
                    "GROUP BY payment_date " +
                    "ORDER BY payment_date";
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@toExclusive", toExclusive);

                using (var r = await cmd.ExecuteReaderAsync())
                {
                    while (await r.ReadAsync())
                    {
                        DateTime d = Convert.ToDateTime(r["payment_date"], CultureInfo.InvariantCulture).Date;
                        long amount = Convert.ToInt64(r["sum_amount"], CultureInfo.InvariantCulture);
                        int p = s.Points.AddXY(d, amount);
                        s.Points[p].AxisLabel = d.ToString("dd/MM", CultureInfo.InvariantCulture);
                    }
                }
            }

            chartRevenueDaily.Series.Add(s);

            // Nếu tháng hiện tại chưa có dữ liệu, báo nhẹ nhàng trên chart.
            if (s.Points.Count == 0)
            {
                chartRevenueDaily.Titles.Clear();
                var title = new Title("Chưa có doanh thu trong tháng hiện tại");
                title.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
                title.ForeColor = Color.DimGray;
                chartRevenueDaily.Titles.Add(title);
            }
            else if (chartRevenueDaily.Titles.Count == 0)
            {
                var title = new Title("Doanh thu theo ngày (tháng hiện tại)");
                title.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                chartRevenueDaily.Titles.Add(title);
            }

            // Giảm mật độ label nếu tháng có nhiều ngày/điểm
            if (chartRevenueDaily.ChartAreas.Count > 0)
            {
                int points = s.Points.Count;
                chartRevenueDaily.ChartAreas[0].AxisX.Interval = points > 20 ? 2 : 1;
            }
        }
    }
}
