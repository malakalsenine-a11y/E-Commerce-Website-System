using project01.Models;

namespace project01
{
    public class Program
    {

        public static EcommerceContext context = new EcommerceContext();

        // ==================================================================
        //                       *** 01 Register a New User ***
        // ==================================================================

        public static void AddRegisterNewUser()
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

        public static void AddPlaceOrder()
        {
            Console.WriteLine("Enter User ID: ");
            int userid = int.Parse(Console.ReadLine());

            User user = context.users
                .FirstOrDefault(u => u.userId == userid);


            if(user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter Shipping Address: ");
            string shippingAddress = Console.ReadLine();

            Console.WriteLine("Payment Method:");
            Console.WriteLine("1. CreditCard");
            Console.WriteLine("2. DebitCard");
            Console.WriteLine("3. PayPal");
            Console.WriteLine("4. Cash");

            Console.Write("Choose Payment Method: ");
            int choice = int.Parse(Console.ReadLine());

            string paymentMethod;

            switch (choice)
            {
                case 1:
                    paymentMethod = "CreditCard";
                    break;
                case 2:
                    paymentMethod = "DebitCard";
                    break;
                case 3:
                    paymentMethod = "PayPal";
                    break;
                case 4:
                    paymentMethod = "Cash";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            //Console.WriteLine("Enter Payment Method:");
            //string paymentMethod = Console.ReadLine();

            //if (    paymentMethod != "CreditCard" &&
            //        paymentMethod != "DebitCard" &&
            //        paymentMethod != "PayPal" &&
            //        paymentMethod != "Cash")
            //    {
            //        Console.WriteLine("Invalid payment method.");
            //        return;
            //    }



            Order order = new Order
            {
                userId = userid,
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
                Console.WriteLine("Enter product ID:");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

      

                Product product = context.Products
                    .FirstOrDefault(P => P.productId == productId);

                if(product == null)
                {
                    Console.WriteLine("Product not found!");
                    return;
                }

                if (quantity > product.stockQuantity)
                {
                    Console.WriteLine("Not enough stock.");
                    return;
                }

                OrderItem orderItem = new OrderItem
                {
                    orderId = order.orderId,
                    productId = product.productId,
                    quantity = quantity,
                    unitPrice = product.price

                };

                context.OrderItems.Add(orderItem);
                order.totalAmount += product.price * quantity;
                product.stockQuantity -= quantity; // update stock


            }
            context.SaveChanges();

            Console.WriteLine("Order placed successfully.");
            Console.WriteLine(order.orderId);




        }

        // ==================================================================
        //                  *** 04 Write a Product Review ***
        // ==================================================================

        public static void WriteReview()
        {
            var users = context.users.ToList();

            foreach(var userx in users)
            {
                Console.WriteLine($"{userx.userId} , {userx.username}");
            }

            var products = context.Products.ToList();

            foreach (var productx in products)
            {
                Console.WriteLine($"{productx.productId} , {productx.productName}");

            }

            Console.WriteLine("=== Available Users ===");

            Console.WriteLine("Enter User ID: ");
            int userid = int.Parse(Console.ReadLine());

            User user = context.users
                .FirstOrDefault(u => u.userId == userid);


            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }


            Console.WriteLine("=== Available Products ===");

            Console.WriteLine("Enter product ID: ");
            int idProduct = int.Parse(Console.ReadLine());

            Product product = context.Products
                .FirstOrDefault(p => p.productId == idProduct);


            if(product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }


            Console.WriteLine("Enter Rating (1 - 5): ");
            int rating = int.Parse(Console.ReadLine());

            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Rating must be between 1 and 5.");
                return;
            }


            Console.WriteLine("Enter Comment: ");
            string comment = Console.ReadLine();

           

            Review review = new Review
            {
                userId = userid,
                productId = idProduct,
                rating = rating,
                comment = comment,
                reviewDate = DateTime.Now
            };
            context.Reviews.Add(review);
            context.SaveChanges();
            Console.WriteLine("Review added successfully.");
        }


        // ==================================================================
        //                  *** 04 Write a Product Review ***
        // ==================================================================

        public static void UpdateProduct()
        {
            Console.WriteLine("Enter product ID: ");
            int idProduct = int.Parse(Console.ReadLine());


            Product product = context.Products
                .FirstOrDefault(p => p.productId == idProduct);


            if (product == null)
            {
                Console.WriteLine("product not found.");
                return;
            }

            Console.WriteLine("Enter new price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            if (newPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }


            product.price = newPrice;

            Console.WriteLine("Is product available? (true/false): ");
            bool isAvailable = bool.Parse(Console.ReadLine());


            product.isAvailable = isAvailable;


            context.SaveChanges();
            Console.WriteLine("Product updated successfully.");

        }


        static void Main(string[] args) 
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
