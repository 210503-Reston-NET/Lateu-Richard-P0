using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ILocationBL
    {
           //public void ViewLocationInventory(Location location); 
          public  Location AddLocation(Location location);
          public   List<Location> GetAllLocation();

          public    Location FindLocationById(int location_id);
    }
}