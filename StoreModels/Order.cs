using System;
using System.Collections.Generic;
namespace StoreModels
{

    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
          public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }
        public DateTime date {get; set;}

        public List<Item> Items{get;set;}

        public Order(Customer customer,int qty, List<Item> items){
            this.Customer=customer;
            this.Items=items;
        }


    
       
    }
}