﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        public int Supplier_Id { get; set; }
        public string Name { get; set;}
        public string Phone { get; set;}
        public ICollection<ProductSuppliy> ProductSuppliy { get; set; }

    }
}
