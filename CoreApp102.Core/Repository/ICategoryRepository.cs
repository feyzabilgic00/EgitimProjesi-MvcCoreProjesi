using CoreApp102.Core.Models;
using System.Threading.Tasks;

namespace CoreApp102.Core.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductByIdAsync(int catId);
    }
}
