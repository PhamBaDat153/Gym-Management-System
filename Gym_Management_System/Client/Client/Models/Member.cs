using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Member
    {
        public Guid MemberId { get; set; }

        public string MemberName { get; set; }

        public bool Gender { get; set; } 

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int RemainingDuration { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool HasTrainer { get; set; }

        public bool IsExpired { get; set; }

        public bool IsActive { get; set; }
    }
}
