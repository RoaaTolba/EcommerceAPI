using ecommerceAPI.Application.DTOs.Category;
using ecommerceAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            this._service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> ShowAllCategories()
        {
            var categories =await _service.GetAllCategoriesAsync();
            return Ok(categories);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> AddNewCategoryAsync(CreateCategoryDto categoryDTO)
        {
            if (categoryDTO == null)
                return NotFound();
            var cate = await _service.AddCategoryAsync(categoryDTO);
            return Ok(cate);
        }
    }
}
