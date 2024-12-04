using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class PutProductInWarehouse
    {
        public int product_Id { get; set; }
        public int Warehouse_Id { get; set; }   
        public int Amount { get; set; }
    }
}
