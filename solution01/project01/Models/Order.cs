using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Order
    {
        public int orderId { get; set; }  //generated 
        public int userId { get; set; } // user input (Foreign Key)
        public DateTime orderDate { get; set; } // user input

        public decimal totalAmount { get; set; } // user input

        public string status { get; set; } // defult

        public string shippingAddress { get; set; } // user input

        public string paymentMethod { get; set; } // user input


    }
}
