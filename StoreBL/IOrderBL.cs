using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface IOrderBL
    {
       public void DisplayOrderDetails(int order_id);
       
        public void ViewOrderHistoryByLocation(Location location);

     
         
    }
}