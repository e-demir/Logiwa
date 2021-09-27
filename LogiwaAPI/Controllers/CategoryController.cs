using LogiwaAPI.Models;
using LogiwaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaAPI.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryRepository.GetAllCategories());
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{id}")]
        public IActionResult GetCategory(int id)
        {
            var product = _categoryRepository.GetCategory(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"The category with Id: {id} was not found ");
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public IActionResult AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.CategoryId, category);
        }

        [HttpPost]
        [Route("api/[controller]/[action]/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (category != null)
            {
                _categoryRepository.DeleteCategory(category);
                return Ok();
            }

            return NotFound($"The category with Id: {id} was not found ");
        }

        [HttpPost]
        [Route("api/[controller]/[action]/{id}")]
        public IActionResult EditCategory(int id, Category category)
        {
            var existingProduct =  _categoryRepository.GetCategory(id);

            if (existingProduct != null)
            {
                category.CategoryId = existingProduct.CategoryId;
                _categoryRepository.EditCategory(category);
            }

            return Ok(category);
        }




    }
}
