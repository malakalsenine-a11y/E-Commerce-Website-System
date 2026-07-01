using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId { get; set; }  //generated (Primary Key)


        [Required]
        [ForeignKey ("User")]
        public int userId { get; set; } // user input (Foreign Key)


        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; } // user input (Foreign Key)


        [Required]
        [Range (1 , 5)]
        public int rating { get; set; } // user input


        [MaxLength (1000)]
        public string? comment { get; set; } // user input


        [Required]
        public DateTime reviewDate { get; set; } // system generated



        // ===========================================================

        public User User { get; set; } //navigation
        public Product product { get; set; } //navigation

    }
}
