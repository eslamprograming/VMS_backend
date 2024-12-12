using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class ApplicationUser:IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string? photo {  get; set; }
        public ICollection<Order> orders { get; set; }= new List<Order>();
        public ICollection<ProductSuppliy> ProductSuppliys { get; set; } = new List<ProductSuppliy>();
    }
}
