using System;
using Model= StoreModels;
using System.Collections.Generic;
using System.IO; // For the File IO
using System.Text.Json; // Json serialization (marshalling and unmarshalling)
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
          
            return location;
        }

         public   List<Model.Location> GetAllLocation(){

                return new List<Model.Location>();
            }

           public  Model.Location FindLocationById(int location_id){

                 return new Model.Location();
             }
    }
}
