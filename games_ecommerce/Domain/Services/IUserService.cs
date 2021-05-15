using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Services
{
    public interface IUserService
    {
        public Task<UserResponse> SaveAsync(User user);
        public Task<UserResponse> UpdateAsync(int id, User user);
        public Task<UserResponse> DeleteAsync(int id);
        public Task<User> FindByIdAsync(int id);
        public Task<IEnumerable<User>> ListAsync();
    }
}
