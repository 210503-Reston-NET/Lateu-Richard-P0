using StoreBL;
using StoreModels;
using System;
using Serilog;
using System.Collections.Generic;
namespace StoreUI
{
    public class ManagerMenu : IMenu
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
            this._iProductBL = iProductBL;
            this._validate = validate;

        }

        public void Start()
        {
            //adding serialog config
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("logs/StoreApp.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            //LoggingFactory Log=new LoggingFactory();

            bool repeat = true;
            do
            {
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

                Console.WriteLine("[4] order operations");
                Console.WriteLine("\t[40] place order  ");
                Console.WriteLine("\t[41] get order details ");
                Console.WriteLine("\t[42] print order history By Location");
                Console.WriteLine("\t[43] print order history By Customer");

                Console.WriteLine("[5] Go back");

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
                        Console.WriteLine("Choose the specific action on Order");
                        break;
                    case "40":
                        doOrder();
                        break;

                    case "41":
                        PrintOrder();
                        break;
                    case "42":
                        ViewHitoryByLocation();
                        break;
                    case "43":
                        ViewHitoryByCustomer();
                        break;
                    case "5":
                        //Console.WriteLine("Choose the specific action for orders");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            } while (repeat);

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
            string address = Console.ReadLine();
            try
            {

                Location locationObj = new Location(name, address);
                Location newLocation = _iLocationBL.AddLocation(locationObj);
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

        private void FindLocationByName()
        {

            Console.WriteLine("Enter the Location name: ");
            string name = Console.ReadLine();

            try
            {
                Location found = _iLocationBL.FindLocationByName(name);
                if (!found.Equals(null))
                {
                    Console.WriteLine("Location details\n");
                    Console.WriteLine(found.ToString());
                }

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Location {name} not found");
                e.ToString();
            }


        }
        private void getOrdersByLocation()
        {
            Console.WriteLine("Enter the Location name: ");
            string locationName = Console.ReadLine();
            List<Order> orders = _iLocationBL.ViewLocationOrders(locationName);
            printOrderDetails(orders);
        }

        private void printOrderDetails(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                order.ToString();
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
            string address = Console.ReadLine();
            try
            {

                Customer customerObj = new Customer(name, email, phone, address);
                Customer newCustomer = _icutomerBL.AddCustomer(customerObj);
                Console.WriteLine("New Customer created!");
                Console.WriteLine(newCustomer.ToString());

                Log.Information("New customer created : {a} by {b}", newCustomer.ToString(), "Admin");



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex, "Customer creation failed");
            }
            finally
            {
                Log.CloseAndFlush();
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

        private void FindCustomerByName()
        {
            string name = _validate.ValidateName("Enter the Custmer name: ");

            try
            {
                Customer found = _icutomerBL.GetCustomerByName(name);
                if (!found.Equals(null))
                {
                    Console.WriteLine("customer details\n");
                    Console.WriteLine(found.ToString());
                }

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Customer {name} not found");
                e.ToString();
            }


        }

        /// <summary>
        /// Product UI Calls
        /// </summary>

        private void AddProduct()
        {
            Console.WriteLine("Enter the details of the Product you want to add");
            Console.WriteLine("Enter Product  Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product barcode");
            string barcode = Console.ReadLine();
            Console.WriteLine("Enter Product price");
            string p = Console.ReadLine();
            double price = Double.Parse(p);
            Console.WriteLine("Enter Product intial stock");
            string st = Console.ReadLine();
            int stock = int.Parse(st);
            try
            {

                Product productObj = new Product(name, barcode, price, stock);
                Product newProduct = _iProductBL.AddProduct(productObj);
                Console.WriteLine("New Product created!");
                Console.WriteLine(newProduct.ToString());

            }
            catch (Exception e)
            {
                //Console.WriteLine(ex.Message);
                e.ToString();
            }
        }
        private void FindProductByName()
        {
            string name = _validate.ValidateName("Enter the Product name: ");

            try
            {
                Product found = _iProductBL.FindProductByName(name);
                if (!found.Equals(null))
                {
                    Console.WriteLine("product details\n");
                    Console.WriteLine(found.ToString());
                }

            }
            catch (NullReferenceException e)
            {

                Console.WriteLine($"Product {name} not found");
                e.ToString();
            }
        }
        private void ViewProducts()
        {
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

        private void Purchase() { }
        private void doOrder()
        {
            Customer customer = customerPrompt("Enter Customer Name:");
            Location location = LocationPrompt("Enter Location Name:");


            List<Item> items = OrderItemsPrompt("Enter Product Name");

            _iOrderBL.PlaceOrder(customer, location, items);
            Log.Information("order created for customer {a} by {b}", customer.Name, "Admin");


        }

        private List<Item> OrderItemsPrompt(string input)
        {
            List<Item> items = new List<Item>();
            Item item;
            bool repeat = true;
            do
            {
                item = new Item();
                string productName = _validate.ValidateName(input);
                Product product = _iProductBL.FindProductByName(productName);
                if (!product.Equals(null))
                {
                    Console.WriteLine("Enter quantity");
                    string s = Console.ReadLine();
                    int qty = int.Parse(s);
                    Console.WriteLine("Enter price unite");
                    string pr = Console.ReadLine();
                    int price = int.Parse(pr);
                    item.ProductId = product.Id;
                    item.Quantity = qty;
                    item.UnitPrice = price;

                    items.Add(item);

                }

                Console.WriteLine("Type 1 to continue or 0 to exit");
                if (Console.ReadLine() == "0")
                {
                    repeat = false;
                }

            } while (repeat);

            return items;


        }

        private Customer customerPrompt(string prompt)
        {
            bool repeat = true;
            Customer customer = new Customer();
            do
            {
                string customerName = _validate.ValidateName(prompt);
                customer = _icutomerBL.GetCustomerByName(customerName);
                if (!customer.Equals(null))
                {
                    repeat = false;
                }

            } while (repeat);

            return customer;
        }

        private Location LocationPrompt(string prompt)
        {
            bool repeat = true;
            Location location = new Location();
            do
            {

                string locationName = _validate.ValidateName(prompt);
                location = _iLocationBL.FindLocationByName(locationName);
                if (!location.Equals(null))
                {
                    repeat = false;
                }

            } while (repeat);

            return location;
        }


        private void PrintOrder()
        {
            Console.WriteLine("Enter Order ID: ");
            string i = Console.ReadLine();
            int id = int.Parse(i);
            Console.WriteLine("Requested Order details ");
            foreach (Item item in _iOrderBL.DisplayOrderDetails(id))
            {
                Console.WriteLine(item.ToString());

            }

        }

        private void ViewHitoryByCustomer()
        {
            Console.WriteLine("Enter Custmer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Requested Customer History details ");
            foreach (Order order in _iOrderBL.ViewOrderHistoryByCustomer(customerName))
            {
                Console.WriteLine($" Order ID: {order.Id}");
                Console.WriteLine("\t Order items ");
                foreach (Item item in _iOrderBL.DisplayOrderDetails(order.Id))
                {
                    Console.WriteLine(item.ToString());

                }

            }
        }

        private void ViewHitoryByLocation()
        {
            Console.WriteLine("Enter Location name: ");
            string locationName = Console.ReadLine();
            Console.WriteLine("Requested Location Orders details ");
            foreach (Order order in _iOrderBL.ViewOrderHistoryByLocation(locationName))
            {
                Console.WriteLine($" Order ID: {order.Id}");
                Console.WriteLine("\t Order items ");
                foreach (Item item in _iOrderBL.DisplayOrderDetails(order.Id))
                {
                    Console.WriteLine(item.ToString());

                }

            }

        }




    }
}