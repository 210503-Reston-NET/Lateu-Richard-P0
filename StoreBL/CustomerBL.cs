using System;
using StoreModels;
using StoreDL;
namespace StoreBL
{
    public class CustomerBL:ICustomerBL
    {
        private ICustomerDL _dataAccess=new CustomerDL();

        /*public CustomerBL(ICustomerDL iCustomerDL )
        {
            this._dataAccess=iCustomerDL;
        }*/

        public Customer AddCustomer(Customer c){
                   _dataAccess.AddCustomer(c);
             return c;
         }

        
    }
}
