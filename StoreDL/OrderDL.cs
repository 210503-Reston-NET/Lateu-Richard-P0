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

       public Model.Order FindOrderByName(string orderName){
        Entity.Order response = _context.Orders.FirstOrDefault(order => order.Name == orderName);
                if (response == null) return null;
                return new Model.Order(response.Id,response.CustomerId,response.StoreId,response.OrderDate,response.OrderTotal,response.Name);

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

       public List<Model.Order> ViewOrderHistoryByCustomer(int customer_id){
            return _context.Orders.Where(
                    order=>order.CustomerId==customer_id
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

       public Model.Order AddOrder(Model.Order order){
 _context.Orders.Add(
                new Entity.Order
                {                    
                    
                    OrderDate = order.OrderDate,
                    OrderTotal=order.OrderTotal,
                    CustomerId = order.CustomerId,
                    StoreId = order.StoreId,
                    Name=order.Name,

                    

             
                }
            );
           
            _context.SaveChanges();
            return order;
       }
         public  Model.Item AddItem(Model.Item item){
         _context.Items.Add(
             new Entity.Item
             {
            UnitPrice=item.UnitPrice,
            OrderId=item.OrderId,
            ProductId=item.ProductId,
            Quantity=item.Quantity, 

             }
         );
         _context.SaveChanges();
         return item;
         }

        public void PlaceOrder(Model.Customer customer, Model.Location location,List<Model.Item> items){
        
       }
    }
}