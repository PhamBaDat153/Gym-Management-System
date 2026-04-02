using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Schedule
    {
        public Guid ScheduleId { get; set; }
        public string EmployeeId { get; set; }
        public string MemberId { get; set; }
        public string Note { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public int SessionStatus { get; set; }  
    }
}
