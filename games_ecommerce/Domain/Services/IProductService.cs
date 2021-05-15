using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Services
{
    public interface IProductService
    {
        public Task<ProductResponse> SaveAsync(Product product);
        public Task<ProductResponse> UpdateAsync(int id, Product product);
        public Task<ProductResponse> DeleteAsync(int id);
        public Task<Product> FindByIdAsync(int id);
        public Task<IEnumerable<Product>> ListAsync();
    }
}
