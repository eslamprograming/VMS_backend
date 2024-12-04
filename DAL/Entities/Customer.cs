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
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        //public ICollection<ApplicationUser> Employees { get; set; }=new List<ApplicationUser>();
    }
}
