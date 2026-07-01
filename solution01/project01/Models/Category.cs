using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId { get; set; }  //generated  (Primary Key)


        [Required]
        [MaxLength(100)]
        public string categoryName { get; set; } // user input (unique)


        [MaxLength(500)]
        public string? description { get; set; } // user input (Optional)



        [MaxLength(300)]
        public string? imageUrl { get; set; } // user input  (Optional)
    }
}
