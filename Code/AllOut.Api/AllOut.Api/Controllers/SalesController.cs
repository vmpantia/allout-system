using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _sales;
        private readonly IUtilityService _utility;
        public SalesController(ISalesService sales, IUtilityService utility)
        {
            _sales = sales;
            _utility = utility;
        }

        [HttpGet("GetSales")]
        public async Task<IActionResult> GetSalesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_SALES, clientID);
        }

        [HttpGet("GetSalesByQuery")]
        public async Task<IActionResult> GetSalesByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_SALES_BY_QUERY, clientID, query);
        }

        [HttpGet("GetSalesByStatus")]
        public async Task<IActionResult> GetSalesByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_SALES_BY_STATUS, clientID, status);
        }

        [HttpGet("GetSalesByID")]
        public async Task<IActionResult> GetSalesByIDAsync(Guid clientID, string id)
        {
            return await ProcessRequest(RequestType.GET_SALES_BY_ID, clientID, id);
        }

        [HttpGet("GetCountSales")]
        public async Task<IActionResult> GetCountSalesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_COUNT_SALES, clientID);
        }

        [HttpGet("GetCountSalesByStatus")]
        public async Task<IActionResult> GetCountSalesByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_COUNT_SALES_BY_STATUS, clientID, status);
        }

        [HttpPost("SaveSales")]
        public async Task<IActionResult> SaveSalesAsync(SaveSalesRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_SALES, request.client.ClientID, request, request.FunctionID);
        }

        [HttpPost("UpdateSalesStatusByIDs")]
        public async Task<IActionResult> UpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_SALES_STATUS_BY_IDS, request.client.ClientID, request, request.FunctionID);
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
                    case RequestType.GET_SALES:
                        response = await _sales.GetSalesAsync();
                        break;

                    case RequestType.GET_SALES_BY_QUERY:
                        response = await _sales.GetSalesByQueryAsync((string)data);
                        break;

                    case RequestType.GET_SALES_BY_STATUS:
                        response = await _sales.GetSalesByStatusAsync((int)data);
                        break;

                    case RequestType.GET_SALES_BY_ID:
                        response = await _sales.GetSalesByIDAsync((string)data);
                        break;

                    case RequestType.GET_COUNT_SALES:
                        response = await _sales.GetCountSalesAsync();
                        break;

                    case RequestType.GET_COUNT_SALES_BY_STATUS:
                        response = await _sales.GetCountSalesByStatusAsync((int)data);
                        break;

                    case RequestType.POST_SAVE_SALES:
                        response = await _sales.SaveSalesAsync((SaveSalesRequest)data);
                        break;

                    case RequestType.POST_UPDATE_SALES_STATUS_BY_IDS:
                        response = await _sales.UpdateSalesStatusByIDsAsync((UpdateStatusByStringIDsRequest)data);
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
