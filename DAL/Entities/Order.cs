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
    [Table("Order")]
    public class Order
    {
        [Key]
        public  int Order_Id { get; set; }
        public DateTime OrderDate {  get; set; }
        public decimal OrderPrice { get; set; }
        public ICollection<OrderDetails> orderDetails { get; set; }=new List<OrderDetails>();
        public Customer Customer { get; set; }
        //[ForeignKey("Customer")]
        //public int Customer_Id { get; set; }
        public ApplicationUser Employee { get; set; }
        //[ForeignKey("ApplicationUser")]
        //public string Employee_Id { get; set; }
    }
}
