using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }  //generated (Primary Key)


        [Required]
        [MaxLength(150)]
        public string productName { get; set; } // user input



        [MaxLength(1000)]
        public string? description { get; set; } // user input


        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; } // user input


        [Required]
        [Range(0.01, double.MaxValue)]
        public int stockQuantity { get; set; } // user input


        [MaxLength(300)]
        public string? imageUrl { get; set; } // user input


        [Required]
        public int  categoryId { get; set; } // user input (Foreign Key)


        [Required]
        public DateTime createdAt { get; set; } // user input (Foreign Key)

        public bool isAvailable { get; set; } = true; // Default

    }
}
