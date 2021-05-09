using System;
using System.Collections.Generic;
namespace StoreModels
{

    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Orders
    {
          public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }

        public List<Item> Items{get;set;}

        public Orders(Customer customer,Product product,int qty, List<Item> items){
            this.Customer=customer;
            this.Product=product;
            this.Quantity=qty;
            this.item=items;
        }


        public Customer Customer{get;set;}
        public Product Product{get;set;}
        public int Quantity{get;set;}
    }
}