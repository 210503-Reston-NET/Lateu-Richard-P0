namespace StoreModels
{
    public class Product
    {

        public Product(){}

          public Product(string name, float price,int stock){
              this.Name=name;
              this.UnitePrice=price;
              this.availableStock=stock;
          }
        

        public string Name {get;set;}
        public float UnitePrice{get;set;}

        public int availableStock{get;set;}
    }
}