using System.Collections.Generic;
using Model= StoreModels;
using Entity=StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace StoreDL
{
    public class OrderDL : IOrderDL
    {

        
        private Entity.projet0dbContext _context;
        public OrderDL() { }
        public OrderDL(Entity.projet0dbContext context){
            this._context=context;
        }
    

        public List<Model.Item> DisplayOrderDetails(int order_id){
            return _context.Items.Where(
                    item=>item.OrderId==order_id
                ).Select(
                    item => new Model.Item
                    {
                        OrderId = item.OrderId,       
                        ProductId=item.ProductId,
                        Quantity=item.Quantity,
                        UnitPrice = item.UnitPrice,
                    
                    }
                ).ToList();

        }
       
        public List<Model.Order> ViewOrderHistoryByLocation(int location_id){
           return _context.Orders.Where(
                    order=>order.StoreId==location_id
                ).Select(
                    order => new Model.Order
                    {                         
                        Id = order.Id,  
                        CustomerId= order.CustomerId,    
                        OrderDate=order.OrderDate,
                        OrderTotal = order.OrderTotal,
                        StoreId=order.StoreId,
                    
                    }
                ).ToList();
        }

        public void PlaceOrder(Model.Customer customer, List<Model.Item> items){
         throw new System.Exception("PlaceOrder yet implemented in DL");
       }
    }
}