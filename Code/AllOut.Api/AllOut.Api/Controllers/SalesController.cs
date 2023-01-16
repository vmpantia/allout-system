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

        [HttpPost("SaveSales")]
        public async Task<IActionResult> SaveSalesAsync(SaveSalesRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_SALES, request.client.ClientID, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object? request = null)
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClientID(clientID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                //Check if Request is NULL
                if (request == null)
                    throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_BRAND));

                switch (type)
                {
                    case RequestType.POST_SAVE_SALES:
                        response = await _sales.SaveSalesAsync((SaveSalesRequest)request);
                        break;
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
