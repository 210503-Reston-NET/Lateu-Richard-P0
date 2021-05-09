namespace StoreModels
{
    public class Location
    {
        
    Location(string state, string city){
        this.State=state;
        this.City=city;
    }

         public string State{get; set;}
        
        public string City{get; set;}
    }
}