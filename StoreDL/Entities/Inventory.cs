using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Location Store { get; set; }
    }
}
