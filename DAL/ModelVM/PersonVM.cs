using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelVM
{
    public class PersonVM
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
