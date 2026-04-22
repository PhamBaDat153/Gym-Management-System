using Client.DataContext;
using System;
using System.Data.SqlClient;

namespace Client.Services
{
    internal static class MemberDurationService
    {
        /// <summary>
        /// Tự động cập nhật remaining_duration theo hóa đơn mới nhất của hội viên:
        /// remaining = duration - số ngày đã qua từ payment_date (>= 0).
        /// Không phụ thuộc register_date.
        /// </summary>
        public static void UpdateRemainingDurationsOncePerDay()
        {
            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        @"
DECLARE @today DATE = CONVERT(date, GETDATE());

;WITH LatestReceipt AS (
    SELECT
        r.member_id,
        r.package_id,
        r.payment_date,
        ROW_NUMBER() OVER (PARTITION BY r.member_id ORDER BY r.payment_date DESC, r.receipt_id DESC) AS rn
    FROM dbo.Receipt r
)
UPDATE m
SET
    m.remaining_duration =
        CASE
            WHEN lr.rn = 1 THEN
                CASE
                    WHEN p.duration - DATEDIFF(day, lr.payment_date, @today) < 0 THEN 0
                    ELSE p.duration - DATEDIFF(day, lr.payment_date, @today)
                END
            ELSE 0
        END,
    m.is_expired =
        CASE
            WHEN lr.rn = 1 THEN
                CASE
                    WHEN p.duration - DATEDIFF(day, lr.payment_date, @today) <= 0 THEN 1 ELSE 0
                END
            ELSE 1
        END
FROM dbo.Member m
LEFT JOIN LatestReceipt lr ON lr.member_id = m.member_id AND lr.rn = 1
LEFT JOIN dbo.Package p ON p.package_id = lr.package_id;
",
                        conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Best-effort: không chặn UI nếu DB không cho ALTER/UPDATE.
            }
        }
    }
}

