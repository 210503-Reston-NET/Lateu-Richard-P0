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

         _context.Customers.Add(
                new Entity.Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address=customer.Address,
                }
            );
           
            _context.SaveChanges();
            return customer;
        }

 
           public  List<Model.Customer> GetAllCustomers(){

                return _context.Customers.Select(
                    customer=>new Model.Customer(customer.Name,customer.Email,customer.Phone,customer.Address)
                ).ToList();
            }

           public   Model.Customer FindCustomerById(int customer_id){

                 return new Model.Customer();
             }

             public Model.Customer GetCustomerByName(string name){
                  
            Entity.Customer found = _context.Customers.FirstOrDefault(customer => customer.Name == name);
            // we get the results and return null if nothing is found, otherwise return a Model.Restaurant that was found
            if (found == null) return null;
            return new Model.Customer(found.Name, found.Email, found.Phone,found.Address);
                 return new Model.Customer();
             }


        public void ViewOrderHistoryByCustomer(Model.Customer customer){
          throw new System.Exception("ViewOrderHistoryByCustomer yet implemented in DL");
        }
        
    }
}