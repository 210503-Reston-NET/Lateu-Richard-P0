using System;
using System.Collections.Generic;

#nullable disable

namespace StoreUI.Entities
{
    public partial class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Store { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
