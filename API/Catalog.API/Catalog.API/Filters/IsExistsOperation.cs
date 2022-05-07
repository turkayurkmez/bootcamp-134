using Catalog.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.API.Filters
{
    public class IsExistsOperation : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public IsExistsOperation(IProductService productService)
        {
            this.productService = productService;
            
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id gereklidir"); 
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (!await productService.IsProductExists(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün bulunamadı" });
                }
                else
                {
                    await next.Invoke();
                }

               
            }

          
        }
    }
}
