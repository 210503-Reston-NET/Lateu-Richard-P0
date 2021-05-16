using StoreDL;
using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderDL _orderDLAccess;
        private ILocationDL _locationDL;
        public OrderBL() { }
         public OrderBL(IOrderDL dataAccess,ILocationDL locationDL  ){ 
           this._orderDLAccess=dataAccess;
           this._locationDL=locationDL;
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

          public void PlaceOrder(Customer customer, List<Item> items){
            _orderDLAccess.PlaceOrder(customer, items);
       }

    }
}