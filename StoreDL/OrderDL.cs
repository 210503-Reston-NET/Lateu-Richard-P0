namespace StoreDL
{
    public class OrderDL : IOrderDL
    {
        public OrderDL()
        {
        }

        public void DisplayOrderDetails(int order_id){

            throw new System.Exception("DisplayOrderDetails not yet impl in DL");
        }
       
        public void ViewOrderHistoryByLocation(Location location){
            throw new System.Exception("ViewOrderHistoryByLocation not yet impl in DL");
        }
    }
}