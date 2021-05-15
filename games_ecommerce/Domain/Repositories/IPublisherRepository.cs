using games_ecommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Repositories
{
    public interface IPublisherRepository
    {
        public Task AddAsync(Publisher publisher);
        public void Update(Publisher publisher);
        public void Delete(Publisher publisher);
        public Task<Publisher> FindByIdAsync(int id);
        public Task<IEnumerable<Publisher>> ListAsync();
    }
}
