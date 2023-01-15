﻿using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        public UserController(IUserService user)
        {
            _user = user;
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUserAsync(LoginUserRequest request)
        {
            return await ProcessRequest(RequestType.POST_LOGIN_USER, request);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            return await ProcessRequest(RequestType.GET_USERS);
        }

        [HttpGet("GetUsersByQuery/{query}")]
        public async Task<IActionResult> GetUsersByQueryAsync(string query)
        {
            return await ProcessRequest(RequestType.GET_USERS_BY_QUERY, query);
        }

        [HttpGet("GetUserByID/{id}")]
        public async Task<IActionResult> GetUserByIDAsync(Guid id)
        {
            return await ProcessRequest(RequestType.GET_USER_BY_ID, id);
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUserAsync(SaveUserRequest request)
        {
            return await ProcessRequest(RequestType.POST_SAVE_USER, request);
        }

        [HttpPost("UpdateUserStatusByIDs")]
        public async Task<IActionResult> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            return await ProcessRequest(RequestType.POST_UPDATE_USER_STATUS_BY_IDS, request);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, object? request = null)
        {
            try
            {
                object? response = null;

                if (type == RequestType.GET_USERS)
                {
                    response = await _user.GetUsersAsync();
                }
                else
                {
                    //Check if Request is NULL
                    if (request == null)
                        throw new ControllerException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_BRAND));

                    switch(type)
                    {
                        case RequestType.POST_LOGIN_USER:
                            response = await _user.LoginUserAsync((LoginUserRequest)request);
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