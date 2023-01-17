using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
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
            var type = RequestType.POST_LOGIN_USER;
            try
            {
                //Check if Request is NULL
                if (request == null)
                    throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_USER));

                var response = await _user.LoginUserAsync(request);
                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAsync(Guid clientID)
        {
            var type = RequestType.GET_USERS;
            try
            {
                var errorMessage = await _utility.ValidateClientID(clientID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                var response = await _user.GetUsersAsync();
                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("GetUsersByQuery")]
        public async Task<IActionResult> GetUsersByQueryAsync(Guid clientID, string query)
        {
            var type = RequestType.GET_USERS_BY_QUERY;
            try
            {
                var errorMessage = await _utility.ValidateClientID(clientID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                var response = await _user.GetUsersAsync();
                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByIDAsync(Guid clientID, Guid id)
        {
            var type = RequestType.GET_USER_BY_ID;
            try
            {
                var errorMessage = await _utility.ValidateClientID(clientID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                var response = await _user.GetUserByIDAsync(id);
                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUserAsync(SaveUserRequest request)
        {
            var type = RequestType.POST_SAVE_USER;
            try
            {
                //Check if Request is NULL
                if (request == null)
                    throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_USER));

                if(request.FunctionID != Constants.FUNCTION_ID_ADD_USER)
                {
                    var errorMessage = await _utility.ValidateClientID(request.client.ClientID);
                    if (!string.IsNullOrEmpty(errorMessage))
                        return Unauthorized(errorMessage);
                }

                var response = await _user.SaveUserAsync(request);
                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("UpdateUserStatusByIDs")]
        public async Task<IActionResult> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            try
            {
                //Check if Request is NULL
                if (request == null)
                    throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_USER));

                var errorMessage = await _utility.ValidateClientID(request.client.ClientID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                var response = await _user.UpdateUserStatusByIDsAsync(request);
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
