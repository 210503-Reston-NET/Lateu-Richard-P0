using StoreDL;
using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderDL _orderDLAccess;
        public OrderBL() { }
         public OrderBL(IOrderDL dataAccess  ){ this._orderDLAccess=dataAccess;}

         public List<Item> DisplayOrderDetails(int order_id){

          return _orderDLAccess.DisplayOrderDetails(order_id);
         }
       
        public void ViewOrderHistoryByLocation(Location location){

        }

          public void PlaceOrder(Customer customer, List<Item> items){
            _orderDLAccess.PlaceOrder(customer, items);
       }

    }
}