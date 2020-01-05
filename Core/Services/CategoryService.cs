using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IQueryable<Category> GetAll()
        { 
            return _categoryRepository.FindAll();
        } 
         
        public Category Save(Category category)
        {
             return _categoryRepository.Save(category);
        }

        public Category DeleteByName(string name)
        { 
            return _categoryRepository.DeleteByName(name);
        }


        public Category Update(Category model)
        {
            return _categoryRepository.Modify(model);
        }

        public Category GetById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }
    }
}
