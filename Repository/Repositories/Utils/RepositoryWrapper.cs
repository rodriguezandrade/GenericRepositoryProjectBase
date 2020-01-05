using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Utils
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ICategoryRepository  _categoryRepository;
        private IRepositoryWrapper  _repositoryWraper;
        private RepositoryContext _repositoryContext; 

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_repositoryContext, _repositoryWraper);
                }

                return _categoryRepository;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
