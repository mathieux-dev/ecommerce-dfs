using games_ecommerce.Persistence.Context;

namespace games_ecommerce.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        private readonly DataAppContext _context;

        protected BaseRepository(DataAppContext context)
        {
            _context = context;
        }
    }
}
