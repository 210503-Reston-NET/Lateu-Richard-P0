using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ICustomerBL
    {
         Customer AddCustomer(Customer c);
         Customer GetCustomerByName(string name);

       List<Customer> GetAllCustomer();

     //public  Customer FindCustomerById(int customer_id);

        void PlaceOrder(Customer customer, List<Item> items);
         void ViewOrderHistoryByCustomer(Customer customer);

         
    }
}