using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.Models;

namespace TheBookShop.Core.Repository.IRepository
{
    public interface IBookShopAssetRepository
    {
        Task<ServiceResponse<IEnumerable<BookShopAssetDto>>> GetAllAsserts();
        Task<ServiceResponse<BookShopAssetDto>> GetAssertById(int id);
        Task<ServiceResponse<BookShopAssetDto>> CreateAsset(BookShopAssetDto newAssert);

    }
}
