using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brand;
        private readonly IUtilityService _utility;
        public BrandController(IBrandService brand, IUtilityService utility)
        {
            _brand = brand;
            _utility = utility;
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrandsAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_BRANDS, clientID);
        }

        [HttpGet("GetBrandsByQuery")]
        public async Task<IActionResult> GetBrandsByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_BRANDS_BY_QUERY, clientID, query);
        }

        [HttpGet("GetBrandsByStatus")]
        public async Task<IActionResult> GetBrandsByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_BRANDS_BY_STATUS, clientID, status);
        }

        [HttpGet("GetBrandByID")]
        public async Task<IActionResult> GetBrandIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_BRAND_BY_ID, clientID, id);
        }

        [HttpGet("GetCountBrands")]
        public async Task<IActionResult> GetCountBrandsAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_COUNT_BRANDS, clientID);
        }

        [HttpGet("GetCountBrandsByStatus")]
        public async Task<IActionResult> GetCountBrandsByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_COUNT_BRANDS_BY_STATUS, clientID, status);
        }

        [HttpPost("SaveBrand")]
        public async Task<IActionResult> SaveBrandAsync(SaveBrandRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_BRAND, request.client.ClientID, request, request.FunctionID);
        }

        [HttpPost("UpdateBrandStatusByIDs")]
        public async Task<IActionResult> UpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_BRAND_STATUS_BY_IDS, request.client.ClientID, request, request.FunctionID);
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
                    case RequestType.GET_BRANDS:
                        response = await _brand.GetBrandsAsync();
                        break;

                    case RequestType.GET_BRANDS_BY_QUERY:
                        response = await _brand.GetBrandsByQueryAsync((string)data);
                        break;

                    case RequestType.GET_BRANDS_BY_STATUS:
                        response = await _brand.GetBrandsByStatusAsync((int)data);
                        break;

                    case RequestType.GET_BRAND_BY_ID:
                        response = await _brand.GetBrandByIDAsync((Guid)data);
                        break;

                    case RequestType.GET_COUNT_BRANDS:
                        response = await _brand.GetCountBrandsAsync();
                        break;

                    case RequestType.GET_COUNT_BRANDS_BY_STATUS:
                        response = await _brand.GetCountBrandsByStatusAsync((int)data);
                        break;

                    case RequestType.POST_SAVE_BRAND:
                        response = await _brand.SaveBrandAsync((SaveBrandRequest)data);
                        break;

                    case RequestType.POST_UPDATE_BRAND_STATUS_BY_IDS:
                        response = await _brand.UpdateBrandStatusByIDsAsync((UpdateStatusByIDsRequest)data);
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
