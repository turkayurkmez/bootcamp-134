using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccess.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private List<User> _users;
        public FakeUserRepository()
        {
            _users = new List<User>()
            {
                new User() { Id = 1, FirstName = "John", Email= "a@test.com", Role= "Admin", Password="123", UserName="user1" },
                new User() { Id = 1, FirstName = "Mary", Email= "a@test.com", Role= "Editor", Password="123", UserName="user2" },
                new User() { Id = 1, FirstName = "Billy", Email= "a@test.com", Role= "Client", Password="123", UserName="user3" },


            };
        }
        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }

        public User ValidateUser(string username, string password)
        {
            return _users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
