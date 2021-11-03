using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.Common;

namespace TheBookShop.Models
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public decimal Fee { get; set; }
        public SubscriptionStatus Status { get; set; }
        public int SubscriptionRefId { get; set; }
        public int? BookShopAssetId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
