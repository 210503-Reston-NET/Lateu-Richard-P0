using System;
using System;
using StoreBL;
using StoreModels;
namespace StoreUI
{
  public class Program
    {
  /// <summary>
        /// This is the main method, its the starting point of your application
        /// </summary>
        /// <param name="args"></param>
        private static ICustomerBL CustomerBL=new CustomerBL(new ICustomerDL());
        static void Main(string[] args)
        {
         //getting configurations from a config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up my db connections
            string connectionString = configuration.GetConnectionString("ShopDB");
            //we're building the dbcontext using the constructor that takes in options, we're setting the connection
            //string outside the context def'n
            DbContextOptions<demodbContext> options = new DbContextOptionsBuilder<demodbContext>()
            .UseSqlServer(connectionString)
            .Options;
            //passing the options we just built
            var context = new demodbContext(options);



          
        bool repeat=true;
          do{
            Console.WriteLine("Welcome to my Restaurant Menu!");
                Console.WriteLine("What would you like to do?");
                
                Console.WriteLine("[0] Create a Customer");
                Console.WriteLine("[1] Go back");
                string input = Console.ReadLine();
                switch (input)
                {
                   
                    case "0":
                        
                        Console.WriteLine("Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Email");
                        string email = Console.ReadLine();
                        Customer customer=new Customer(name,email);
                        CustomerBL.AddCustomer(customer);
                        break;
                    case "1":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }while(repeat);


        
        }

    }
}
