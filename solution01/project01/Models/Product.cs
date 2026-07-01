using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Product
    {

        public int productId { get; set; }  //generated 
        public string productName { get; set; } // user input
        public string description { get; set; } // user input

        public decimal price { get; set; } // user input

        public int stockQuantity { get; set; } // user input

        public string imageUrl { get; set; } // user input

        public int  categoryId { get; set; } // user input

        public DateTime registrationDate { get; set; } // user input (Foreign Key)

        public bool isAvailable { get; set; } // Default

    }
}
