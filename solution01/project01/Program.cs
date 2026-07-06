using project01.Models;

namespace project01
{
    public class Program
    {

        public static EcommerceContext context = new EcommerceContext();


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
        static void Main(string[] args) 
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
