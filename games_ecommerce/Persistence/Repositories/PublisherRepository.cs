using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Repositories;
using games_ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Persistence.Repositories
{
    public class PublisherRepository : BaseRepository, IPublisherRepository
    {
        private readonly DataAppContext _context;

        public PublisherRepository(DataAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
        }

        public void Update(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
        }

        public void Delete(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
        }

        public async Task<Publisher> FindByIdAsync(int id)
        {
            var companyWithProducts = _context.Publishers.Include(publisher => publisher.Products).AsNoTracking();
            return await companyWithProducts.FirstOrDefaultAsync(publisher => publisher.Id == id);
        }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await _context.Publishers.ToListAsync();
        }
    }
}