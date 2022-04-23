using Catalog.DataAccess.Repositories;
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
        private readonly IProductRepository productRepository;
        private List<Product> products;

        
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
             

        public async Task<IList<Product>> GetProducts()
        {
            return await productRepository.GetAll();
        }
        public void SendProductReportWithEmail(string email)
        {
            //Send email
        }
    }
}
