using System;
using System.Collections.Generic;
namespace StoreModels
{

    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
          //public Customer Customer { get; set; }
        //public Location Location { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string Name  {get; set;}

        public List<Item> Items{get;set;}
        public Order(){}
        public Order(int customer_id, int location_id,DateTime orderDate,double orderTotal,string name){
            this.CustomerId=customer_id;
            this.StoreId=location_id;
            this.OrderDate=orderDate;
            this.OrderTotal=orderTotal;
            this.Name=name;
        }

         public Order(int Id,int customer_id, int location_id,DateTime orderDate,double orderTotal,string name):this(customer_id,location_id,orderDate,orderTotal,name){
            this.CustomerId=customer_id;
            this.StoreId=location_id;
            this.OrderDate=orderDate;
            this.OrderTotal=orderTotal;
            this.Name=name;
            this.Id=Id;

        }

          public override string ToString()
        {
          //  return base.ToString();
             return $" Name {Name}\t Customer ID: {CustomerId} \t Location ID: {StoreId}\t Date {OrderDate} \t Items: {Items}\n";
        }
    
       
    }
}