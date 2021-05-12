using System;

namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        
        public string Name{get; set;}
        public string Email{get; set;}
      

       public Customer(string name,string email){
            
                this.Email=email;
                this.Name=name;
        }


    }
}
