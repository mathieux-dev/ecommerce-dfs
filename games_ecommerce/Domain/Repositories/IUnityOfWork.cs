using System.Threading.Tasks;

namespace games_ecommerce.Domain.Repositories
{
    public interface IUnityOfWork
    {
        Task CompleteAsync();
    }
}
