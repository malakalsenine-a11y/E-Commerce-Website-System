using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Category
    {
        public int categoryId { get; set; }  //generated 
        public string categoryName { get; set; } // user input
        public string description { get; set; } // user input

        public string imageUrl { get; set; } // user input
    }
}
