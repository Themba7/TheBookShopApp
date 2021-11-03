using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBookShop.Core.Repository.IRepository;
using TheBookShop.Models;

namespace TheBookShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize] //add this back once auth is fixed on client side
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] SubscriptionDto subscription)
        {
            if (ModelState.IsValid)
            {
                var result = await _subscriptionRepository.SubscribeToAssert(subscription);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ServiceResponse<SubscriptionDto>
                {
                    Data = subscription,
                    IsSuccess = false,
                    Message = "Invalid subscription",
                    Time = DateTime.Now
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionDto subscription)
        {
            if (ModelState.IsValid)
            {
                var result = await _subscriptionRepository.SubscribeToAssert(subscription);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ServiceResponse<SubscriptionDto>
                {
                    Data = subscription,
                    IsSuccess = false,
                    Message = "Error encounter while cancelling your subscription",
                    Time = DateTime.Now
                });
            }
        }


    }
}
