using CoreApp102.Core.Repository;
using CoreApp102.Core.UnitOfWork;
using CoreApp102.Data.Repository;
using System.Threading.Tasks;

namespace CoreApp102.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public IProductRepository product => _productRepository ??= new ProductRepository(_db);

        public ICategoryRepository category => _categoryRepository ??= new CategoryRepository(_db);

        public void Commit()
        {
            _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
