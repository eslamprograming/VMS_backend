using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Reports.ModelReportsVM
{
    public class SupplierReportsVM
    {
        public int Supplier_Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal total_Price { get; set; }
        public int Count {  get; set; }
    }
}
