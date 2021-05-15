using games_ecommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        public Task AddAsync(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public Task<Product> FindByIdAsync(int id);
        public Task<IEnumerable<Product>> ListAsync();
    }
}
