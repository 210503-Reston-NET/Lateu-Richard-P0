using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface IOrderBL
    {
        List<Item> DisplayOrderDetails(int order_id);
       

         List<Order> ViewOrderHistoryByLocation(string locationName);

            void PlaceOrder(Customer customer, List<Item> items);
         
    }
}