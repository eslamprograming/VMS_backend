using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Required]
        public string name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();   
    }
}
