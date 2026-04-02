using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class MemberReport
    {
        public Guid ReportId { get; set; }
        public int TotalMember { get; set; }
        public int MonthlyNewMember { get; set; }
        public int MonthlyLossMember { get; set; }
        public int AverageAge { get; set; }
        public bool CommonGender { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
