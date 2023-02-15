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
        private readonly IUtilityService _utility;
        public UserService(AllOutDbContext context, IRequestService request, IUtilityService utility)
        {
            _db = context;
            _request = request;
            _utility = utility;
        }

        #region Public Methods
        public async Task<Client> LoginUserAsync(LoginUserRequest request)
        {
            if (string.IsNullOrEmpty(request.LogonName) || string.IsNullOrEmpty(request.Password))
                throw new APIException(Constants.ERROR_LOGIN_EMPTY_CREDENTIAL);

            var users = await _db.Users.Where(data => (data.Username == request.LogonName && data.Password == request.Password) ||
                                                      (data.Email == request.LogonName && data.Password == request.Password)).ToListAsync();

            if (users == null || !users.Any())
                throw new APIException(Constants.ERROR_LOGIN_INCORRECT_CREDENTIAL);

            if (users.First().Status != Constants.STATUS_ENABLED_INT)
                throw new APIException(Constants.ERROR_USER_NOT_ACTIVE);

            var client = await GenerateNewClient(users.First(), request);
            if (client == null)
                throw new APIException(Constants.ERROR_LOGIN_GENERATE_CLIENT);

            return client;
        }

        public async Task<Guid> LogoutUserAsync(Guid clientID)
        {
            var client = await _db.Clients.FindAsync(clientID);

            if (client == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_CLIENT));

            client.Status = Constants.STATUS_DISABLED_INT;
            await _db.SaveChangesAsync();

            return clientID;
        }

        public async Task<IEnumerable<UserFullInformation>> GetUsersAsync()
        {
            var list = await GetUsers();
            return list.Where(data => data.Status != Constants.STATUS_DELETION_INT).ToList();
        }

        public async Task<IEnumerable<UserFullInformation>> GetUsersByQueryAsync(string query)
        {
            var list = await GetUsers();
            return list.Where(data => data.Email.Contains(query) ||
                                      data.Username.Contains(query) ||
                                      data.FirstName.Contains(query) ||
                                      data.LastName.Contains(query) ||
                                      data.RoleName.Contains(query)) 
                       .Where(data => data.Status != Constants.STATUS_DELETION_INT).ToList();
        }

        public async Task<IEnumerable<UserFullInformation>> GetUsersByStatusAsync(int status)
        {
            var list = await GetUsers();
            return list.Where(data => data.Status == status).ToList();
        }

        public async Task<User> GetUserByIDAsync(Guid userID)
        {
            var user = await _db.Users.FindAsync(userID);

            if (user == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_USER));

            user.Password = Constants.HIDE_PASSWORD;
            return user;
        }

        public async Task<int> GetCountUsersAsync()
        {
            var count = await _db.Users.Where(data => data.Status != Constants.STATUS_DELETION_INT).CountAsync();
            return count;
        }

        public async Task<int> GetCountUsersByStatusAsync(int status)
        {
            var count = await _db.Users.Where(data => data.Status == status).CountAsync();
            return count;
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
                case Constants.FUNCTION_ID_DELETE_USER_BY_ADMIN: //Delete
                    await DeleteUser(request.inputUser.UserID);
                    break;
            }

            //Insert Transaction
            await InsertUser_TRN(request.inputUser, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        public async Task<string> UpdateUserStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
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
            inputUser.CreatedDate = DateTime.Now;
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
            //currentUser.Username = inputUser.Username;
            //currentUser.Password = inputUser.Password;
            currentUser.FirstName = inputUser.FirstName;
            currentUser.MiddleName = inputUser.MiddleName;
            currentUser.LastName = inputUser.LastName;
            currentUser.IsEmailConfirmed = inputUser.IsEmailConfirmed;
            currentUser.RoleID = inputUser.RoleID;
            currentUser.Status = inputUser.Status;
            //currentUser.CreatedDate = inputUser.CreatedDate;
            currentUser.ModifiedDate = DateTime.Now;
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
                RoleID = inputUser.RoleID,
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

            //Check newData if NULL
            if (newData == null)
                return string.Format(Constants.ERROR_NULL, Constants.OBJECT_USER);

            //Validate Required Fields for User
            if (string.IsNullOrEmpty(newData.Email))
                return string.Concat(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_EMAIL);

            if (string.IsNullOrEmpty(newData.Username))
                return string.Concat(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_UNAME);

            if (string.IsNullOrEmpty(newData.FirstName))
                return string.Concat(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_FNAME);

            if (string.IsNullOrEmpty(newData.LastName))
                return string.Concat(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_LNAME);

            if (string.IsNullOrEmpty(newData.Password))
                return string.Concat(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_PASS);

            if(!_utility.IsValidEmail(newData.Email))
                return string.Format(Constants.ERROR_EMAIL_NOT_VALID, newData.Email);

            if (!_utility.IsValidName(newData.FirstName) ||
                !_utility.IsValidName(newData.LastName))
                return Constants.ERROR_NAME_NOT_VALID;

            if (oldData != null)
            {
                isNew = false;

                //Check if new data and old data changed
                if (/*newData.Email == oldData.Email &&*/
                    //newData.Username == oldData.Username &&
                    //newData.Password == oldData.Password &&
                    newData.FirstName == oldData.FirstName &&
                    newData.MiddleName == oldData.MiddleName &&
                    newData.LastName == oldData.LastName &&
                    //newData.IsEmailConfirmed == oldData.IsEmailConfirmed &&
                    newData.RoleID == oldData.RoleID &&
                    newData.Status == oldData.Status &&
                    newData.CreatedDate == oldData.CreatedDate &&
                    newData.ModifiedDate == oldData.ModifiedDate)
                    return string.Format(Constants.ERROR_NO_CHANGES, Constants.OBJECT_USER);

                isNameChanged = newData.FirstName != oldData.FirstName ||
                                newData.LastName != oldData.LastName;
                isEmailChanged = newData.Email != oldData.Email;
            }

            //Check if ValidPassowrd when it's User creation
            if (isNew && !_utility.IsValidPassword(newData.Password))
                return Constants.ERROR_PASSWORD_NOT_VALID;

            if (isNew || isNameChanged || isEmailChanged)
            {
                //Check Duplicate Name or Email for New Data
                var duplicate = await _db.Users.Where(data => (data.FirstName == newData.FirstName && data.LastName == newData.LastName) &&
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

        private async Task<Client> GenerateNewClient(User user, LoginUserRequest request)
        {
            var client = new Client
            {
                UserID = user.UserID,
                Name = string.Format(Constants.NAME_FORMAT, user.LastName, user.FirstName),
                Browser = request.Browser,
                IPAddress = request.IPAddress,
                WindowsVersion = request.WindowsVersion,
                Status = Constants.STATUS_ENABLED_INT,
                CreatedDate = DateTime.Now
            };

            //Disable all active clients of User
            var clients = await _db.Clients.Where(data => data.UserID == user.UserID && 
                                                          data.Status == Constants.STATUS_ENABLED_INT).ToListAsync();
            if (clients.Any())
            {
                foreach (var currClient in clients)
                {
                    currClient.Status = Constants.STATUS_DISABLED_INT;
                }
            }

            await _db.Clients.AddAsync(client);
            await _db.SaveChangesAsync();

            return client;
        }

        private async Task<IEnumerable<UserFullInformation>> GetUsers()
        {
            return await (from a in _db.Users
                          join b in _db.Roles on a.RoleID equals b.RoleID into bb from b in bb.DefaultIfEmpty()
                          select new UserFullInformation
                          {
                              UserID = a.UserID,
                              Email = a.Email,
                              Username = a.Username,
                              Password = Constants.HIDE_PASSWORD,
                              FirstName = a.FirstName,
                              MiddleName = a.MiddleName,
                              LastName = a.LastName,
                              IsEmailConfirmed = a.IsEmailConfirmed,
                              RoleID = a.RoleID,
                              RoleName = _utility.CheckRoleAvailability(b) ? b.Name : Constants.NA,
                              Status = a.Status,
                              CreatedDate = a.CreatedDate,
                              ModifiedDate = a.ModifiedDate
                          }).ToListAsync();
        }
        #endregion
    }
}
