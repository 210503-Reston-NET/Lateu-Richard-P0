using System;
using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class CustomerBL:ICustomerBL
    {
        private ICustomerDL _dataAccess=new CustomerDL();

        public CustomerBL(ICustomerDL iCustomerDL )
        {
            this._dataAccess=iCustomerDL;
        }

        public Customer AddCustomer(Customer c){
                   _dataAccess.AddCustomer(c);
             return c;
         }

           public Customer GetCustomerByName(string name){
               return _dataAccess.GetCustomerByName(name);
           }

      public List<Customer> GetAllCustomer(){
          return _dataAccess.GetAllCustomer();
      }

      /*public Location FindCustomerById(int customer_id){
          return _dataAccess.FindCustomerById(customer_id);
      }*/

       public void PlaceOrder(Customer customer, List<Item> items){
            _dataAccess.PlaceOrder(customer, items);
       }
        public void ViewOrderHistoryByCustomer(Customer customer){
             _dataAccess.ViewOrderHistoryByCustomer(customer);
        }

        
    }
}
