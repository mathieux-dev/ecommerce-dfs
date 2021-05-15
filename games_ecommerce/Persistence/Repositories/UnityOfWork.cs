using games_ecommerce.Domain.Repositories;
using games_ecommerce.Persistence.Context;
using System.Threading.Tasks;

namespace games_ecommerce.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DataAppContext _context;

        public UnityOfWork(DataAppContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
