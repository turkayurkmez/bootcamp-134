using Catalog.API.Filters;
using Catalog.Business;
using Catalog.DataTransferObjects.Requests;
using Catalog.DataTransferObjects.Responses;
using Catalog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService productService)
        {
            service = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {

            var products = await service.GetProducts();
            return Ok(products);
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
        [IsExists(Order =2)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id<0 || id > 200)
            {
                throw new ArgumentException("id değeri negatif olamaz!");
            }
            await service.DeleteProduct(id);
            return Ok();
        }
    }
}
