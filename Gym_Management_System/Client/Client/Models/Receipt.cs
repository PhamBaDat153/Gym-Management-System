using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Receipt
    {
        public Guid ReceiptId { get; set; }
        public string MemberId { get; set; }
        public string PackageId { get; set; }
        public int TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethod { get; set; }
    }
}
