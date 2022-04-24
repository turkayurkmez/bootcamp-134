using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccess.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> products;
        public FakeProductRepository()
        {
            products = new List<Product>
            {
                 new Product{ Id = 1, Name = "Product 1", Price = 100, CategoryId = 1, Description= "Product 1 description", ImageUrl="http://placehold.it/300x300"},
                 new Product{ Id = 2, Name = "Product 2", Price = 200, CategoryId = 1, Description= "Product 2 description", ImageUrl="http://placehold.it/300x300"},
                 new Product{ Id = 3, Name = "Product 3", Price = 300, CategoryId = 1, Description= "Product 3 description", ImageUrl="http://placehold.it/300x300"},
                 new Product{ Id = 4, Name = "Product 4", Price = 400, CategoryId = 1, Description= "Product 4 description", ImageUrl="http://placehold.it/300x300"},
                 new Product{ Id = 5, Name = "Product 5", Price = 500, CategoryId = 1, Description= "Product 5 description", ImageUrl="http://placehold.it/300x300"},

            };
        }

        public Task Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<Product> IRepository<Product>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
    
}
