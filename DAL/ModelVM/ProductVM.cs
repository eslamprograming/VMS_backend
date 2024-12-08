using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class ProductVM
    {
        public string Name { get; set; }
        public IFormFile Photho { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductAmount { get; set; }
        public int Category_Id { get; set; }
    }
}
