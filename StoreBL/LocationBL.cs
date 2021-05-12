using StoreModels;
namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationDL _locationDL=new LocationDL();
        public LocationBL()
        {
        }

        public Location AddLocation(Location location){

            return location;
        }

          List<Location> GetAllLocation(){
        

           return _locationDL.GetAllLocation();

          }

             Location FindLocationById(int location_id){
                 return _locationDL.FindLocationById(location_id);
             }
    }
}