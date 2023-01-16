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
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _sales;
        public SalesController(ISalesService sales)
        {
            _sales = sales;
        }

        [HttpPost("SaveSales")]
        public async Task<IActionResult> SaveSalesAsync(SaveSalesRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_SALES, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, object? request = null)
        {
            try
            {
                object? response = null;

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
