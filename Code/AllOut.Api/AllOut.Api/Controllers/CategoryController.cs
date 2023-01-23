using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;
        private readonly IUtilityService _utility;
        public CategoryController(ICategoryService category, IUtilityService utility)
        {
            _category = category;
            _utility = utility;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_CATEGORIES, clientID);
        }

        [HttpGet("GetCategoriesByQuery")]
        public async Task<IActionResult> GetBrandsByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_CATEGORIES_BY_QUERY, clientID, query);
        }

        [HttpGet("GetCategoriesByStatus")]
        public async Task<IActionResult> GetCategoriesByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_CATEGORIES_BY_STATUS, clientID, status);
        }

        [HttpGet("GetCategoryByID")]
        public async Task<IActionResult> GetCategoryIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_CATEGORY_BY_ID, clientID, id);
        }

        [HttpGet("GetCountCategories")]
        public async Task<IActionResult> GetCountCategoriesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_COUNT_CATEGORIES, clientID);
        }

        [HttpGet("GetCountCategoriesByStatus")]
        public async Task<IActionResult> GetCountCategoriesByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_COUNT_CATEGORIES_BY_STATUS, clientID, status);
        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> SaveCategoryAsync(SaveCategoryRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_CATEGORY, request.client.ClientID, request, request.FunctionID);
        }

        [HttpPost("UpdateCategoryStatusByIDs")]
        public async Task<IActionResult> UpdateCategoryStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_CATEGORY_STATUS_BY_IDS, request.client.ClientID, request, request.FunctionID);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object data = null, string functionID = null)
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClientID(clientID, type, functionID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                switch (type)
                {
                    case RequestType.GET_CATEGORIES:
                        response = await _category.GetCategoriesAsync();
                        break;

                    case RequestType.GET_CATEGORIES_BY_QUERY:
                        response = await _category.GetCategoriesByQueryAsync((string)data);
                        break;

                    case RequestType.GET_CATEGORIES_BY_STATUS:
                        response = await _category.GetCategoriesByStatusAsync((int)data);
                        break;

                    case RequestType.GET_CATEGORY_BY_ID:
                        response = await _category.GetCategoryByIDAsync((Guid)data);
                        break;

                    case RequestType.GET_COUNT_CATEGORIES:
                        response = await _category.GetCountCategoriesAsync();
                        break;

                    case RequestType.GET_COUNT_CATEGORIES_BY_STATUS:
                        response = await _category.GetCountCategoriesByStatusAsync((int)data);
                        break;

                    case RequestType.POST_SAVE_CATEGORY:
                        response = await _category.SaveCategoryAsync((SaveCategoryRequest)data);
                        break;

                    case RequestType.POST_UPDATE_CATEGORY_STATUS_BY_IDS:
                        response = await _category.UpdateCategoryStatusByIDsAsync((UpdateStatusByGUIDsRequest)data);
                        break;
                }

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
