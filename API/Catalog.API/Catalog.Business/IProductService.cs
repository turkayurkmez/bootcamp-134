using Catalog.DataTransferObjects.Requests;
using Catalog.DataTransferObjects.Responses;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Business
{
    public interface IProductService
    {
        Task<IList<ProductDisplayResponse>> GetProducts();
        Task<ProductDisplayResponse> GetProduct(int id);
        Task<IList<ProductDisplayResponse>> GetProductsByName(string key);
        Task<int> AddProduct(AddProductRequest request);
        Task UpdateProduct(UpdateProductRequest request);
        Task DeleteProduct(int id);
        Task<bool> IsProductExists(int id);
    }
}
