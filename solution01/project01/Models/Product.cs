using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }  // System generated (Primary Key)


        [Required]
        [MaxLength(150)]
        public string productName { get; set; } // user input



        [MaxLength(1000)]
        public string? description { get; set; } // user input


        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; } // user input


        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0; // default value



        [MaxLength(300)]
        public string? imageUrl { get; set; } // user input



        [Required]
        public DateTime createdAt { get; set; } // system generated

        public bool isAvailable { get; set; } = true; // Default value


        // ==================================================================


        // foreign key — every product must belong to a category

        [Required]
        [ForeignKey("category")]
        public int categoryId { get; set; } // from list  (Foreign Key)
        public Category category { get; set; }  //navigation property


        // reverse navigation — one Product has many Reviews

        public List<Review> reviews { get; set; } // Relationship


        // reverse navigation — one Product appears in many OrderItems (bridge table)
        public List<Order> orders { get; set; } // Relationship


    }
}
