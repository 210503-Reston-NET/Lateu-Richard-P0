namespace StoreUI
{
    public class MenuFactory
    {
      public static IMenu GetMenu(string menuType)
        {
            switch (menuType.ToLower())
            {
                case "manager":
                    return new ManagerMenu();
                case "saleagent":
                return new SaleRepresentativeMenu();
                   // return new RestaurantMenu(new RestaurantBL(new RepoFile()), new ValidationService());
                default:
                    return null;
            }
        }   
    }
}