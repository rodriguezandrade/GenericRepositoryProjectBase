using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    { 
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Save(Category model);
        Task<Category> DeleteByName(string name);
        Task<Category> Modify(Category model);
        Task<Category> GetById(Guid id);
    }
}
