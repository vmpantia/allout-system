using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Puregold.API.Exceptions;

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

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_USER_BY_ID, 
                                        clientID, id);
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
        public async Task<IActionResult> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request)
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
                    case RequestType.GET_USER_BY_ID:
                        response = await _user.GetUserByIDAsync((Guid)data);
                        break;
                    case RequestType.POST_SAVE_USER:
                        response = await _user.SaveUserAsync((SaveUserRequest)data);
                        break;
                    case RequestType.POST_UPDATE_USER_STATUS_BY_IDS:
                        response = await _user.UpdateUserStatusByIDsAsync((UpdateStatusByIDsRequest)data);
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
