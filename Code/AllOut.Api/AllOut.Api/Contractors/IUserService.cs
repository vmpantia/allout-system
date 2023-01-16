﻿using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IUserService
    {
        Task<Client> LoginUserAsync(LoginUserRequest request);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersByQueryAsync(string query);
        Task<User> GetUserByIDAsync(Guid userID);
        Task<string> SaveUserAsync(SaveUserRequest request);
        Task<string> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request);
    }
}