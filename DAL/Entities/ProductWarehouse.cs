using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ProductWarehouse")]
    public class ProductWarehouse
    {
        [Key]
        public int Id { get; set; } // Primary key for the join table

        //[ForeignKey("Product")]
        //public int ProductId { get; set; }

        //[ForeignKey("Warehouse")]
        //public int WarehouseId { get; set; }

        public int Amount { get; set; } // Field for the quantity of the product in the warehouse

        public DateTime DateTime { get; set; } // Field for the timestamp of the relationship

        // Navigation properties
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
