using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IOrderDL
    {
          void DisplayOrderDetails(int order_id);
       
         void ViewOrderHistoryByLocation(Location location);
          void PlaceOrder(Customer customer, List<Item> items);

    }
}