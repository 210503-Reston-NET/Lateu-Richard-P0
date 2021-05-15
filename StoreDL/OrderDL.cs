using System.Collections.Generic;
using Model= StoreModels;
using Entity=StoreDL.Entities;
namespace StoreDL
{
    public class OrderDL : IOrderDL
    {

        
        private Entity.projet0dbContext _context;
        public OrderDL() { }
        public OrderDL(Entity.projet0dbContext context){
            this._context=context;
        }
    

        public void DisplayOrderDetails(int order_id){

            throw new System.Exception("DisplayOrderDetails not yet impl in DL");
        }
       
        public void ViewOrderHistoryByLocation(Model.Location location){
            throw new System.Exception("ViewOrderHistoryByLocation not yet impl in DL");
        }

        public void PlaceOrder(Model.Customer customer, List<Model.Item> items){
         throw new System.Exception("PlaceOrder yet implemented in DL");
       }
    }
}