using Repository.Data;
using Repository.Repositories.Utils;
using Repository.Repositories.Interfaces;
using Repository.Models;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll().ToListAsync();
        }

        public async Task<Category> Save(Category model)
        {
            _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.save();

            return model;
        }

        public async Task<Category> DeleteByName(string name)
        {
            var modelToEliminate = await _repositoryWrapper.Category
                                    .FindByCondition(x => x.Name == name)
                                    .Where(x => x.Name == name)
                                    .FirstOrDefaultAsync();

            _repositoryWrapper.Category.Delete(modelToEliminate);
            _repositoryWrapper.save();

            return modelToEliminate;
        }

        public async Task<Category> Modify(Category model)
        {

            var entity = await _repositoryWrapper.Category.FindByCondition(item => item.Id == model.Id).FirstOrDefaultAsync();
            entity.Name = model.Name;

            _repositoryWrapper.Category.Update(entity);
            _repositoryWrapper.save();

            return model;
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _repositoryWrapper.Category.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
        }
    }
}
