using games_ecommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task AddAsync(User user);
        public void Update(User user);
        public void Delete(User user);
        public Task<User> FindByIdAsync(int id);
        public Task<IEnumerable<User>> ListAsync();
    }
}
