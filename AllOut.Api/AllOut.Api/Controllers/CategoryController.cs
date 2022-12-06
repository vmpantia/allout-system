using AllOut.Api.Contractors;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AllOut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;
        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet("GetCategorys")]
        public async Task<IActionResult> GetCategorysAsync()
        {
            try
            {
                var response = await _category.GetCategorysAsync();
                return Ok(response);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryByID/{id}")]
        public async Task<IActionResult> GetCategoryIDAsync(Guid id)
        {
            try
            {
                var response = await _category.GetCategoryByIDAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> SaveCategoryAsync(CategoryRequest request)
        {
            try
            {
                var response = await _category.SaveCategoryAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
