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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventory;
        public InventoryController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet("GetInventories")]
        public async Task<IActionResult> GetInventoriesAsync()
        {
            return await ProcessRequest(RequestType.GET_INVENTORIES);
        }

        [HttpGet("GetInventoriesByQuery")]
        public async Task<IActionResult> GetInventoriesByQueryAsync(string query)
        {
            return await ProcessRequest(RequestType.GET_INVENTORIES_BY_QUERY, query);
        }

        [HttpGet("GetInventoryByID")]
        public async Task<IActionResult> GetInventoryByIDAsync(string id)
        {
            return await ProcessRequest(RequestType.GET_INVENTORY_BY_ID, id);
        }

        [HttpPost("SaveInventory")]
        public async Task<IActionResult> SaveInventoryAsync(SaveInventoryRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_INVENTORY, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, object? request = null)
        {
            try
            {
                object? response = null;

                if (type == RequestType.GET_INVENTORIES)
                {
                    response = await _inventory.GetInventoriesAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_BRAND));

                    switch(type)
                    {
                        case RequestType.GET_INVENTORIES_BY_QUERY:
                            response = await _inventory.GetInventoriesByQueryAsync((string)request);
                            break;

                        case RequestType.GET_INVENTORY_BY_ID:
                            response = await _inventory.GetInventoryByIDAsync((string)request);
                            break;

                        case RequestType.POST_SAVE_INVENTORY:
                            response = await _inventory.SaveInventoryAsync((SaveInventoryRequest)request);
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
