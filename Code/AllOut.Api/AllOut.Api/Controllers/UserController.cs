using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
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
            return await ProcessRequest(RequestType.POST_LOGIN_USER, Guid.Empty, request);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_USERS, clientID);
        }

        [HttpGet("GetUsersByQuery")]
        public async Task<IActionResult> GetUsersByQueryAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_USERS_BY_QUERY, clientID, query);
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByIDAsync(Guid clientID, Guid id)
        {
            return await ProcessRequest(RequestType.GET_USER_BY_ID, clientID, id);
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUserAsync(SaveUserRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_USER, request.client.ClientID, request);
        }

        [HttpPost("UpdateUserStatusByIDs")]
        public async Task<IActionResult> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_USER_STATUS_BY_IDS, request.client.ClientID, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object? request = null)
        {
            try
            {
                object? response = null;

                if(type != RequestType.POST_LOGIN_USER)
                {
                    var errorMessage = await _utility.ValidateClientID(clientID);
                    if (!string.IsNullOrEmpty(errorMessage))
                        return Unauthorized(errorMessage);
                }

                if (type == RequestType.GET_USERS)
                {
                    response = await _user.GetUsersAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_BRAND));

                    switch(type)
                    {
                        case RequestType.POST_LOGIN_USER:
                            response = await _user.LoginUserAsync((LoginUserRequest)request);
                            if (response != null)
                                clientID = ((Client)response).ClientID;
                            break;

                        case RequestType.GET_USERS_BY_QUERY:
                            response = await _user.GetUsersByQueryAsync((string)request);
                            break;

                        case RequestType.GET_USER_BY_ID:
                            response = await _user.GetUserByIDAsync((Guid)request);
                            break;

                        case RequestType.POST_SAVE_USER:
                            response = await _user.SaveUserAsync((SaveUserRequest)request);
                            break;

                        case RequestType.POST_UPDATE_USER_STATUS_BY_IDS:
                            response = await _user.UpdateUserStatusByIDsAsync((UpdateStatusByIDsRequest)request);
                            break;
                    }
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
