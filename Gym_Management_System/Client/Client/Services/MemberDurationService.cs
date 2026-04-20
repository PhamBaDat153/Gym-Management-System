using Client.DataContext;
using System;
using System.Data.SqlClient;

namespace Client.Services
{
    internal static class MemberDurationService
    {
        /// <summary>
        /// Tự động trừ remaining_duration theo số ngày đã qua.
        /// Mỗi ngày chỉ trừ đúng 1 lần dựa trên cột last_duration_update.
        /// </summary>
        public static void UpdateRemainingDurationsOncePerDay()
        {
            try
            {
                using (SqlConnection conn = GymManagementSystemContext.Connect())
                using (SqlCommand cmd = new SqlCommand(
                    @"
IF COL_LENGTH('dbo.Member', 'last_duration_update') IS NULL
BEGIN
    ALTER TABLE dbo.Member
    ADD last_duration_update DATE NOT NULL
        CONSTRAINT DF_Member_last_duration_update DEFAULT (CONVERT(date, GETDATE()));
END;

DECLARE @today DATE = CONVERT(date, GETDATE());

UPDATE m
SET
    m.remaining_duration =
        CASE
            WHEN DATEDIFF(day, m.last_duration_update, @today) <= 0 THEN m.remaining_duration
            ELSE
                CASE
                    WHEN m.remaining_duration - DATEDIFF(day, m.last_duration_update, @today) < 0 THEN 0
                    ELSE m.remaining_duration - DATEDIFF(day, m.last_duration_update, @today)
                END
        END,
    m.last_duration_update =
        CASE
            WHEN DATEDIFF(day, m.last_duration_update, @today) <= 0 THEN m.last_duration_update
            ELSE @today
        END,
    m.is_expired =
        CASE
            WHEN
                (CASE
                    WHEN DATEDIFF(day, m.last_duration_update, @today) <= 0 THEN m.remaining_duration
                    ELSE
                        CASE
                            WHEN m.remaining_duration - DATEDIFF(day, m.last_duration_update, @today) < 0 THEN 0
                            ELSE m.remaining_duration - DATEDIFF(day, m.last_duration_update, @today)
                        END
                END) <= 0
            THEN 1 ELSE 0
        END
FROM dbo.Member m;
",
                    conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Best-effort: không chặn UI nếu DB không cho ALTER/UPDATE.
            }
        }
    }
}

