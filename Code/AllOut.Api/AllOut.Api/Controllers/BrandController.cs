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

        [HttpGet("GetBrandByID")]
        public async Task<IActionResult> GetBrandIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_BRAND_BY_ID, clientID, id);
        }

        [HttpPost("SaveBrand")]
        public async Task<IActionResult> SaveBrandAsync(SaveBrandRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_BRAND, request.client.ClientID, request);
        }

        [HttpPost("UpdateBrandStatusByIDs")]
        public async Task<IActionResult> UpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_BRAND_STATUS_BY_IDS, request.client.ClientID, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID,  object? request = null)
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClientID(clientID);
                if(!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                if (type == RequestType.GET_BRANDS)
                {
                    response = await _brand.GetBrandsAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_BRAND));

                    switch(type)
                    {
                        case RequestType.GET_BRANDS_BY_QUERY:
                            response = await _brand.GetBrandsByQueryAsync((string)request);
                            break;

                        case RequestType.GET_BRAND_BY_ID:
                            response = await _brand.GetBrandByIDAsync((Guid)request);
                            break;

                        case RequestType.POST_SAVE_BRAND:
                            response = await _brand.SaveBrandAsync((SaveBrandRequest)request);
                            break;

                        case RequestType.POST_UPDATE_BRAND_STATUS_BY_IDS:
                            response = await _brand.UpdateBrandStatusByIDsAsync((UpdateStatusByIDsRequest)request);
                            break;
                    }
                }

                if (response == null)
                {
                    await _utility.LogClientRequest(clientID, type, Constants.STATUS_CODE_NOTFOUND);
                    return NotFound();
                }

                await _utility.LogClientRequest(clientID, type, Constants.STATUS_CODE_OK);
                return Ok(response);
            }
            catch (Exception ex)
            {
                await _utility.LogClientRequest(clientID, type, Constants.STATUS_CODE_CONFLICT);
                return Conflict(ex.Message);
            }
        }

    }
}
