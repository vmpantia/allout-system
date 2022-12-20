using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using AllOut.Common;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brand;
        public BrandController(IBrandService Brand)
        {
            _brand = Brand;
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrandsAsync()
        {
            return await ProcessRequest(RequestType.GET_BRANDS);
        }

        [HttpGet("GetBrandsByQuery/{query}")]
        public async Task<IActionResult> GetBrandsByQueryAsync(string query)
        {
            return await ProcessRequest(RequestType.GET_BRANDS_BY_QUERY, query);
        }

        [HttpGet("GetBrandByID/{id}")]
        public async Task<IActionResult> GetBrandIDAsync(Guid id)
        {
            return await ProcessRequest(RequestType.GET_BRAND_BY_ID, id);
        }

        [HttpPost("SaveBrand")]
        public async Task<IActionResult> SaveBrandAsync(SaveBrandRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_BRAND, request);
        }

        [HttpPost("UpdateBrandStatusByIDs")]
        public async Task<IActionResult> UpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_BRAND_STATUS_BY_IDS, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, object? request = null)
        {
            try
            {
                object? response = null;

                if (type == RequestType.GET_BRANDS)
                {
                    response = await _brand.GetBrandsAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new ControllerException(string.Format(Constants.ERROR_OBJECT_REQUEST_NULL, Constants.OBJECT_BRAND));

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
