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
         public string Phone { get; set; }
        public string Address { get; set; }
      
      public Customer(){}

       public Customer(string name,string email,string phone, string address){
            
                this.Email=email;
                this.Name=name;
                this.Phone=phone;
                this.Address=address;
        }


    }
}
