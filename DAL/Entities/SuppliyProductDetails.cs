using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("SuppliyProductDetails")]
    public class SuppliyProductDetails
    {
        [Key]
        public int SuppliyProductDetails_Id { get; set; }
        public int amount {  get; set; }
        public decimal price { get; set; }  
        public Product Product {  get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public ProductSuppliy ProductSuppliy { get; set; }
    //    [ForeignKey("ProducSuppliy")]
    //    public int ProductSuppliy_Id { get; set; }
    //
    }
}
