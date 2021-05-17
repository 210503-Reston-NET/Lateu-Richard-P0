using System;
using StoreModels;
using System.Text.RegularExpressions;
using Xunit;

namespace StoreTests
{
    public class ProductTest
    {
        [Fact]
        public void NameShouldValidate()
        {
            //Arrange
            string name="Computer";
            Product product=new Product();      

            //Act
            product.Name=name;           

            //Assert
            Assert.Equal(true,name.Length>5);
          

        }

        [Fact]
         public void NameCaractersShouldValidate()
        {
            //Arrange
            string name="richardlateu@";
            Product product=new Product();      
            char [] s={'@','#','*','!','.','/','~'};
            int res=name.IndexOfAny(s);
            //Act
            product.Name=name;           

            //Assert
            Assert.Equal(-1,res);

        }


        
    }
}
