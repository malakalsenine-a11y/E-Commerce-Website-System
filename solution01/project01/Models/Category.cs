using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }  //generated  (Primary Key)


        [Required]
        [MaxLength(100)]
        public string categoryName { get; set; } // user input


        [MaxLength(500)]
        public string? description { get; set; } // user input



        [MaxLength(300)]
        public string? imageUrl { get; set; } // user input
    }
}
