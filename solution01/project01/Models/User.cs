using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class User
    {
        public int userId { get; set; }  //generated 
        public string username { get; set; } // user input
        public string email { get; set; } // user input

        public string passwordHash { get; set; } // user input

        public string fullName { get; set; } // user input

        public string phoneNumber { get; set; } // user input

        public string address { get; set; } // user input

        public DateTime registrationDate { get; set; } // user input

        public bool isActive { get; set; } // Default



    }
}
