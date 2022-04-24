using AutoMapper;
using Catalog.DataAccess.Repositories;
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
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private List<Product> products;

        
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<int> AddProduct(AddProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            product.CreatedAt = DateTime.Now;
            await productRepository.Add(product);
            return product.Id;
        }

        public async Task DeleteProduct(int id)
        {
           await productRepository.Delete(id);
           
        }

        public async Task<ProductDisplayResponse> GetProduct(int id)
        {
            var product = await productRepository.GetById(id);
            var productDisplayResponse = mapper.Map<ProductDisplayResponse>(product);
            return productDisplayResponse;                
        }
        

        public async Task<IList<ProductDisplayResponse>> GetProducts()
        {
            var products = await productRepository.GetAll();
            var result = mapper.Map<IList<ProductDisplayResponse>>(products);
            return result;
        }

        public async Task<IList<ProductDisplayResponse>> GetProductsByName(string key)
        {
            var products = await productRepository.GetProductsByName(key);
            var result = mapper.Map<IList<ProductDisplayResponse>>(products);
            return result;
        }

        public async Task<bool> IsProductExists(int id)
        {
           return await productRepository.IsExists(id);
        }

        public void SendProductReportWithEmail(string email)
        {
            //Send email
        }

        public async Task UpdateProduct(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.Update(product);
            
        }
    }
}
