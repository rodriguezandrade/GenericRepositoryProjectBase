using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/categories/")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("getAll")]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return await _categoryService.GetAll();
        } 

        [Route("save")]
        [HttpPost]
        public async Task <CategoryDto> Save([FromBody] CategoryDto category)
        {
            return await _categoryService.Save(category);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task <CategoryDto> DeleteByName([FromQuery] string name)
        {
            return await _categoryService.DeleteByName(name);
        }

        [Route("getById")]
        [HttpGet]
        public async Task<CategoryDto> GetById([FromQuery] Guid id)
        { 
            return await _categoryService.GetById(id);
        }
    }
}