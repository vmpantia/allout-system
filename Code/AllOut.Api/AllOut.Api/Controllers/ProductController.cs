using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        private readonly IUtilityService _utility;
        public ProductController(IProductService product, IUtilityService utility)
        {
            _product = product;
            _utility = utility;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProductsAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_PRODUCTS, clientID);
        }

        [HttpGet("GetProductsByQuery")]
        public async Task<IActionResult> GetProductsByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_PRODUCTS_BY_QUERY, clientID, query);
        }

        [HttpGet("GetProductByID")]
        public async Task<IActionResult> GetProductIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_PRODUCT_BY_ID, clientID, id);
        }

        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_PRODUCT, request.client.ClientID, request);
        }

        [HttpPost("UpdateProductStatusByIDs")]
        public async Task<IActionResult> UpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_PRODUCT_STATUS_BY_IDS, request.client.ClientID, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object? request = null)
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClientID(clientID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                if (type == RequestType.GET_PRODUCTS)
                {
                    response = await _product.GetProductsAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_PRODUCT));

                    switch (type)
                    {
                        case RequestType.GET_PRODUCTS_BY_QUERY:
                            response = await _product.GetProductsByQueryAsync((string)request);
                            break;

                        case RequestType.GET_PRODUCT_BY_ID:
                            response = await _product.GetProductByIDAsync((Guid)request);
                            break;

                        case RequestType.POST_SAVE_PRODUCT:
                            response = await _product.SaveProductAsync((SaveProductRequest)request);
                            break;

                        case RequestType.POST_UPDATE_PRODUCT_STATUS_BY_IDS:
                            response = await _product.UpdateProductStatusByIDsAsync((UpdateStatusByIDsRequest)request);
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
