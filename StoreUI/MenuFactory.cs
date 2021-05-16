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
    public class MenuFactory
    {
      public static IMenu GetMenu(string menuType)
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
           
           // CustomerBL customerBL=new CustomerBL(new CustomerDL(context));

            switch (menuType.ToLower())
            {
                case "manager":
                    return new ManagerMenu(new CustomerBL(new CustomerDL(context))
                    ,new LocationBL(new LocationDL(context)),
                    new OrderBL(new OrderDL(context),new LocationDL(context),new CustomerDL(context)),
                    new ProductBL(new ProductDL
                    (context)),
                    new ValidationService());
                case "saleagent":
                    return new SaleRepresentativeMenu();
                   // return new RestaurantMenu(new RestaurantBL(new RepoFile()), new ValidationService());
                default:
                    return null;
            }
        }   
    }
}