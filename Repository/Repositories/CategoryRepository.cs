using Repository.Data;
using Repository.Repositories.Utils;
using Repository.Repositories.Interfaces;
using Repository.Models;
using System.Linq;
using System;

namespace Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryRepository
           (
            RepositoryContext repositoryContext,
            IRepositoryWrapper repositoryWrapper
           )
             : base(repositoryContext)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Category> GetAll()
        {
            return _repositoryWrapper.Category.FindAll();
        }

        public Category Save(Category model)
        {
            _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.save();

            return model;
        }

        public Category DeleteByName(string name)
        {
            var modelToEliminate = _repositoryWrapper.Category
                                    .FindByCondition(x => x.Name == name)
                                    .Where(x => x.Name == name)
                                    .FirstOrDefault();

            _repositoryWrapper.Category.Delete(modelToEliminate);
            _repositoryWrapper.save();

            return modelToEliminate;
        }

        public Category Modify(Category model)
        {

            var entity = _repositoryWrapper.Category.FindByCondition(item => item.CategoryId == model.CategoryId).FirstOrDefault();
            entity.Name = model.Name;

            _repositoryWrapper.Category.Update(entity);
            _repositoryWrapper.save();

            return model;
        }

        public Category GetById(Guid id)
        { 
            return _repositoryWrapper.Category.FindByCondition(item => item.CategoryId == id).FirstOrDefault();
        }
    }
}
