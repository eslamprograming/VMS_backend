using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Reports
{
    public class ProductSupply
    {
        public int ProductSupply_Id { get; set; }
        public DateTime SupplyDate { get; set; }
        public decimal ProductSupply_Price { get; set; }
        public string Employee { get; set; }
        public string Supplier { get; set; }
    }
}
