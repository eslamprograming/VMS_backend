using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class WarehouseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public decimal Capacity { get; set; }
    }
}
