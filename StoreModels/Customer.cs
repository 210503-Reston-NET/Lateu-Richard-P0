using System;

namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        
        public string Name{get; set;}
        public string email{get; set;}
        public Location Location;

        Customer(string name,string email,Location location){
                this.Location=location;
                this.Email=email;
                this.Name=name;
        }


    }
}
