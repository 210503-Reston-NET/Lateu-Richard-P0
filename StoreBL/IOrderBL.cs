using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface IOrderBL
    {
        List<Item> DisplayOrderDetails(int order_id);
       
         void ViewOrderHistoryByLocation(Location location);

            void PlaceOrder(Customer customer, List<Item> items);
         
    }
}