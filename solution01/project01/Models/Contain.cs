using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Contain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int quantityId { get; set; }    // system generated


        [Required]
        [Range(1, 999)]
        public int quantity { get; set; }   // user input


        // foreign key
        [Required]
        [ForeignKey("Order")]
        public int orderId { get; set; }
        public Order Order { get; set; }                  // navigation property


        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }                // from list 
        public Product Product { get; set; }              // navigation property



        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal unitPrice { get; set; }            // calculated — copied from product.price at the time of ordering

    }
}
