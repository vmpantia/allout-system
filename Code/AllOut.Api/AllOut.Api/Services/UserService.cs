using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;

namespace AllOut.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public UserService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        #region Public Methods
        public async Task<Client> LoginUserAsync(LoginUserRequest request)
        {
            if (string.IsNullOrEmpty(request.LogonName) || string.IsNullOrEmpty(request.Password))
            {
                throw new APIException(Constants.ERROR_EMPTY_CREDENTIAL);
            }

            var users = await _db.Users.Where(data => (data.Username == request.LogonName && data.Password == request.Password) ||
                                                      (data.Email == request.LogonName && data.Password == request.Password)).ToListAsync();

            if (users == null || !users.Any())
            {
                throw new APIException(Constants.ERROR_INCORRECT_CREDENTIAL);
            }

            return new Client()
            {
                UserID = users.First().UserID,
                Name = string.Format(Constants.NAME_FORMAT, users.First().LastName, users.First().FirstName)
            };
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
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_USER));

            return user;
        }

        public async Task<string> SaveUserAsync(SaveUserRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_USER));

            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new APIException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_USER));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_USER_BY_ADMIN: //Add
                case Constants.FUNCTION_ID_ADD_USER: //Add
                    await InsertUser(request.inputUser);
                    break;
                case Constants.FUNCTION_ID_CHANGE_USER_BY_ADMIN: //Change
                case Constants.FUNCTION_ID_CHANGE_USER: //Change
                    await UpdateUser(request.inputUser);
                    break;
                case Constants.FUNCTION_ID_DELETE_PRODUCT_BY_ADMIN: //Delete
                    await DeleteUser(request.inputUser.UserID);
                    break;
            }

            //Insert Transaction
            await InsertUser_TRN(request.inputUser, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        public async Task<string> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);
            var count = 0;
            foreach (var id in request.IDs)
            {
                count++;
                var user = await _db.Users.FindAsync(id);
                if (user != null)
                {
                    user.Status = request.newStatus;
                    user.ModifiedDate = DateTime.Now;
                    await InsertUser_TRN(user, requestID.ToString(), count);
                }
            }

            await _db.SaveChangesAsync();

            return requestID;
        }
        #endregion

        #region Private Methods
        private async Task InsertUser(User inputUser)
        {
            var errorMessage = await ValidateUser(inputUser);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            inputUser.UserID = Guid.NewGuid();
            inputUser.CreatedDate = Globals.EXEC_DATETIME;
            await _db.Users.AddAsync(inputUser);
        }

        private async Task UpdateUser(User inputUser)
        {
            var currentUser = await _db.Users.FindAsync(inputUser.UserID);

            if (currentUser == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_USER));

            var errorMessage = await ValidateUser(inputUser, currentUser);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

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
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_USER));

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

        private async Task<string> ValidateUser(User newData, User? oldData = null)
        {
            bool isNameChanged = false;
            bool isEmailChanged = false;
            bool isNew = true;

            //Check Data if NULL
            if (newData == null)
                return string.Format(Constants.ERROR_NULL, Constants.OBJECT_USER);

            //Check if required fields have value
            if (string.IsNullOrEmpty(newData.Email) ||
                string.IsNullOrEmpty(newData.Username) ||
                string.IsNullOrEmpty(newData.Password) ||
                string.IsNullOrEmpty(newData.FirstName) ||
                string.IsNullOrEmpty(newData.LastName))
                return Constants.ERROR_REQUIRED_FIELDS;


            if (oldData != null)
            {
                isNew = false;

                //Check if new data and old data changed
                if (/*newData.Email == oldData.BrandID &&*/
                    //newData.Username == oldData.CategoryID &&
                    //newData.Password == oldData.Name &&
                    newData.FirstName == oldData.FirstName &&
                    newData.MiddleName == oldData.MiddleName &&
                    newData.LastName == oldData.LastName &&
                    //newData.IsEmailConfirmed == oldData.IsEmailConfirmed &&
                    newData.Permission == oldData.Permission &&
                    newData.Status == oldData.Status &&
                    newData.CreatedDate == oldData.CreatedDate &&
                    newData.ModifiedDate == oldData.ModifiedDate)
                    return string.Format(Constants.ERROR_NO_CHANGES, Constants.OBJECT_USER);

                isNameChanged = newData.FirstName != oldData.FirstName ||
                                newData.LastName != oldData.LastName;
                isEmailChanged = newData.Email != oldData.Email;
            }


            if (isNew || isNameChanged || isEmailChanged)
            {
                //Check Duplicate Name or Email for New Data
                var duplicate = await _db.Users.Where(data => (data.FirstName == newData.FirstName && data.LastName == newData.LastName) ||
                                                              (data.Email == newData.Email)).ToListAsync();

                if (duplicate.Count > 0)
                {
                    if (duplicate.First().Status != Constants.STATUS_ENABLED_INT)
                        return string.Format(Constants.ERROR_NAME_EXIST_DISABLED, Constants.OBJECT_USER);

                    return string.Format(Constants.ERROR_NAME_EXIST, Constants.OBJECT_USER);
                }
            }

            return string.Empty;
        }
        #endregion
    }
}
