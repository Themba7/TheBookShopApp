using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.Common;
using TheBookShop.Core.Repository.IRepository;
using TheBookShop.DataAccess.Data;
using TheBookShop.Models;

namespace TheBookShop.Core.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public SubscriptionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SubscriptionDto>> SubscribeToAssert(SubscriptionDto addSubscription)
        {
            try
            {
                var subscription = _mapper.Map<SubscriptionDto, Subscription>(addSubscription);
                subscription.ApplicationUser = await _db.Users.FindAsync(addSubscription.ApplicationUserId);
                subscription.BookShopAsset = await _db.BookShopAssets.FindAsync(addSubscription.BookShopAssetId);
                var addedSubscription = await _db.Subscriptions.AddAsync(subscription);
                await _db.SaveChangesAsync();

                var result = _mapper.Map<Subscription, SubscriptionDto>(addedSubscription.Entity);

                return new ServiceResponse<SubscriptionDto>
                {
                    IsSuccess = true,
                    Time = DateTime.Now,
                    Data = result,
                    Message = "Subscription added"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<SubscriptionDto>
                {
                    IsSuccess = false,
                    Data = addSubscription,
                    Message = ex.Message,
                    Time = DateTime.Now
                };
            }
        }

        public async Task<ServiceResponse<SubscriptionDto>> UnsubscribeToAssert(SubscriptionDto unsubscribe)
        {
            try
            {
                var cancelSubscription = await _db.Subscriptions.FirstOrDefaultAsync(x =>
                x.BookShopAsset.Id == unsubscribe.BookShopAssetId &&
                x.Status == SubscriptionStatus.Subscribed &&
                x.ApplicationUser.Id == unsubscribe.ApplicationUserId &&
                x.Id == unsubscribe.SubscriptionRefId);

                if (cancelSubscription == null)
                {
                    return new ServiceResponse<SubscriptionDto>
                    {
                        IsSuccess = false,
                        Time = DateTime.Now,
                        Data = unsubscribe,
                        Message = "Sunscription not found"
                    };
                }

                var subscription = _mapper.Map<SubscriptionDto, Subscription>(unsubscribe);
                var addedSubscription = await _db.Subscriptions.AddAsync(subscription);
                await _db.SaveChangesAsync();

                var result = _mapper.Map<Subscription, SubscriptionDto>(addedSubscription.Entity);

                return new ServiceResponse<SubscriptionDto>
                {
                    IsSuccess = true,
                    Time = DateTime.Now,
                    Data = result,
                    Message = "Unsubscribed"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<SubscriptionDto>
                {
                    IsSuccess = false,
                    Data = unsubscribe,
                    Message = ex.Message,
                    Time = DateTime.Now
                };
            }
        }
    }
}
