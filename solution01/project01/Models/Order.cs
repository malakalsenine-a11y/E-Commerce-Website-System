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
        public DateTime orderDate { get; set; } // // system generated


        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal totalAmount { get; set; } // calculated



        [Required] 
        [MaxLength (30)]
        public string status { get; set; } = "Pending";  // default value


        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; } // user input


        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; } // // from list — "CreditCard" | "DebitCard" | "PayPal" | "Cash"

        // ========================================================


        // foreign key — every order must belong to exactly one user

        [Required]
        [ForeignKey("user")]
        public int userId { get; set; }   // from list (Foreign Key)

        public User user { get; set; } //navigation 

        public IList<Product> products { get; set; } // Relationship


        // reverse navigation — one Order has many OrderItems (bridge table)

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
