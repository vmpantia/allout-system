using AllOut.Api.Contractors;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

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

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (ServiceException ex)
            {
                return Conflict(ex.Message);
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

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (ServiceException ex)
            {
                return Conflict(ex.Message);
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
            catch (ServiceException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
