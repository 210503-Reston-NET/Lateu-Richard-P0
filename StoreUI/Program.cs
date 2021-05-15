using System;
using StoreBL;
using StoreModels;
using StoreDL;
using StoreDL.Entities;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace StoreUI
{
  public class Program
    {
  /// <summary>
        /// This is the main method, its the starting point of your application
        /// </summary>
        /// <param name="args"></param>
       // private static CustomerBL customerBL=new CustomerBL();
        static void Main(string[] args)
        {
         //getting configurations from a config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up my db connections
            string connectionString = configuration.GetConnectionString("shopDB");
            //we're building the dbcontext using the constructor that takes in options, we're setting the connection
            //string outside the context def'n
            DbContextOptions<projet0dbContext> options = new DbContextOptionsBuilder<projet0dbContext>()
            .UseSqlServer(connectionString)
            .Options;
            //passing the options we just built
            var context = new projet0dbContext(options);
           
            CustomerBL customerBL=new CustomerBL(new CustomerDL(context));


          
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
                        Console.WriteLine("Phone");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Address");
                        string address = Console.ReadLine();
                        StoreModels.Customer customer=new StoreModels.Customer(name,email,phone, address);
                        customerBL.AddCustomer(customer);
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
