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

        [HttpGet("GetProductsByStatus")]
        public async Task<IActionResult> GetProductsByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_PRODUCTS_BY_STATUS, clientID, status);
        }

        [HttpGet("GetProductByID")]
        public async Task<IActionResult> GetProductIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_PRODUCT_BY_ID, clientID, id);
        }

        [HttpGet("GetCountProducts")]
        public async Task<IActionResult> GetCountProductsAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_COUNT_PRODUCTS, clientID);
        }

        [HttpGet("GetCountProductsByStatus")]
        public async Task<IActionResult> GetCountProductsByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_COUNT_PRODUCTS_BY_STATUS, clientID, status);
        }

        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_PRODUCT, request.client.ClientID, request, request.FunctionID);
        }

        [HttpPost("UpdateProductStatusByIDs")]
        public async Task<IActionResult> UpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_PRODUCT_STATUS_BY_IDS, request.client.ClientID, request, request.FunctionID);
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
                    case RequestType.GET_PRODUCTS:
                        response = await _product.GetProductsAsync();
                        break;

                    case RequestType.GET_PRODUCTS_BY_QUERY:
                        response = await _product.GetProductsByQueryAsync((string)data);
                        break;

                    case RequestType.GET_PRODUCTS_BY_STATUS:
                        response = await _product.GetProductsByStatusAsync((int)data);
                        break;

                    case RequestType.GET_PRODUCT_BY_ID:
                        response = await _product.GetProductByIDAsync((Guid)data);
                        break;

                    case RequestType.GET_COUNT_PRODUCTS:
                        response = await _product.GetCountProductsAsync();
                        break;

                    case RequestType.GET_COUNT_PRODUCTS_BY_STATUS:
                        response = await _product.GetCountProductsByStatusAsync((int)data);
                        break;

                    case RequestType.POST_SAVE_PRODUCT:
                        response = await _product.SaveProductAsync((SaveProductRequest)data);
                        break;

                    case RequestType.POST_UPDATE_PRODUCT_STATUS_BY_IDS:
                        response = await _product.UpdateProductStatusByIDsAsync((UpdateStatusByIDsRequest)data);
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
