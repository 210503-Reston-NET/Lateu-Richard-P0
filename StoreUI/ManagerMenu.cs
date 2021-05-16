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
        private IProductBL _iProductBL;
        private IValidationService _validate;

        public ManagerMenu(ICustomerBL icutomerBL,
         ILocationBL iLocationBL,
          IOrderBL iOrderBL, 
          IProductBL iProductBL,
          IValidationService validate)
        {
            this._icutomerBL = icutomerBL;
            this._iLocationBL = iLocationBL;
            this._iOrderBL = iOrderBL;
            this._iProductBL=iProductBL;
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
                
                Console.WriteLine("[3] Product operations");
                Console.WriteLine("\t[30] create Product ");
                Console.WriteLine("\t[31] View Products");
                Console.WriteLine("\t[32] Find Product By Name");

                Console.WriteLine("[4] Go back");

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
                    Console.WriteLine("Choose the specific action on Product");
                    break;
                    case "30":
                        AddProduct();
                        break;
                    case "31":
                        ViewProducts();
                        break;
                    case "32":
                        FindProductByName();
                        break;
                    case "4":
                        //Console.WriteLine("Choose the specific action for orders");
                        repeat=false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }while(repeat);
            
        }

        

/// <summary>
/// Location UI Calls
/// </summary>

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
        
        /// <summary>
        /// Product UI Calls
        /// </summary>
        
        private void AddProduct(){
             Console.WriteLine("Enter the details of the Product you want to add");
            Console.WriteLine("Enter Product  Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product barcode");
            string barcode=Console.ReadLine();
            Console.WriteLine("Enter Product price");
            string p =Console.ReadLine();
            double price=Double.Parse(p);
            Console.WriteLine("Enter Product intial stock");
            string st=Console.ReadLine();
            int stock=int.Parse(st);
            try
            {
                    
           Product productObj=new Product(name, barcode,price,stock);
           Product newProduct=_iProductBL.AddProduct(productObj);
           Console.WriteLine("New Product created!");
           Console.WriteLine(newProduct.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void FindProductByName(){
            string name = _validate.ValidateName("Enter the Product name: ");

            try{
                Product found=_iProductBL.FindProductByName(name);
                 if (!found.Equals(null)){
                     Console.WriteLine("product details\n");
                     Console.WriteLine(found.ToString());
                     }

            }catch(NullReferenceException e){
               Console.WriteLine($"Product {name} not found");
            } 
        }
        private void ViewProducts(){
             List<Product> products = _iProductBL.GetAllProducts();
            if (products.Count == 0) Console.WriteLine("No Product found");
            else
            {
                  Console.WriteLine("Product list");
                foreach (Product product in products)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }



    /// <summary>
    /// Order UI Calls
    /// </summary>

       private void Purchase(){}
        private void OrderDetails(){}
        private void PlaceOrder(){}

        private void ViewHitoryByCustomer(){}

        private void ViewHitoryByLocation(){}


     
        
    }
}