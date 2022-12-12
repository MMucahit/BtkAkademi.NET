using Repositories.Abstracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        // Dependency Injection
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly RepositoryContext _context;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _productRepository = new ProductRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }
        //
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
