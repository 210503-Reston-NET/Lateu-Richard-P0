using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ICustomerBL
    {
        public Customer AddCustomer(Customer c);
        public Customer GetCustomerByName(string name);

      List<Customer> GetAllCustomers();

      Location FindCustomerById(int customer_id);

       public void PlaceOrder(Customer customer, List<Item> items);
        public void ViewOrderHistoryByCustomer(Customer customer);

         
    }
}