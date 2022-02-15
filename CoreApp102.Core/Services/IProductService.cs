using CoreApp102.Core.Models;
using System.Threading.Tasks;

namespace CoreApp102.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithByIdAsync(int proId);

        //Product ile ilgili tanimlamam gereken ic metodlarim var ise onlari bu servis katmaninda yazabilirim.
    }
}
