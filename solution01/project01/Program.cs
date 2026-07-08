using Microsoft.EntityFrameworkCore;
using project01.Models;
using System.Transactions;

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
        //                  ***  Add Category ***
        // ==================================================================

        public static void AddCategory()
        {
            Console.Write("Enter Category Name: ");
            string categoryName = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Image URL: ");
            string imageUrl = Console.ReadLine();


            Category category = new Category
            {
                categoryName = categoryName,
                description = description,
                imageUrl = imageUrl
            };

            context.Categories.Add(category);
            context.SaveChanges();

            Console.WriteLine("Category added successfully.");
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


            Console.Write("Enter Category ID: ");
            int categoryID = int.Parse(Console.ReadLine());

            Category selectedCategory = context.Categories
               .FirstOrDefault(c => c.categoryId == categoryID);

            if (selectedCategory == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }


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
        //                  *** 05 Update Product Price and Availability ***
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


        // ==================================================================
        //                  *** 06 Cancel an Order ***
        // ==================================================================

        public static void CancelOrder()
        {
            Console.WriteLine("Enter order ID: ");
            int idOrder = int.Parse(Console.ReadLine());


            Order order = context.Orders
                .FirstOrDefault(o => o.orderId == idOrder);

            if(order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }



            var orderItems = context.OrderItems
                .Where(O => O.orderId == idOrder)
                .ToList();

            foreach(var orderItem in orderItems)
            {
                Product product = context.Products
                    .FirstOrDefault(P => P.productId == orderItem.productId);

                if(product != null)
                {
                    product.stockQuantity += orderItem.quantity;

                }

            }

            order.status = "Cancelled";
            context.SaveChanges();
            Console.WriteLine("Order cancelled successfully.");








        }


        // ==================================================================
        //                  *** 07 Delete a Review ***
        // ==================================================================

        public static void DeleteReview()
        {
            Console.WriteLine("Enter Review ID: ");
            int idReview = int.Parse(Console.ReadLine());

            Review review = context.Reviews
                .FirstOrDefault(r => r.reviewId == idReview);

            if(review == null)
            {
                Console.WriteLine("Review not found.");
                return;
            }

            context.Reviews.Remove(review);
            context.SaveChanges();
            Console.WriteLine("Review deleted successfully.");
        }

        // ==================================================================
        //                  *** 08 View All Products (Get All) ***
        // ==================================================================

        public static void ViewAllProducts()
        {
            List<Product> products = context.Products.ToList();

            Console.WriteLine("=== All Products ===");

            foreach (Product p in products)
            {
                Console.WriteLine($"Products Name{p.productName} \n" +
                    $"Price{p.price} \n" +
                    $"Stock quantity {p.stockQuantity} \n" +
                    $" availability status{p.isAvailable}\n ");
            }

        }


        // ==================================================================
        //        *** 09  Filter Products by Category and Price Range ***
        // ==================================================================

        public static void FilterProducts()
        {
            Console.WriteLine("Enter Category ID: ");
            int idCategory = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter minium price: ");
            decimal min = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter maximum price: ");
            decimal max = decimal.Parse(Console.ReadLine());

            List<Product> products = context.Products
                .Where(p => p.categoryId == idCategory
                        && p.price >= min
                        && p.price <= max)
                .OrderBy(p=> p.price)
                .ToList();

            foreach(var product in products)
            {
                Console.WriteLine($"Name: {product.productName}\n" +
                    $"Price: {product.price}\n" +
                    $"Stock Quantity: {product.stockQuantity}\n" +
                    $"isAvailable: {product.isAvailable}\n");
            }
        }


        // ==================================================================
        //      *** 10 Get Category with All Its Products (Include) ***
        // ==================================================================

        public static void GetCategoryWithProducts()
        {

            Console.WriteLine("Enter category ID: ");
            int id = int.Parse(Console.ReadLine());


            Category category = context.Categories
                .Include(c => c.products)
                .FirstOrDefault(c => c.categoryId == id);

            if(category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            Console.WriteLine($"Name: {category.categoryName} ");
            Console.WriteLine($"Description: {category.description}");



            Console.WriteLine("=== Products ===");


            foreach (var product in category.products)
            {
                Console.WriteLine(
                    $"Product Name: {product.productName} \n" +
                    $"Price: {product.price} \n");
            }


        }

        // ==================================================================
        //      *** 11  View Order History with Full Details (ThenInclude) ***
        // ==================================================================

        public static void ViewOrderHistory()
        {

        }

        // ==================================================================
        //      *** 12 Product Summary Report (Projection + Lazy Loading) ***
        // ==================================================================

        public static void ProductSummaryReport()
        {

        }







        static void Main(string[] args) 
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   Flight Management System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  - Add Register New User");
                Console.WriteLine(" 2  - Add Category");
                Console.WriteLine(" 3  - Add New Product To Categor");
                Console.WriteLine(" 4  - Add Place Order");
                Console.WriteLine(" 5  - Write Review");
                Console.WriteLine(" 6  - Update Product");
                Console.WriteLine(" 7  - Cancel Order");
                Console.WriteLine(" 8  - Delete Review");
                Console.WriteLine(" 9  - View All Products");
                Console.WriteLine(" 10  - Filter Products");
                Console.WriteLine(" 11  - Get Category With Products");
                Console.WriteLine(" 12 - View Order History");
                Console.WriteLine(" 13 - Product Summary Report");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: AddRegisterNewUser(); break;
                    case 2: AddCategory(); break;
                    case 3: AddNewProductToCategory(); break;
                    case 4: AddPlaceOrder(); break;
                    case 5: WriteReview(); break;
                    case 6: UpdateProduct(); break;
                    case 7: CancelOrder(); break;
                    case 8: DeleteReview(); break;
                    case 9: ViewAllProducts(); break;
                    case 10: FilterProducts(); break;
                    case 11: GetCategoryWithProducts(); break;
                    case 12: ViewOrderHistory(); break;
                    case 13: ProductSummaryReport(); break;
                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;

                }

                if(!exit)
                {
                    Console.WriteLine("\nPress any key to continue ...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("Goodbye!");

        }
    }
}
