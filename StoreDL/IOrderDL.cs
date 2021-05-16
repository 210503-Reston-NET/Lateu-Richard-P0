using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IOrderDL
    {
          List<Item> DisplayOrderDetails(int order_id);
       
         List<Order> ViewOrderHistoryByLocation(int location_id);

         List<Order> ViewOrderHistoryByCustomer(int customer_id);
          void PlaceOrder(Customer customer, List<Item> items);

    }
}