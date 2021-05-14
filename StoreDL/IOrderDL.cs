using StoreModels;
namespace StoreDL
{
    public interface IOrderDL
    {
          public void DisplayOrderDetails(int order_id);
       
        public void ViewOrderHistoryByLocation(Location location);

    }
}