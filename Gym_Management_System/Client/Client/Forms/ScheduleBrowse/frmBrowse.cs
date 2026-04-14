using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms.ScheduleBrowse
{
    public partial class frmBrowse : Form
    {

        // TODO: Thay chuỗi này bằng Connection String bạn đã copy ở Server Explorer
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementSystem;Integrated Security=True";
        public frmBrowse()
        {
            InitializeComponent();
        }
        private void LoadScheduleByDate(DateTime selectedDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Câu lệnh SQL: Lọc (WHERE) theo cột schedule_date và đổi luôn tên cột sang tiếng Việt
                string query = @"SELECT 
                            e.employee_name AS [Huấn luyện viên], 
                            m.member_name AS [Hội viên], 
                            s.session_start AS [Giờ bắt đầu], 
                            s.session_end AS [Giờ kết thúc], 
                            CASE 
                                WHEN s.session_status = 1 THEN N'Hoạt động' 
                                ELSE N'Dừng hoạt động' 
                            END AS [Trạng thái]
                         FROM Schedule s
                         LEFT JOIN Employee e ON s.employee_id = e.employee_id
                         LEFT JOIN Member m ON s.member_id = m.member_id
                         WHERE CAST(s.schedule_date AS DATE) = @SelectedDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu vào bảng
                dgvScheduleBrowse.DataSource = dt; // Đổi 'dataGridView1' thành tên DataGridView của bạn nếu bạn đã đổi tên

                // Định dạng giờ hiển thị cho đẹp
                if (dgvScheduleBrowse.Columns["Giờ bắt đầu"] != null)
                    dgvScheduleBrowse.Columns["Giờ bắt đầu"].DefaultCellStyle.Format = "HH:mm";

                if (dgvScheduleBrowse.Columns["Giờ kết thúc"] != null)
                    dgvScheduleBrowse.Columns["Giờ kết thúc"].DefaultCellStyle.Format = "HH:mm";

                // Cho bảng tự động giãn đều lấp đầy
                dgvScheduleBrowse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void frmBrowse_Load(object sender, EventArgs e)
        {
            // Tự động load dữ liệu của ngày hiện tại
            LoadScheduleByDate(DateTime.Today);
        }
        private void dgvScheduleBrowse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            {
                // Chuỗi kết nối (nhớ đổi lại cho đúng với máy của bạn)
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GymManagementSystem;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // 1. Câu lệnh SQL gốc: Luôn luôn lọc theo Ngày đang chọn trên Lịch
                    string query = @"SELECT 
                            e.employee_name AS [Huấn luyện viên], 
                            m.member_name AS [Hội viên], 
                            s.session_start AS [Giờ bắt đầu], 
                            s.session_end AS [Giờ kết thúc], 
                            CASE 
                                WHEN s.session_status = 1 THEN N'Hoạt động' 
                                ELSE N'Dừng hoạt động' 
                            END AS [Trạng thái]
                         FROM Schedule s
                         LEFT JOIN Employee e ON s.employee_id = e.employee_id
                         LEFT JOIN Member m ON s.member_id = m.member_id
                         WHERE CAST(s.schedule_date AS DATE) = @SelectedDate";

                    // 2. Kiểm tra nếu có nhập Tên HLV thì thêm điều kiện lọc HLV
                    if (!string.IsNullOrWhiteSpace(cmbTrainer.Text))
                    {
                        query += " AND e.employee_name LIKE @TrainerName";
                    }

                    // 3. Kiểm tra nếu có nhập Tên Hội viên thì thêm điều kiện lọc Hội viên
                    if (!string.IsNullOrWhiteSpace(cmbMember.Text))
                    {
                        query += " AND m.member_name LIKE @MemberName";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền giá trị Ngày từ cuốn lịch vào SQL
                    cmd.Parameters.AddWithValue("@SelectedDate", monthCalendar1.SelectionStart.Date);

                    // Truyền giá trị chuỗi tìm kiếm (Dùng % để tìm kiếm gần đúng)
                    if (!string.IsNullOrWhiteSpace(cmbTrainer.Text))
                    {
                        cmd.Parameters.AddWithValue("@TrainerName", "%" + cmbTrainer.Text.Trim() + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(cmbMember.Text))
                    {
                        cmd.Parameters.AddWithValue("@MemberName", "%" + cmbMember.Text.Trim() + "%");
                    }

                    // Đổ dữ liệu ra bảng
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvScheduleBrowse.DataSource = dt;

                    // Định dạng giờ hiển thị
                    if (dgvScheduleBrowse.Columns["Giờ bắt đầu"] != null)
                        dgvScheduleBrowse.Columns["Giờ bắt đầu"].DefaultCellStyle.Format = "HH:mm";

                    if (dgvScheduleBrowse.Columns["Giờ kết thúc"] != null)
                        dgvScheduleBrowse.Columns["Giờ kết thúc"].DefaultCellStyle.Format = "HH:mm";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Lấy ngày mà người dùng vừa click trên lịch
            DateTime dateToView = monthCalendar1.SelectionStart;

            // Gọi hàm load dữ liệu
            LoadScheduleByDate(dateToView);
        }
    }
}
