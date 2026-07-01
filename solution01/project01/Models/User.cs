using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }  //generated (Primary Key)

        [Required]
        [MaxLength (50)]

        public string username { get; set; } // user input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // user input


        [Required]
        [MaxLength(256)]
        public string passwordHash { get; set; } // user input


        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // user input


        [MaxLength(20)]
        public string? phoneNumber { get; set; } // user input


        [MaxLength(20)]
        public string? address { get; set; } // user input


        [Required]
        public DateTime registrationDate { get; set; } // user input



        public bool isActive { get; set; } = true ; // Default



    }
}
