using StoreBL;
using StoreModels;
using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class ManagerMenu:IMenu
    {
        private ICustomerBL _icutomerBL;
        private ILocationBL _iLocationBL;
        private IOrderBL _iOrderBL;
        private IValidationService _validate;

        public ManagerMenu(ICustomerBL icutomerBL, ILocationBL iLocationBL, IOrderBL iOrderBL, IValidationService validate)
        {
            this._icutomerBL = icutomerBL;
            this._iLocationBL = iLocationBL;
            this._iOrderBL = iOrderBL;
            this._validate = validate;
        }

        public void   Start(){
            bool repeat=true;
          do{
            Console.WriteLine("Welcome to my Restaurant Menu!");
                Console.WriteLine("What would you like to do?");
                
                Console.WriteLine("[0] Create a Customer");
                Console.WriteLine("[1] View  Customers");
                Console.WriteLine("[2] Go back");
                string input = Console.ReadLine();
                switch (input)
                {
                   
                    case "0":
                    AddCustomer();
                        
                        /*Console.WriteLine("Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Phone");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Address");
                        string address = Console.ReadLine();
                        StoreModels.Customer customer=new StoreModels.Customer(name,email,phone, address);
                        _icutomerBL.AddCustomer(customer);
                         Console.WriteLine("New Customer created!");
                        Console.WriteLine(customer.ToString());*/
                        break;
                    case "1":
                        ViewCustomers();
                        break;
                    case "2":
                    repeat=false;
                    break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }while(repeat);
            
        }

         private void AddCustomer()
        {
            Console.WriteLine("Enter the details of the customer you want to add");
            string name = _validate.ValidateName("Enter the restaurant name: ");
            string email = _validate.ValidateEmail("Enter customer email");
            Console.WriteLine("Enter customer  phone number");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Address Enter customer  ");
            string address=Console.ReadLine();
            try
            {
                    
           Customer customerObj=new Customer(name,email,phone, address);
           Customer newCustomer=_icutomerBL.AddCustomer(customerObj);
            Console.WriteLine("New Customer created!");
            Console.WriteLine(newCustomer.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         private void ViewCustomers()
        {
            List<Customer> customers = _icutomerBL.GetAllCustomers();
            if (customers.Count == 0) Console.WriteLine("No customer found");
            else
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }

        }
        
    }
}