using Catalog.API.Filters;
using Catalog.API.Models;
using Catalog.Business;
using Catalog.DataTransferObjects.Requests;
using Catalog.DataTransferObjects.Responses;
using Catalog.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IMemoryCache memoryCache;

        public ProductsController(IProductService productService, IMemoryCache memoryCache)
        {
            service = productService;
            this.memoryCache = memoryCache;
        }

        private DateTime cacheTime = DateTime.Now;

        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetProducts()
        {


            ///memoryCache.GetOrCreateAsync<>

            if (!memoryCache.TryGetValue("productsCache", out CacheProofModel proof))
            {
                var entryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5))
                                                                .RegisterPostEvictionCallback((key, value, reason, state) =>
                                                                {
                                                                    //memory cache içinden bir data çıkarıldığında çalışmasını istediğiniz işlemleri burada yazacaksınız;
                                                                });

                memoryCache.Set("productsCache", new CacheProofModel { Products = await service.GetProducts(), CacheTime = DateTime.Now }, DateTime.Now.AddMinutes(1));
                proof = new CacheProofModel { Products = await service.GetProducts(), CacheTime = DateTime.Now };

            }


            return Ok(proof);
        }

        [HttpGet("{id}")]
        [IsExists]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProductDisplayResponse product = await service.GetProduct(id);
            return Ok(product);
        }
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await service.GetProductsByName(key);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int productId = await service.AddProduct(request);
                return CreatedAtAction(nameof(GetProductById), routeValues: new { id = productId }, value: null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            //if (await service.IsProductExists(id))
            //{
            if (ModelState.IsValid)
            {
                await service.UpdateProduct(request);
                return Ok();
            }
            return BadRequest(ModelState);
            //}
            //return NotFound(new { message = $"{id} id'li ürün bulunamadı" });

        }

        [HttpDelete("{id}")]
        [CustomException(Order = 1)]
        [IsExists(Order = 2)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0 || id > 200)
            {
                throw new ArgumentException("id değeri negatif olamaz!");
            }
            await service.DeleteProduct(id);
            return Ok();
        }
    }
}
