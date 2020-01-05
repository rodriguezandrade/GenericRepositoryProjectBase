using Repository.Models;
using System;
using System.Linq;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IQueryable<Category> GetAll();
        Category Save(Category model);
        Category DeleteByName(string name);
        Category Modify(Category model);
        Category GetById(Guid id);
    }
}
