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

        // ==================================================================
        //                  *** 03 Place an Order ***
        // ==================================================================

        public static void PlaceAnOrder()
        {
            Console.WriteLine("Enter User ID: ");
            int userid = int.Parse(Console.ReadLine());

            Console.Write("Enter Shipping Address: ");
            string shippingAddress = Console.ReadLine();

            Console.WriteLine("Payment Method:");
            Console.WriteLine("1. CreditCard");
            Console.WriteLine("2. DebitCard");
            Console.WriteLine("3. PayPal");
            Console.WriteLine("4. Cash");

            Console.WriteLine("Enter Payment Method:");
            string paymentMethod = Console.ReadLine();

            Order order = new Order
            {
                orderId = userid,
                orderDate = DateTime.Now,
                totalAmount = 0,
                status = "Pending",
                shippingAddress = shippingAddress,
                paymentMethod = paymentMethod
            };

            context.Orders.Add(order);
            context.SaveChanges();


            //---------------------------------------------------

            Console.WriteLine("How many products? ");
            int productNum = int.Parse(Console.ReadLine());

            for(int i = 1; i<= productNum; i++)
            {

            }

        }








        static void Main(string[] args) 
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
