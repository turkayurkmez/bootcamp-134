using AutoMapper;
using Catalog.DataAccess.Repositories;
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
             

        public async Task<IList<ProductDisplayResponse>> GetProducts()
        {
            var products = await productRepository.GetAll();
            var result = mapper.Map<IList<ProductDisplayResponse>>(products);
            return result;
        }
        public void SendProductReportWithEmail(string email)
        {
            //Send email
        }
    }
}
