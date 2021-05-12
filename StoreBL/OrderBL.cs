namespace StoreBL
{
    public class OrderBL : IOrderBL
    {

 private IOrderDL _iorderDL=new IOrderDL();
        public void DisplayOrderDetails(int order_id){
                      _iorderDL.DisplayOrderDetails(order_id);
        }
       
        public void ViewOrderHistoryByLocation(Location location){
                       _iorderDL.ViewOrderHistoryByLocation(location);
        }
 
    }
}