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
    public class SaalesController : ControllerBase
    {
        private readonly ISalesService _sales;
        public SaalesController(ISalesService sales)
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

                //if (type == RequestType.GET_INVENTORIES)
                //{
                //    response = await _inventory.GetInventoriesAsync();
                //}
                //else
                //{
                //Check if Request is NULL
                if (request == null)
                    throw new ControllerException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_BRAND));

                switch (type)
                {
                    case RequestType.POST_SAVE_INVENTORY:
                        response = await _sales.SaveSalesAsync((SaveSalesRequest)request);
                        break;
                }
                //}

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
