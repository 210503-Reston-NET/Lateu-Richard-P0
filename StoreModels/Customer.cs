using System;

namespace StoreModels
{
    public class Customer
    {
        Customer(string name,string email,Location location){
this.Location=location;
this.Email=email;
this.Name=name;
        }


        public string Name{get; set;}
        public string email{get; set;}
        public Location Location;
    }
}
