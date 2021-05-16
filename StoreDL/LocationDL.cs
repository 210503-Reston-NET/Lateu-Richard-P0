using System;
using Model= StoreModels;
using System.Collections.Generic;
using System.Linq;
using Entity=StoreDL.Entities;
namespace StoreDL
{
    public class LocationDL : ILocationDL
    {
       
        
        private Entity.projet0dbContext _context;
        public LocationDL() { }
        public LocationDL(Entity.projet0dbContext context){
            this._context=context;
        }

        public Model.Location AddLocation(Model.Location location){
              _context.Locations.Add(
                new Entity.Location
                {
                     Name = location.Name,
                    Address=location.Address,
                   
                  
                }
            );
           
            _context.SaveChanges();
            return location;          
        }

         public   List<Model.Location> GetAllLocations(){

              return _context.Locations.Select(
                    location=>new Model.Location(location.Name,location.Address)
                ).ToList();
               
            }

           public  Model.Location FindLocationByName(string name){              
                 Entity.Location response = _context.Locations.FirstOrDefault(location => location.Name == name);
                if (response == null) return null;
                return new Model.Location(response.Name,response.Address);
                              
             }

             public  void ViewLocationInventory(string name){

             }
    }
}
