using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.Models;

namespace TheBookShop.Core.Repository.IRepository
{
    public interface ISubscriptionRepository
    {
        Task<ServiceResponse<SubscriptionDto>> SubscribeToAssert(SubscriptionDto addSubscription);
        Task<ServiceResponse<SubscriptionDto>> UnsubscribeToAssert(SubscriptionDto addSubscription);
    }
}
