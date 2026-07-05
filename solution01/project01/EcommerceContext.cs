using Microsoft.EntityFrameworkCore;
using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01
{
    public class EcommerceContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contain> Contains { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> users { get; set; }




    }
}
