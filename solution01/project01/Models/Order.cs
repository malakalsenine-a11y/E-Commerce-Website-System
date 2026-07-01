using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }  //generated  (Primary Key)


        [Required]
        [ForeignKey("User")]
        public int userId { get; set; } // user input (Foreign Key)


        [Required]
        public DateTime orderDate { get; set; } // user input


        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal totalAmount { get; set; } // user input



        [Required]
        [MaxLength (30)]
        public string status { get; set; } = "Pending";// defult


        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; } // user input


        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; } // user input


    }
}
