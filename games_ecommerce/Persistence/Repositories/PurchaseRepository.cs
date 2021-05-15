using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Repositories;
using games_ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Persistence.Repositories
{
    public class PurchaseRepository : BaseRepository, IPurchaseRepository
    {
        private readonly DataAppContext _context;

        public PurchaseRepository(DataAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
        }

        public void Update(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
        }

        public void Delete(Purchase purchase)
        {
            _context.Purchases.Remove(purchase);
        }

        public async Task<Purchase> FindByIdAsync(int id)
        {
            var purchasesWithProducts = _context.Purchases.Include(purchase => purchase.Products).AsNoTracking();
            return await purchasesWithProducts.FirstOrDefaultAsync(purchase => purchase.Id == id);
        }

        public async Task<IEnumerable<Purchase>> ListAsync()
        {
            return await _context.Purchases.ToListAsync();
        }
    }
}
