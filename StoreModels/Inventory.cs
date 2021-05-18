using System;
namespace StoreModels
{
    public class Inventory
    {
         // public Product Location;
         //public int location_id{set;get;}
            //public Location Location{set;get;}
            //public Product Product{set;get;}

            public int StoreId { get; set; }
           public int ProductId { get; set; }

            public int quantity{set;get;}
            public DateTime OrderDate { get; set; }
            public string Inventorytype { get; set; }

           public  Inventory(){}
    }
}