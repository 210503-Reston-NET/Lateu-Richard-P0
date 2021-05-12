using StoreModels;
namespace StoreDL
{
    public interface ICustomerDL
    {
      public  Customer AddCustomer(Customer customer); 

      List<Customer> GetAllCustomer();

      Location FindCustomerById(int customer_id);

      public Customer GetCustomerByName(string name);
    }
}