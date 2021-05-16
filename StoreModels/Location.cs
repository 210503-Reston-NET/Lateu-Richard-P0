namespace StoreModels
{
   /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public Location(string name,string Address){
           this.Name=name;
           this.Address=Address;
        
        }
     

         public override string ToString()
        {
          //  return base.ToString();
             return $" LocationName: {Name} \t Address: {Address}";
        }
    }
}