using Catalog.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        //public IProductService ProductService { get; set; }
        public IsExistsAttribute() : base(typeof(IsExistsOperation))
        {
                        
        }
        
    }
}
