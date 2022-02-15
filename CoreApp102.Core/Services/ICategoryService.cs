using CoreApp102.Core.Models;
using System.Threading.Tasks;

namespace CoreApp102.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductByIdAsync(int catId);

    }
}
