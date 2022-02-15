using CoreApp102.Core.Repository;
using System.Threading.Tasks;

namespace CoreApp102.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository product { get; }

        ICategoryRepository category { get; }

        Task CommitAsync();
        void Commit();
    }
}
