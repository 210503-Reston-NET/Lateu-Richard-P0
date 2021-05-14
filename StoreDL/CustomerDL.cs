using System.Collections.Generic;
using Entity=RRDL.Entities;
using System.Linq;
namespace StoreDL
{
    public class CustomerDL:ICustomerDL
    {

        private Entity.demodbContext _context;
        public CustomerDL() { }
        public CustomerDL(Entity.demodbContext context){
            this._context=context;
        }

        

        public Model.Customer AddCustomer(Customer customer){
            //This records a change in the context change tracker that we want to add this particular entity to the 
            // db
       
            _context.Customers.Add(
                new Entity.Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address=CustomerDL.Address,
                }
            );
            //This persists the change to the db
            // Note: you can create a separate method that persists the changes so that you can execute repo commands in
            //the BL and save changes only when all the operations return no exceptions
            _context.SaveChanges();
            return customer;
        }

        
           public  List<Customer> GetAllCustomer(){

                return new List<Customer>();
            }

           public   Customer FindCustomerById(int customer_id){

                 return new Customer();
             }

             public Customer GetCustomerByName(string name){
                 return new Customer();
             }

               public void PlaceOrder(Customer customer, List<Item> items){
         throw new System.Exception("PlaceOrder yet implemented in DL");
       }
       /* public void ViewOrderHistoryByCustomer(Customer customer){
          throw new System.Exception("ViewOrderHistoryByCustomer yet implemented in DL");
        }*/
        
    }
}