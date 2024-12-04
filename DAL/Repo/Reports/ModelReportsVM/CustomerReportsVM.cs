using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Reports.ModelReportsVM
{
    public class CustomerReportsVM
    {
        public int Customer_Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public int? OrderCount { get; set; } 
        public decimal? totalOrderPrice { get; set; } 
    }
}
