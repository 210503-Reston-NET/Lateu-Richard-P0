﻿using System;
using StoreModels;
using System.IO; // For the File IO
using System.Text.Json; // Json serialization (marshalling and unmarshalling)
namespace StoreDL
{
    public class LocationDL : ILocationDL
    {
        const string filePath="../StoreDL/data.json";
         private string jsonString;
        public LocationDL()
        {
        }

        public Location AddLocation(Location location){
           jsonString = JsonSerializer.Serialize(location);
            File.WriteAllText(filePath, jsonString);
            return location;
        }
    }
}
