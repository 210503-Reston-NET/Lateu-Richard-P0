using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ILocationDL
    {
           Location AddLocation(Location L);
           List<Location> GetAllLocations();
            Location FindLocationByName(string locationName);
           void ViewLocationInventory(string name); 
    }
}