using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
          public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new HashSet<Order>();
        }


       public Customer(string name,string email,string phone, string address){
            
                this.Email=email;
                this.Name=name;
                this.Phone=phone;
                this.Address=address;
        }

      
    }
}
