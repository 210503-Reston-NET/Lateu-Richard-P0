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
        
    }
}