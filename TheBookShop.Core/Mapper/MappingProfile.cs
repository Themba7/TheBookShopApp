using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.DataAccess.Data;
using TheBookShop.Models;

namespace TheBookShop.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookShopAssetDto, BookShopAsset>().ReverseMap();
            CreateMap<SubscriptionDto, Subscription>().ReverseMap();
        }
    }
}
