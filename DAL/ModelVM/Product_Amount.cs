using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class Product_Amount
    {
        public int product_Id {  get; set; }
        public int Amount { get; set; }
        public decimal price { get; set; }
        public int Warehouse { get; set; }
    }
}
