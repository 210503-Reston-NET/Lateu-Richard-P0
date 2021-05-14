using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
