using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
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
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProductsAsync()
        {
            return await ProcessRequest(RequestType.GET_PRODUCTS);
        }

        [HttpGet("GetProductsByQuery/{query}")]
        public async Task<IActionResult> GetProductsByQueryAsync(string query)
        {
            return await ProcessRequest(RequestType.GET_PRODUCTS_BY_QUERY, query);
        }

        [HttpGet("GetProductByID/{id}")]
        public async Task<IActionResult> GetProductIDAsync(Guid id)
        {
            return await ProcessRequest(RequestType.GET_PRODUCT_BY_ID, id);
        }

        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProductAsync(SaveProductRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_PRODUCT, request);
        }

        [HttpPost("UpdateProductStatusByIDs")]
        public async Task<IActionResult> UpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_PRODUCT_STATUS_BY_IDS, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, object? request = null)
        {
            try
            {
                object? response = null;

                if (type == RequestType.GET_PRODUCTS)
                {
                    response = await _product.GetProductsAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new ControllerException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_PRODUCT));

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
