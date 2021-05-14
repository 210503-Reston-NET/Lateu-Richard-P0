using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerDL
    {
        Customer AddCustomer(Customer customer); 

       List<Customer> GetAllCustomer();

       Customer FindCustomerById(int customer_id);

       Customer GetCustomerByName(string name);

       void PlaceOrder(Customer customer, List<Item> items);


       void ViewOrderHistoryByCustomer(Customer c);
    }
}