using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ILocationBL
    {
           //public void ViewLocationInventory(Location location); 
            Location AddLocation(Location location);
            List<Location> GetAllLocation();

             Location FindLocationById(int location_id);
    }
}