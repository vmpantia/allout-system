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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventory;
        private readonly IUtilityService _utility;
        public InventoryController(IInventoryService inventory, IUtilityService utility)
        {
            _inventory = inventory;
            _utility = utility;
        }

        [HttpGet("GetInventories")]
        public async Task<IActionResult> GetInventoriesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_INVENTORIES, clientID);
        }

        [HttpGet("GetInventoriesByQuery")]
        public async Task<IActionResult> GetInventoriesByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_INVENTORIES_BY_QUERY, clientID, query);
        }

        [HttpGet("GetInventoryByID")]
        public async Task<IActionResult> GetInventoryByIDAsync(Guid clientID, string id)
        {
            return await ProcessRequest(RequestType.GET_INVENTORY_BY_ID, clientID, id);
        }

        [HttpPost("SaveInventory")]
        public async Task<IActionResult> SaveInventoryAsync(SaveInventoryRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_INVENTORY, request.client.ClientID, request, request.FunctionID);
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
                    case RequestType.GET_INVENTORIES:
                        response = await _inventory.GetInventoriesAsync();
                        break;

                    case RequestType.GET_INVENTORIES_BY_QUERY:
                        response = await _inventory.GetInventoriesByQueryAsync((string)data);
                        break;

                    case RequestType.GET_INVENTORY_BY_ID:
                        response = await _inventory.GetInventoryByIDAsync((string)data);
                        break;

                    case RequestType.POST_SAVE_INVENTORY:
                        response = await _inventory.SaveInventoryAsync((SaveInventoryRequest)data);
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
