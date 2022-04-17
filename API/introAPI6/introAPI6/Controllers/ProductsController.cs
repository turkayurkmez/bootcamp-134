using introAPI6.Models;
using introAPI6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace introAPI6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products;

        private ProductsService productsService; 
        public ProductsController()
        {
            productsService = new ProductsService();
            //products = new List<Product>
            //{
            //   new Product {Id=1, Description="Product 1", Price=10, Discount=0.1, ImageUrl="https://picsum.photos/200/300", Name="Product 1", Stock=100},
            //   new Product {Id=2, Description="Product 2", Price=10, Discount=0.1, ImageUrl="https://picsum.photos/200/300", Name="Product 2", Stock=100},
            //   new Product {Id=4, Description="Product 4", Price=10, Discount=0.1, ImageUrl="https://picsum.photos/200/300", Name="Product 3", Stock=100},
            //   new Product {Id=5, Description="Product 5", Price=10, Discount=0.1, ImageUrl="https://picsum.photos/200/300", Name="Product 4", Stock=100},
            //   new Product {Id=3, Description="Product 3", Price=10, Discount=0.1, ImageUrl="https://picsum.photos/200/300", Name="Product 5", Stock=100},


            //};
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = productsService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product) 
        {
            //Model Binder, Http request body'sinden gelen verileri Product nesnesine dönüştürür.
            if (ModelState.IsValid)
            {
                productsService.Create(product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = 5 }, value: product);
                //StatusCodes.
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute]int id)
        {
            var product = productsService.GetById(id);
            if (product == null)
            {
                return NotFound(new { message = $"{id} numaralı ürün bulunamadı" });
            }
            return Ok(product);

        }
        
        
         

    }

    //[HttpGet]
    //public IActionResult SearchProductByName(string name)
    //{
    //    return Ok();
    //}

}

