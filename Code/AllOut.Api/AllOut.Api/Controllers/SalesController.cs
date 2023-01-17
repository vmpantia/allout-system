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
