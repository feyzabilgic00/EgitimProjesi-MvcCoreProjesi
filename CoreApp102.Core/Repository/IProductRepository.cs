using CoreApp102.Core.Models;
using System.Threading.Tasks;

namespace CoreApp102.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithByIdAsync(int proId);
    }
}
