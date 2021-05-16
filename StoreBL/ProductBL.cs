using StoreDL;
using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private IProductDL _productDL;
        public ProductBL()
        {
        }
         public ProductBL(IProductDL pdl)
        {
            this._productDL=pdl;
        }

       public Product AddProduct(Product p){
        return _productDL.AddProduct(p);
       }
           public List<Product> GetAllProducts(){
            return _productDL.GetAllProducts();
           }
            public Product FindProductByName(string name){
            return _productDL.FindProductByName(name);
            }
    }
}