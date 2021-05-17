using System;
using StoreModels;
using System.Text.RegularExpressions;
using Xunit;

namespace StoreTests
{
    public class CustomerTest
    {
        public bool AddressStartingPoint(string address){
            string temp=address.Substring(0,2);
            return Regex.IsMatch(temp, @"^\d+$");
        }
        [Fact]
        public void AddressShouldValidate()
        {
            //Arrange
            string address="5620 SMYRNA GA";
            Customer customer=new Customer();      

            //Act
            customer.Address=address;           

            //Assert
            Assert.Equal(true,AddressStartingPoint(customer.Address));

        }

        [Fact]
         public void EmailShouldValidate()
        {
            //Arrange
            string email="richardlateu";
            Customer customer=new Customer();      

            //Act
            customer.Email=email;           

            //Assert
            Assert.Equal(email,customer.Address);

        }



    }
}
