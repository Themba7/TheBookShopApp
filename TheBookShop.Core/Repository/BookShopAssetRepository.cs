using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.Core.Repository.IRepository;
using TheBookShop.DataAccess.Data;
using TheBookShop.Models;

namespace TheBookShop.Core.Repository
{
    public class BookShopAssetRepository : IBookShopAssetRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BookShopAssetRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BookShopAssetDto>> CreateAsset(BookShopAssetDto newAssert)
        {
            try
            {
                var assert = _mapper.Map<BookShopAssetDto, BookShopAsset>(newAssert);
                var addedAssert = await _db.BookShopAssets.AddAsync(assert);
                await _db.SaveChangesAsync();

                var result = _mapper.Map<BookShopAsset, BookShopAssetDto>(addedAssert.Entity);

                return new ServiceResponse<BookShopAssetDto>
                {
                    IsSuccess = true,
                    Time = DateTime.Now,
                    Data = result,
                    Message = "New assert added"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<BookShopAssetDto>
                {
                    IsSuccess = false,
                    Data = newAssert,
                    Message = ex.Message,
                    Time = DateTime.Now
                };
            }
        }

        public async Task<ServiceResponse<IEnumerable<BookShopAssetDto>>> GetAllAsserts()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<BookShopAsset>, IEnumerable<BookShopAssetDto>>(await _db.BookShopAssets.ToListAsync());

                return new ServiceResponse<IEnumerable<BookShopAssetDto>>
                {
                    IsSuccess = true,
                    Time = DateTime.Now,
                    Data = result,
                    Message = "List of assets returned"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<BookShopAssetDto>>
                {
                    IsSuccess = false,
                    Data = Enumerable.Empty<BookShopAssetDto>(),
                    Message = ex.Message,
                    Time = DateTime.Now
                };
            }
            
        }

        public async Task<ServiceResponse<BookShopAssetDto>> GetAssertById(int id)
        {
            try
            {
                var assert = await _db.BookShopAssets.FirstOrDefaultAsync(x => x.Id == id);

                var result = _mapper.Map<BookShopAsset, BookShopAssetDto>(assert);

                return new ServiceResponse<BookShopAssetDto>
                {
                    IsSuccess = true,
                    Time = DateTime.Now,
                    Data = result,
                    Message = "Asset returned"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<BookShopAssetDto>
                {
                    IsSuccess = false,
                    Data = new BookShopAssetDto(),
                    Message = ex.Message,
                    Time = DateTime.Now
                };
            }
            
        }

        
    }
}
