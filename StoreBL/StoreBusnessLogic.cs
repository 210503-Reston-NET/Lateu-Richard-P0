using System;
using StoreModels;
using StoreDL;
using System.Collections.Generic;
using Entity=StoreDL.Entities;
namespace StoreBL
{
    public class StoreBusnessLogic:IStoreBusnessLogic
    {
           private ICustomerDL _icustomerDL;
           private ILocationDL _ilocationDL;
           private IOrderDL _iorderDL;
           /*private Entity.projet0dbContext _context;

            public StoreBusnessLogic( var context){
                _context=(Entity.projet0dbContext)context;
            _icustomerDL=new CustomerDL(context);
            _ilocationDL= new LocationDL(context);
            _iorderDL=new OrderDL(context);

            }*/


          /* public StoreBusnessLogic(ICustomerDL icustomerDL,ILocationDL ilocationDL,IOrderDL iorderDL){

            this._icustomerDL=icustomerDL;
            this._ilocationDL=ilocationDL;
            this._iorderDL=iorderDL;
           }
*/
/// <summary>
/// Implementation of customer logic
/// </summary>
/// <param name="c"></param>
/// <returns></returns>
        public Customer AddCustomer(Customer c){
                   _icustomerDL.AddCustomer(c);
             return c;
         }

           public Customer GetCustomerByName(string name){
               return _icustomerDL.GetCustomerByName(name);
           }

      public List<Customer> GetAllCustomers(){
          return _icustomerDL.GetAllCustomers();
      }
      public Customer FindCustomerById(int customer_id){
          return _icustomerDL.FindCustomerById(customer_id);
      }
/// <summary>
/// Implementation of Location logic
/// </summary>
/// <param name="location"></param>
/// <returns></returns>
        public Location AddLocation(Location location){

            return location;
        }

        public  List<Location> GetAllLocation(){
        

           return _ilocationDL.GetAllLocation();

          }

          public   Location FindLocationById(int location_id){
                 return _ilocationDL.FindLocationById(location_id);
             }
      ///

      

       /// <summary>
       /// implementation of order logic
       /// </summary>
       /// <param name="customer"></param>
        public void ViewOrderHistoryByCustomer(Customer customer){
             _icustomerDL.ViewOrderHistoryByCustomer(customer);
        }

        public void PlaceOrder(Customer customer, List<Item> items){
            _iorderDL.PlaceOrder(customer, items);
       }

        public void DisplayOrderDetails(int order_id){


         }
       
        public void ViewOrderHistoryByLocation(Location location){

        }



        
    }
}