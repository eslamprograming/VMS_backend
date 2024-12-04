using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class ProductSuppliyVM
    {
        public string EmployeeID { get; set; }
        public int SupplierID { get; set; }
        public decimal price { get; set; }
        public List<Product_Amount> product_Amounts { get; set; } = new List<Product_Amount>();
    }
}
