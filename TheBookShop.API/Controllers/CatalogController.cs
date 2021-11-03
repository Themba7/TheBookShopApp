using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBookShop.Core.Repository.IRepository;

namespace TheBookShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CatalogController : Controller
    {
        private readonly IBookShopAssetRepository _assetRepository;

        public CatalogController(IBookShopAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatalog()
        {
            var catalog = await _assetRepository.GetAllAsserts();
            return Ok(catalog);
        }

        [HttpGet("{id}")]
        //[Authorize] // add this back once auth is fixed client side
        public async Task<IActionResult> GetAssetById(int id)
        {
            var asset = await _assetRepository.GetAssertById(id);

            return Ok(asset);
        }
    }
}
