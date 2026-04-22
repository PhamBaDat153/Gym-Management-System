using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    // Lớp để đăng nhập
    public static class User
    {
        public static event EventHandler Changed;

        public static Guid EmployeeId { get; set; }
        public static string LoginKey { get; set; }
        public static string Password { get; set; }
        public static string Email { get; set; }
        public static string ImageUrl { get; set; }
        public static string EmployeeName { get; set; }
        public static string PhoneNumber { get; set; }
        public static DateTime DateOfBirth { get; set; }
        public static int Salary { get; set; }
        public static DateTime HireDate { get; set; }
        public static bool Status { get; set; }
        public static bool IsActive { get; set; }

        public static List<string> Roles { get; set; } = new List<string>();

        public static void NotifyChanged()
        {
            try
            {
                Changed?.Invoke(null, EventArgs.Empty);
            }
            catch
            {
                // best-effort
            }
        }

        public static void Clear()
        {
            EmployeeId = Guid.Empty;
            LoginKey = null;
            Password = null;
            Email = null;
            ImageUrl = null;
            EmployeeName = null;
            PhoneNumber = null;
            DateOfBirth = DateTime.MinValue;
            Salary = 0;
            HireDate = DateTime.MinValue;
            Status = false;
            IsActive = false;
            Roles.Clear();

            NotifyChanged();
        }
    }
}
