using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string LoginKey { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        public List<Role> Roles { get; set; }
    }
}
