using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
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

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return await ProcessRequest(RequestType.GET_CATEGORIES);
        }

        [HttpGet("GetCategoriesByQuery/{query}")]
        public async Task<IActionResult> GetCategoriesByQueryAsync(string query)
        {
            return await ProcessRequest(RequestType.GET_CATEGORIES_BY_QUERY, query);
        }

        [HttpGet("GetCategoryByID/{id}")]
        public async Task<IActionResult> GetCategoryIDAsync(Guid id)
        {
            return await ProcessRequest(RequestType.GET_CATEGORY_BY_ID, id);
        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> SaveCategoryAsync(SaveCategoryRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_CATEGORY, request);
        }

        [HttpPost("UpdateCategoryStatusByIDs")]
        public async Task<IActionResult> UpdateCategoryStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_CATEGORY_STATUS_BY_IDS, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, object? request = null)
        {
            try
            {
                object? response = null;

                if (type == RequestType.GET_CATEGORIES)
                {
                    response = await _category.GetCategoriesAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new ControllerException(string.Format(Constants.ERROR_OBJECT_REQUEST_NULL, Constants.OBJECT_CATEGORY));

                    switch (type)   
                    {
                        case RequestType.GET_CATEGORIES_BY_QUERY:
                            response = await _category.GetCategoriesByQueryAsync((string)request);
                            break;

                        case RequestType.GET_CATEGORY_BY_ID:
                            response = await _category.GetCategoryByIDAsync((Guid)request);
                            break;

                        case RequestType.POST_SAVE_CATEGORY:
                            response = await _category.SaveCategoryAsync((SaveCategoryRequest)request);
                            break;

                        case RequestType.POST_UPDATE_CATEGORY_STATUS_BY_IDS:
                            response = await _category.UpdateCategoryStatusByIDsAsync((UpdateStatusByIDsRequest)request);
                            break;
                    }
                }

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
    }
}
