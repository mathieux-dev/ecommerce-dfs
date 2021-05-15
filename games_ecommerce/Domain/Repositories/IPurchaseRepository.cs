using games_ecommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        public Task AddAsync(Purchase purchase);
        public void Update(Purchase purchase);
        public void Delete(Purchase purchase);
        public Task<Purchase> FindByIdAsync(int id);
        public Task<IEnumerable<Purchase>> ListAsync();
    }
}
