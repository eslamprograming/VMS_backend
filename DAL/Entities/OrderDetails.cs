using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetails_Id { get; set; }
        [Required]
        public int ProductAmount { get; set; }
        public decimal ProductAmountPrice {  get; set; }
        public Order Order { get; set; }
        //[ForeignKey("Order")]
        //public int Order_Id { get; set; }
        //[ForeignKey("Product")]
        //public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
