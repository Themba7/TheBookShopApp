using System;
using System.Collections.Generic;

namespace TheBookShop.DataAccess.Data
{
    public class Patron
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
