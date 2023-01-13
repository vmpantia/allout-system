using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

namespace AllOut.Api.Services
{
    public class UserService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        private readonly IUtilityService _utility;
        public UserService(AllOutDbContext context, IRequestService request, IUtilityService utility)
        {
            _db = context;
            _request = request;
            _utility = utility;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _db.Users.Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByQueryAsync(string query)
        {
            return await _db.Users.Where(data => data.Email.Contains(query) || 
                                                 data.Username.Contains(query) ||
                                                 data.FirstName.Contains(query) ||
                                                 data.MiddleName.Contains(query) ||
                                                 data.LastName.Contains(query))
                                  .Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
        }

        public async Task<User> GetUserByIDAsync(Guid userID)
        {
            var user = await _db.Users.FindAsync(userID);

            if (user == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_USER));

            return user;
        }

        private async Task InsertUser(User inputUser)
        {
            inputUser.UserID = Guid.NewGuid();
            inputUser.CreatedDate = Globals.EXEC_DATETIME;
            await _db.Users.AddAsync(inputUser);
        }

        private async Task UpdateUser(User inputUser)
        {
            var currentUser = await _db.Users.FindAsync(inputUser.UserID);

            if (currentUser == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_USER));

            //currentUser.UserID = inputUser.UserID;
            currentUser.Email = inputUser.Email;
            currentUser.Username = inputUser.Username;
            currentUser.Password = inputUser.Password;
            currentUser.FirstName = inputUser.FirstName;
            currentUser.MiddleName = inputUser.MiddleName;
            currentUser.LastName = inputUser.LastName;
            currentUser.IsEmailConfirmed = inputUser.IsEmailConfirmed;
            currentUser.Permission = inputUser.Permission;
            currentUser.Status = inputUser.Status;
            //currentUser.CreatedDate = inputUser.CreatedDate;
            currentUser.ModifiedDate = Globals.EXEC_DATETIME;
        }

        private async Task DeleteUser(Guid userID)
        {
            var currentUser = await _db.Users.FindAsync(userID);

            if (currentUser == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_USER));

            _db.Users.Remove(currentUser);
        }

        private async Task InsertUser_TRN(User inputUser, string requestID, int number = 1)
        {
            var newTrn = new User_TRN
            {
                RequestID = requestID,
                Number = number,
                UserID = inputUser.UserID,
                Email = inputUser.Email,
                Username = inputUser.Username,
                Password = inputUser.Password,
                FirstName = inputUser.FirstName,
                MiddleName = inputUser.MiddleName,
                LastName = inputUser.LastName,
                IsEmailConfirmed = inputUser.IsEmailConfirmed,
                Permission = inputUser.Permission,
                Status = inputUser.Status,
                CreatedDate = inputUser.CreatedDate,
                ModifiedDate = inputUser.ModifiedDate
            };

            await _db.User_TRN.AddAsync(newTrn);
        }
    }
}
