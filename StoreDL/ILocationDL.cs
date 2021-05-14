using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ILocationDL
    {
          public Location AddLocation(Location L);
           public List<Location> GetAllLocation();

           public  Location FindLocationById(int location_id);
    }
}