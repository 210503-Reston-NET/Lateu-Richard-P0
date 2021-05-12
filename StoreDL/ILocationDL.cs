using StoreModels;
namespace StoreDL
{
    public interface ILocationDL
    {
          public Location AddLocation(Location L);
            List<Location> GetAllLocation();

             Location FindLocationById(int location_id);
    }
}