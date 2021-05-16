using StoreDL;
using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderDL _orderDLAccess;
        private ILocationDL _locationDL;
        private ICustomerDL _customerDL;
        public OrderBL() { }
         public OrderBL(IOrderDL dataAccess,ILocationDL locationDL, ICustomerDL customerDL){ 
           this._orderDLAccess=dataAccess;
           this._locationDL=locationDL;
           this._customerDL=customerDL;
           }

         public List<Item> DisplayOrderDetails(int order_id){

          return _orderDLAccess.DisplayOrderDetails(order_id);
         }
       
       public  List<Order> ViewOrderHistoryByLocation(string locationName){
          Location location=_locationDL.FindLocationByName(locationName);
          if(!location.Equals(null))
            return _orderDLAccess.ViewOrderHistoryByLocation(location.Id);
          return new List<Order>();

        }

         public  List<Order> ViewOrderHistoryByCustomer(string  customerName){

            Customer customer=_customerDL.GetCustomerByName(customerName);
          if(!customer.Equals(null))
            return _orderDLAccess.ViewOrderHistoryByCustomer(customer.Id);
          return new List<Order>();
          }

          public void PlaceOrder(Customer customer, List<Item> items){
            _orderDLAccess.PlaceOrder(customer, items);
       }

    }
}