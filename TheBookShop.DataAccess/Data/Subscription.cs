using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TheBookShop.Common;

namespace TheBookShop.DataAccess.Data
{
    public class Subscription
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Fee { get; set; }
        public SubscriptionStatus Status { get; set; }
        public int? SubscriptionRefId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public virtual BookShopAsset BookShopAsset { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
