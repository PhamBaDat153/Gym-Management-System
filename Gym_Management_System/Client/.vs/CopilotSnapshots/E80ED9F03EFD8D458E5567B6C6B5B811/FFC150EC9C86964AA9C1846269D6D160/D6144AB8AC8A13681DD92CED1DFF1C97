using Client.DataContext;
using Client.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace Client.Forms.ScheduleBrowse
{
    public partial class frmBrowse : Form
    {
        SqlConnection connection;

        public frmBrowse()
        {
            InitializeComponent();
        }

        private void frmBrowse_Load(object sender, EventArgs e)
        {
            LoadCombo();

            SqlCommand cmd = new SqlCommand(@"
                SELECT 
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
                WHERE CAST(s.schedule_date AS DATE) = @date
            ");

            cmd.Parameters.AddWithValue("@date", DateTime.Today);

            LoadData(cmd);
        }

        // ===== LOAD DATA GIỐNG frmEmployee =====
        public void LoadData(SqlCommand cmd)
        {
            try
            {
                connection = GymManagementSystemContext.Connect();
                cmd.Connection = connection;
                connection.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvScheduleBrowse.DataSource = dt;

                if (dgvScheduleBrowse.Columns["Giờ bắt đầu"] != null)
                    dgvScheduleBrowse.Columns["Giờ bắt đầu"].DefaultCellStyle.Format = "HH:mm";

                if (dgvScheduleBrowse.Columns["Giờ kết thúc"] != null)
                    dgvScheduleBrowse.Columns["Giờ kết thúc"].DefaultCellStyle.Format = "HH:mm";

                dgvScheduleBrowse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // ===== LOAD COMBO =====
        private void LoadCombo()
        {
            using (SqlConnection conn = GymManagementSystemContext.Connect())
            {
                conn.Open();

                // Trainer
                SqlDataAdapter daTrainer = new SqlDataAdapter(
                    "SELECT employee_id, employee_name FROM Employee WHERE login_key = 'trainer' AND is_active = 1",
                    conn);

                DataTable dtTrainer = new DataTable();
                daTrainer.Fill(dtTrainer);

                cmbTrainer.DataSource = dtTrainer;
                cmbTrainer.DisplayMember = "employee_name";

                // Member
                SqlDataAdapter daMember = new SqlDataAdapter(
                    "SELECT member_name FROM Member", conn);
                DataTable dtMember = new DataTable();
                daMember.Fill(dtMember);

                cmbMember.DataSource = dtMember;
                cmbMember.DisplayMember = "member_name";
            }
        }

        // ===== SEARCH =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT 
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
                WHERE CAST(s.schedule_date AS DATE) = @date
            ");

            cmd.Parameters.AddWithValue("@date", monthCalendar1.SelectionStart.Date);

            if (!string.IsNullOrWhiteSpace(cmbTrainer.Text))
            {
                cmd.CommandText += " AND e.employee_name LIKE @trainer";
                cmd.Parameters.AddWithValue("@trainer", "%" + cmbTrainer.Text + "%");
            }

            if (!string.IsNullOrWhiteSpace(cmbMember.Text))
            {
                cmd.CommandText += " AND m.member_name LIKE @member";
                cmd.Parameters.AddWithValue("@member", "%" + cmbMember.Text + "%");
            }

            LoadData(cmd);
        }

        // ===== CLICK NGÀY =====
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            btnSearch_Click(sender, e); // reuse luôn
        }
        private void dgvScheduleBrowse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}