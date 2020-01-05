using System;
using System.Linq;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

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
        public IQueryable<Category> Get()
        {
            return _categoryService.GetAll();
        } 

        [Route("save")]
        [HttpPost]
        public Category Save([FromBody] Category category)
        {
            return _categoryService.Save(category);
        }

        [Route("delete")]
        [HttpDelete]
        public Category DeleteByName([FromQuery] string name)
        {
            return _categoryService.DeleteByName(name);
        }

        [Route("getById")]
        [HttpGet]
        public Category GetById([FromQuery] Guid id)
        { 
            return _categoryService.GetById(id);
        }
    }
}