﻿using AllOut.Api.Common;
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

        [HttpGet("GetSalesReportByYear")]
        public async Task<IActionResult> GetSalesReportByYearAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_SALES_REPORT_BY_YEAR, clientID);
        }

        [HttpGet("GetSalesReportByMonth")]
        public async Task<IActionResult> GetSalesReportByMonthAsync(Guid clientID, int year)
        {
            return await ProcessRequest(RequestType.GET_SALES_REPORT_BY_MONTH, clientID, year);
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

        [HttpGet("GetSalesByID")]
        public async Task<IActionResult> GetSalesByIDAsync(Guid clientID, string id)
        {
            return await ProcessRequest(RequestType.GET_SALES_BY_ID, clientID, id);
        }

        [HttpPost("SaveSales")]
        public async Task<IActionResult> SaveSalesAsync(SaveSalesRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_SALES, request.client.ClientID, request, request.FunctionID);
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
                    case RequestType.GET_SALES_REPORT_BY_YEAR:
                        response = await _sales.GetSalesReportByYearAsync();
                        break;

                    case RequestType.GET_SALES_REPORT_BY_MONTH:
                        response = await _sales.GetSalesReportByMonthAsync((int)data);
                        break;

                    case RequestType.GET_SALES:
                        response = await _sales.GetSalesAsync();
                        break;

                    case RequestType.GET_SALES_BY_QUERY:
                        response = await _sales.GetSalesByQueryAsync((string)data);
                        break;

                    case RequestType.GET_SALES_BY_ID:
                        response = await _sales.GetSalesByIDAsync((string)data);
                        break;

                    case RequestType.POST_SAVE_SALES:
                        response = await _sales.SaveSalesAsync((SaveSalesRequest)data);
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
