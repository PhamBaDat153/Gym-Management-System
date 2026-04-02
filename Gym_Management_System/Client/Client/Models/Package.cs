using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Package
    {
        public Guid PackageId { get; set; }

        public string PackageName { get; set; }

        public int Duration { get; set; }

        public int Price { get; set; }

        public bool WithTrainer { get; set; }

        public bool IsActive { get; set; }
    }
}
