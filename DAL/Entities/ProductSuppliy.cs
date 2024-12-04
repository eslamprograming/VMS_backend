using DAL.ModelVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ProductSuppliy")]
    public class ProductSuppliy
    {
        [Key]
        public int ProductSuppliy_Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal ProductSuppliy_Price { get; set; }
        public ICollection<SuppliyProductDetails> SuppliyProductDetails { get; set; }=
            new List<SuppliyProductDetails>();
        public Supplier Supplier { get; set; }
        //[ForeignKey("Supplier")]
        //public int Supplier_Id { get; set; } 
        public ApplicationUser Employee { get; set; }
        //[ForeignKey("ApplicationUser")]
        //public int Employee_Id { get; set;}
    }
}
