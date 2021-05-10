using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ICustomerBL
    {
        public Customer AddCustomer(Customer c);
        //public Customer GetCustomerByName(string name);
         
    }
}