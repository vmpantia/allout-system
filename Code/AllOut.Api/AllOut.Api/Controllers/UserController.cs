using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly IUtilityService _utility;
        public UserController(IUserService user, IUtilityService utility)
        {
            _user = user;
            _utility = utility;
        }


        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUserAsync(LoginUserRequest request)
        {
            return await ProcessRequest(RequestType.POST_LOGIN_USER, 
                                        Guid.Empty, 
                                        request);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_USERS, 
                                        clientID);
        }

        [HttpGet("GetUsersByQuery")]
        public async Task<IActionResult> GetUsersByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_USERS_BY_QUERY, 
                                        clientID, 
                                        query);
        }

        [HttpGet("GetUsersByStatus")]
        public async Task<IActionResult> GetUsersByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_USERS_BY_STATUS, clientID, status);
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_USER_BY_ID, 
                                        clientID, id);
        }

        [HttpGet("GetCountUsers")]
        public async Task<IActionResult> GetCountUsersAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_COUNT_USERS, clientID);
        }

        [HttpGet("GetCountUsersByStatus")]
        public async Task<IActionResult> GetCountUsersByStatusAsync(Guid clientID, int status)
        {
            return await ProcessRequest(RequestType.GET_COUNT_USERS_BY_STATUS, clientID, status);
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUserAsync(SaveUserRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_USER, 
                                        request.client.ClientID, 
                                        request, 
                                        request.FunctionID);
        }

        [HttpPost("UpdateUserStatusByIDs")]
        public async Task<IActionResult> UpdateUserStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_USER_STATUS_BY_IDS, 
                                        request.client.ClientID, 
                                        request, 
                                        request.FunctionID);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object data = null, string functionID = null) 
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClientID(clientID, type, functionID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                switch(type)
                {
                    case RequestType.POST_LOGIN_USER:
                        response = await _user.LoginUserAsync((LoginUserRequest)data);
                        break;

                    case RequestType.GET_USERS:
                        response = await _user.GetUsersAsync();
                        break;

                    case RequestType.GET_USERS_BY_QUERY:
                        response = await _user.GetUsersByQueryAsync((string)data);
                        break;

                    case RequestType.GET_USERS_BY_STATUS:
                        response = await _user.GetUsersByStatusAsync((int)data);
                        break;

                    case RequestType.GET_USER_BY_ID:
                        response = await _user.GetUserByIDAsync((Guid)data);
                        break;

                    case RequestType.GET_COUNT_USERS:
                        response = await _user.GetCountUsersAsync();
                        break;

                    case RequestType.GET_COUNT_USERS_BY_STATUS:
                        response = await _user.GetCountUsersByStatusAsync((int)data);
                        break;

                    case RequestType.POST_SAVE_USER:
                        response = await _user.SaveUserAsync((SaveUserRequest)data);
                        break;

                    case RequestType.POST_UPDATE_USER_STATUS_BY_IDS:
                        response = await _user.UpdateUserStatusByIDsAsync((UpdateStatusByGUIDsRequest)data);
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
