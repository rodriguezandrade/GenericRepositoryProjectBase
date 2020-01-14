using AutoMapper;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILoggerManager logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var result= await _categoryRepository.GetAll();
            return _mapper.Map<IQueryable<CategoryDto>>(result);
        } 
         
        public async Task<CategoryDto> Save(CategoryDto category)
        {
            _logger.LogInfo("Here is info message from the service.");
            _logger.LogDebug("Here is debug message from the service.");
            _logger.LogWarn("Here is warn message from the service.");
            _logger.LogError("Here is error message from the service.");

            return _mapper.Map<CategoryDto>(await _categoryRepository.Save(_mapper.Map<Category>(category)));
        }

        public async Task<CategoryDto> DeleteByName(string name)
        { 
            return _mapper.Map<CategoryDto>(await _categoryRepository.DeleteByName(name));
        }


        public async Task<CategoryDto> Update(CategoryDto model)
        {
            return _mapper.Map<CategoryDto>(await _categoryRepository.Modify(_mapper.Map<Category>(model)));
        }

        public async Task<CategoryDto> GetById(Guid id)
        {
            return _mapper.Map<CategoryDto>(await _categoryRepository.GetById(id));
        }
    }
}
