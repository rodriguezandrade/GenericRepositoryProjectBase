
using Repository.Models;
using System;
using System.Linq;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
        Category Save(Category category);
        Category DeleteByName(string name);
        Category Update(Category model);
        Category GetById(Guid id);
    }
}
