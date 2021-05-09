namespace StoreModels
{
    public class Orders
    {
        public Orders(Customer customer,Product product,int qty){
            this.Customer=customer;
            this.Product=product;
            this.Quantity=qty;
        }


        public Customer Customer{get;set;}
        public Product Product{get;set;}
        public int Quantity{get;set;}
    }
}