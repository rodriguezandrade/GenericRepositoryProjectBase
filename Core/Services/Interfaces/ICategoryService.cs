using Repository.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> Save(CategoryDto category);
        Task<CategoryDto> DeleteByName(string name);
        Task<CategoryDto> Update(CategoryDto model);
        Task<CategoryDto> GetById(Guid id);
    }
}
