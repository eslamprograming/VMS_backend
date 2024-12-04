using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key]
        public int Warehouse_Id { get; set; }
        public string Name { get; set; }
        public string Location {  get; set; }
        public decimal Capacaty { get; set; }

        public ICollection<ProductWarehouse> ProductWarehouse { get; set; }=new List<ProductWarehouse>();
    }
}
