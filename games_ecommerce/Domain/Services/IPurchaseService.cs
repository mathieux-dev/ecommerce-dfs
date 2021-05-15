using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Services
{
    public interface IPurchaseService
    {
        public Task<PurchaseResponse> SaveAsync(Purchase purchase);
        public Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase);
        public Task<PurchaseResponse> DeleteAsync(int id);
        public Task<Purchase> FindByIdAsync(int id);
        public Task<IEnumerable<Purchase>> ListAsync();
    }
}
