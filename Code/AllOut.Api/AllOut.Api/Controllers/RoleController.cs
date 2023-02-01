using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _ROLE;
        private readonly IUtilityService _utility;
        public RoleController(IRoleService role, IUtilityService utility)
        {
            _ROLE = role;
            _utility = utility;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRolesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_ROLES, 
                                        clientID);
        }

        [HttpGet("GetRolesByQuery")]
        public async Task<IActionResult> GetRolesByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_ROLES_BY_QUERY, 
                                        clientID, 
                                        query);
        }

        [HttpGet("GetRolesByStatus")]
        public async Task<IActionResult> GetRolesByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_ROLES_BY_STATUS, clientID, status);
        }

        [HttpGet("GetRoleByID")]
        public async Task<IActionResult> GetRoleByIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_ROLE_BY_ID, 
                                        clientID, id);
        }

        [HttpGet("GetCountRoles")]
        public async Task<IActionResult> GetCountRolesAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_COUNT_ROLES, clientID);
        }

        [HttpGet("GetCountRolesByStatus")]
        public async Task<IActionResult> GetCountRolesByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_COUNT_ROLES_BY_STATUS, clientID, status);
        }

        [HttpPost("SaveRole")]
        public async Task<IActionResult> SaveRoleAsync(SaveRoleRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_ROLE, 
                                        request.client.ClientID, 
                                        request, 
                                        request.FunctionID);
        }

        [HttpPost("UpdateRolestatusByIDs")]
        public async Task<IActionResult> UpdateRolestatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_ROLE_STATUS_BY_IDS, 
                                        request.client.ClientID, 
                                        request, 
                                        request.FunctionID);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object data = null, string functionID = null) 
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClient(clientID, type, functionID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                switch(type)
                {
                    case RequestType.GET_ROLES:
                        response = await _ROLE.GetRolesAsync();
                        break;

                    case RequestType.GET_ROLES_BY_QUERY:
                        response = await _ROLE.GetRolesByQueryAsync((string)data);
                        break;

                    case RequestType.GET_ROLES_BY_STATUS:
                        response = await _ROLE.GetRolesByStatusAsync((int)data);
                        break;

                    case RequestType.GET_ROLE_BY_ID:
                        response = await _ROLE.GetRoleByIDAsync((Guid)data);
                        break;

                    case RequestType.GET_COUNT_ROLES:
                        response = await _ROLE.GetCountRolesAsync();
                        break;

                    case RequestType.GET_COUNT_ROLES_BY_STATUS:
                        response = await _ROLE.GetCountRolesByStatusAsync((int)data);
                        break;

                    case RequestType.POST_SAVE_ROLE:
                        response = await _ROLE.SaveRoleAsync((SaveRoleRequest)data);
                        break;

                    case RequestType.POST_UPDATE_ROLE_STATUS_BY_IDS:
                        response = await _ROLE.UpdateRoleStatusByIDsAsync((UpdateStatusByGUIDsRequest)data);
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
