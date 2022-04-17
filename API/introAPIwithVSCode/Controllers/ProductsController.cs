using introAPIwithVSCode.Models;
using Microsoft.AspNetCore.Mvc;

namespace introAPIwithVSCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts(){
            var products = new List<Product>(){
                new Product{Id=1, Name="Product 1", Description="Product 1 description", Price=10, CategoryId=1, ImageUrl="https://picsum.photos/200/300"},
                new Product{Id=2, Name="Product 2", Description="Product 2 description", Price=20, CategoryId=2, ImageUrl="https://picsum.photos/200/300"},
                new Product{Id=3, Name="Product 3", Description="Product 3 description", Price=20, CategoryId=3, ImageUrl="https://picsum.photos/200/300"},
                new Product{Id=4, Name="Product 4", Description="Product 4 description", Price=20, CategoryId=4, ImageUrl="https://picsum.photos/200/300"},

            };

            return Ok(products);


            
        }

    }
}