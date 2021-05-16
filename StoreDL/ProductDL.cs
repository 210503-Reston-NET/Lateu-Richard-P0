using System;
using Model= StoreModels;
using System.Collections.Generic;
using System.Linq;
using Entity=StoreDL.Entities;
namespace StoreDL
{
    public class ProductDL : IProductDL
    {
             private Entity.projet0dbContext _context;
        public ProductDL()
        {
        }
    
        public ProductDL(Entity.projet0dbContext context){
            this._context=context;
        }

                public Model.Product AddProduct(Model.Product product){
              _context.Products.Add(
                new Entity.Product
                {
                    Name = product.Name,
                    Barcode=product.Barcode,
                    Price=product.Price,
                   AvailableStock=product.AvailableStock,
                   
                  
                }
            );
           
            _context.SaveChanges();
            return product;          
        }

         public   List<Model.Product> GetAllProducts(){

              return _context.Products.Select(
                    product=>new Model.Product(product.Name,product.Barcode,product.Price,product.AvailableStock)
                ).ToList();
               
            }

           public  Model.Product FindProductByName(string name){              
                 Entity.Product response = _context.Products.FirstOrDefault(product => product.Name == name);
                if (response == null) return null;
                return new Model.Product(response.Name,response.Barcode,response.Price,response.AvailableStock);
                              
             }
    }
}