using project01.Models;

namespace project01
{
    public class Program
    {

        public static EcommerceContext context = new EcommerceContext();

        // ==================================================================
        //                       *** 01 Register a New User ***
        // ==================================================================

        public static void RegisterNewUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Full Name: ");
            string fullname = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            User user = new User
            {
                username = username,
                email = email,
                passwordHash = password,
                fullName = fullname,
                phoneNumber = phone,
                address = address,
                registrationDate = DateTime.Now,
                isActive = true
            };

            context.users.Add(user);
            context.SaveChanges();

            Console.WriteLine($"New user ID: {user.userId}");
        }

        // ==================================================================
        //                  *** 02 Add a New Product to a Category ***
        // ==================================================================

        public static void AddNewProductToCategory()
        {

            var categories = context.Categories.ToList();

            foreach(var category in categories)
            {
                Console.WriteLine($"{category.categoryId}  -  {category.categoryName}");
            }


            Console.WriteLine("Enter Id of Category: ");
            int categoryID = int.Parse(Console.ReadLine());



            Console.Write(" Enter productName: ");
            string nameProduct = Console.ReadLine();

            Console.Write(" Enter description: ");
            string description = Console.ReadLine();

            Console.Write(" Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter imageUrl: ");
            string imageUrl = Console.ReadLine();

            Console.Write("Enter stockQuantity: ");
            int stockQuantity = int.Parse(Console.ReadLine());

            Product product = new Product
            {
                categoryId = categoryID,
                productName = nameProduct,
                description = description,
                price = price,
                imageUrl = imageUrl,
                stockQuantity = stockQuantity,
                createdAt = DateTime.Now,
                isAvailable = true
            };

            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("Product added successfully.");
        }











        static void Main(string[] args) 
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
