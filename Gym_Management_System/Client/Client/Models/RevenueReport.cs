using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class RevenueReport
    {
        public Guid ReportId { get; set; }
        public string BestSellPackage { get; set; }
        public string LeastSellPackage { get; set; }
        public int TotalPackageSold { get; set; }
        public int TotalAmount { get; set; }
        public int TotalCost { get; set; }
        public int NetProfit { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
