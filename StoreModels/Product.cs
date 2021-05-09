namespace StoreModels
{
    /// <summary>
    ///  This class should contain all necessary fields to define a product.
    /// </summary>
    public class Product
    {

        public Product(){}
       public string ProductName { get; set; }
     public double Price { get; set; }

        
        public int availableStock{get;set;}

        //todo: add more properties to define a product (maybe a category?)
          public Product(string name, double price,int stock){
              this.ProductName=name;
              this.Price=price;
              this.availableStock=stock;
          }
        

 
    }
}