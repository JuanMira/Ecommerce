using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Attributes;
using Ecommerce.Repository;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("/category")]
    [Authorize]
    [RoleIdentifier(Role = "Admin")]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public IActionResult CreateCategory(CategorySerializer category)
        {
            var created = _categoryRepository.CreateCategory(category.CategoryName);
            return created ? Ok() : BadRequest();
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categorys = _categoryRepository.GetCategories();
            return Ok(categorys);
        }
    }
}