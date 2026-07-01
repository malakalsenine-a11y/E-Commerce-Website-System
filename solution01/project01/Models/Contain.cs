using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Contain
    {


        [Required]
        [Range(1, 999)]
        public int quantity { get; set; }  //calculated
    }
}
