using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace games_ecommerce.Persistence.Context
{
    public class DataAppContextFactory : IDesignTimeDbContextFactory<DataAppContext>
    {
        public DataAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataAppContext>();

            optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=postgres; password=postgres; database=ecommerce;");
            return new DataAppContext(optionsBuilder.Options);
        }
    }
}
