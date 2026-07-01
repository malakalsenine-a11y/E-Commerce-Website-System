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
        public int reviewId { get; set; }  //generated 

        public int userId { get; set; } // user input (Foreign Key)

        public int productId { get; set; } // user input (Foreign Key)

        public int rating { get; set; } // user input

        public string comment { get; set; } // user input

        public DateTime reviewDate { get; set; } // user input

    }
}
