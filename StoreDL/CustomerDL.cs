using StoreModels;
using System.IO; // For the File IO
using System.Text.Json; // Json serialization (marshalling and unmarshalling)
namespace StoreDL
{
    public class CustomerDL:ICustomerDL
    {
         const string filePath="../StoreDL/data.json";
         private string jsonString;
        public Customer AddCustomer(Customer customer){
            jsonString = JsonSerializer.Serialize(customer);
            File.WriteAllText(filePath, jsonString);
            return customer;
        }

        
            List<Customer> GetAllCustomer(){

                return new List<Customer>();
            }

             Customer FindCustomerById(int customer_id){

                 return new Customer();
             }

             public Customer GetCustomerByName(string name){
                 return new Customer();
             }

               public void PlaceOrder(Customer customer, List<Item> items){
         throw new System.Exception("PlaceOrder yet implemented in DL");
       }
        public void ViewOrderHistoryByCustomer(Customer customer){
          throw new System.Exception("ViewOrderHistoryByCustomer yet implemented in DL");
        }
        
    }
}