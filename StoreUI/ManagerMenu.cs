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
            Console.WriteLine("Welcome to my ShopApp Menu!");
                Console.WriteLine("What would you like to do?");
                
                Console.WriteLine("[1] Create operations");
                Console.WriteLine("\t[10] Create a Customer");
                Console.WriteLine("\t[11] View  Customers");
                Console.WriteLine("\t[12] Find Customer By Name");
                Console.WriteLine("[2] Location operations");
                Console.WriteLine("\t[20] Create a Location");
                Console.WriteLine("\t[21] View  Locations");
                Console.WriteLine("\t[22] Find Location By Name");
                Console.WriteLine("[3] Go back");

                string input = Console.ReadLine();
                switch (input)
                {
                   
                    case "0":
                        Console.WriteLine("Choose the specific action for the Customer");
                        break;
                    case "10":
                         AddCustomer();
                        break;
                    case "11":
                        ViewCustomers();
                        break;
                    case "12":
                        FindCustomerByName();
                        break;
                    case "2":
                        Console.WriteLine("Choose the specific action for the Location");
                        break;
                    case "20":
                        AddLocation();
                        break;
                    case "21":
                        ViewLocations();
                        break;
                    case "22":
                        FindLocationByName();
                        break;
                    case "3":
                    repeat=false;
                    break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }while(repeat);
            
        }


         private void AddLocation()
        {
            Console.WriteLine("Enter the details of the Location you want to add");
            Console.WriteLine("Enter Location  Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Location Address");
            string address=Console.ReadLine();
            try
            {
                    
           Location locationObj=new Location(name, address);
           Location newLocation=_iLocationBL.AddLocation(locationObj);
           Console.WriteLine("New Location created!");
           Console.WriteLine(newLocation.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         private void ViewLocations()
        {
            List<Location> locations = _iLocationBL.GetAllLocations();
            if (locations.Count == 0) Console.WriteLine("No Location found");
            else
            {
                Console.WriteLine("Locations list");
                foreach (Location location in locations)
                {
                    Console.WriteLine(location.ToString());
                }
            }

        }

      private void  FindLocationByName(){
    
         Console.WriteLine("Enter the Location name: ");
            string name =Console.ReadLine();
            
            try{
                Location found=_iLocationBL.FindLocationByName(name);
                if(! found.Equals(null)){
                    Console.WriteLine("Location details\n");
                    Console.WriteLine(found.ToString());
                }

            }catch(NullReferenceException e){
            Console.WriteLine($"Location {name} not found");
            }
            
            
        }
        



/// <summary>
/// Customer UI Calls
/// </summary>
         private void AddCustomer()
        {
            Console.WriteLine("Enter the details of the customer you want to add");
            string name = _validate.ValidateName("Enter the customer name: ");
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
                  Console.WriteLine("Customers list");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }

        }

      private void  FindCustomerByName(){
        //Console.WriteLine("Enter the details of the customer you want to add");
            string name = _validate.ValidateName("Enter the Custmer name: ");

            try{
                Customer found=_icutomerBL.GetCustomerByName(name);
                 if (!found.Equals(null)){
                     Console.WriteLine("customer details\n");
                     Console.WriteLine(found.ToString());
                     }

            }catch(NullReferenceException e){
               Console.WriteLine($"Customer {name} not found");
            }
           
           
            
            
        }
        
    }
}