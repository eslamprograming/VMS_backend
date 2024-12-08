using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Name { get; set;}
        public string Photo { get; set; }
        public string Description { get; set;}
        public decimal Price { get; set;}
        public int ProductAmount { get; set;}
        public Category Category { get; set;}
        public ICollection<OrderDetails> OrderDetails { get; set; }=new List<OrderDetails>();
        public ICollection<SuppliyProductDetails> SuppliyProductDetails { get; set; }=
            new List<SuppliyProductDetails>();

        public ICollection<ProductWarehouse> ProductWarehouse { get; set; } = new List<ProductWarehouse>();



    }
}
