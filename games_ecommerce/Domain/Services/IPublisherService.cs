using games_ecommerce.Domain.Models;
using games_ecommerce.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace games_ecommerce.Domain.Services
{
    public interface IPublisherService
    {
        public Task<PublisherResponse> SaveAsync(Publisher publisher);
        public Task<PublisherResponse> UpdateAsync(int id, Publisher publisher);
        public Task<PublisherResponse> DeleteAsync(int id);
        public Task<Publisher> FindByIdAsync(int id);
        public Task<IEnumerable<Publisher>> ListAsync();
    }
}
