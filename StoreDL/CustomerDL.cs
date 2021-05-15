using System.Collections.Generic;
using System.Linq;
using Model=StoreModels;
using Entity=StoreDL.Entities;
namespace StoreDL
{
    public class CustomerDL : ICustomerDL
    {

        private Entity.projet0dbContext _context;
        public CustomerDL() { }
        public CustomerDL(Entity.projet0dbContext context){
            this._context=context;
        }

        

        public Model.Customer AddCustomer(Model.Customer customer){
            //This records a change in the context change tracker that we want to add this particular entity to the 
            // db
         _context.Customers.Add(
                new Entity.Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address=customer.Address,
                }
            );
            //This persists the change to the db
            // Note: you can create a separate method that persists the changes so that you can execute repo commands in
            //the BL and save changes only when all the operations return no exceptions
            _context.SaveChanges();
            return customer;
        }

        
           public  List<Model.Customer> GetAllCustomer(){

                return new List<Model.Customer>();
            }

           public   Model.Customer FindCustomerById(int customer_id){

                 return new Model.Customer();
             }

             public Model.Customer GetCustomerByName(string name){
                 return new Model.Customer();
             }

               public void PlaceOrder(Model.Customer customer, List<Model.Item> items){
         throw new System.Exception("PlaceOrder yet implemented in DL");
       }
        public void ViewOrderHistoryByCustomer(Model.Customer customer){
          throw new System.Exception("ViewOrderHistoryByCustomer yet implemented in DL");
        }
        
    }
}