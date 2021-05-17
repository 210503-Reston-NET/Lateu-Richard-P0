using System;
using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IStoreBusnessLogic
    {
         
         //customer busness logic
         Customer AddCustomer(Customer c);
         Customer GetCustomerByName(string name);
         List<Customer> GetAllCustomers();

          //public  Customer FindCustomerById(int customer_id);

       void PlaceOrder(Customer customer,Location location, List<Item> items);
         void ViewOrderHistoryByCustomer(Customer customer);


         /// Location BL
          //public void ViewLocationInventory(Location location); 
          /* Location AddLocation(Location location);
           List<Location> GetAllLocation();

          Location FindLocationById(int location_id);
*/
        ///order BL
         void DisplayOrderDetails(int order_id);
       
        void ViewOrderHistoryByLocation(Location location);


    }
}