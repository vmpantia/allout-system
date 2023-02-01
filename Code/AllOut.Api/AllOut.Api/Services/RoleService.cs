using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;

namespace AllOut.Api.Services
{
    public class RoleService : IRoleService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public RoleService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        #region Public Methods
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var roles = await _db.Roles.Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
            return roles;
        }

        public async Task<IEnumerable<Role>> GetRolesByQueryAsync(string query)
        {
            var roles = await _db.Roles.Where(data => data.Name.Contains(query))
                                       .Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
            return roles;
        }

        public async Task<IEnumerable<Role>> GetRolesByStatusAsync(int status)
        {
            var roles = await _db.Roles.Where(data => data.Status == status).ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleByIDAsync(Guid RoleID)
        {
            var role = await _db.Roles.FindAsync(RoleID);

            if (role == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_ROLE));

            return role;
        }

        public async Task<int> GetCountRolesAsync()
        {
            var count = await _db.Roles.Where(data => data.Status != Constants.STATUS_DELETION_INT).CountAsync();
            return count;
        }

        public async Task<int> GetCountRolesByStatusAsync(int status)
        {
            var count = await _db.Roles.Where(data => data.Status == status).CountAsync();
            return count;
        }

        public async Task<string> SaveRoleAsync(SaveRoleRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_ROLE));

            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new APIException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_ROLE));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_ROLE_BY_ADMIN: //Add
                    await InsertRole(request.inputRole);
                    break;
                case Constants.FUNCTION_ID_CHANGE_ROLE_BY_ADMIN: //Change
                    await UpdateRole(request.inputRole);
                    break;
                case Constants.FUNCTION_ID_DELETE_ROLE_BY_ADMIN: //Delete
                    await DeleteRole(request.inputRole.RoleID);
                    break;
            }

            //Insert Transaction
            await InsertRole_TRN(request.inputRole, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        public async Task<string> UpdateRoleStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);
            var count = 0;
            foreach (var id in request.IDs)
            {
                count++;
                var Role = await _db.Roles.FindAsync(id);
                if (Role != null)
                {
                    Role.Status = request.newStatus;
                    Role.ModifiedDate = DateTime.Now;
                    await InsertRole_TRN(Role, requestID.ToString(), count);
                }
            }

            await _db.SaveChangesAsync();

            return requestID;
        }
        #endregion

        #region Private Methods
        private async Task InsertRole(Role inputRole)
        {
            var errorMessage = await ValidateRole(inputRole);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            inputRole.RoleID = Guid.NewGuid();
            inputRole.CreatedDate = DateTime.Now;
            await _db.Roles.AddAsync(inputRole);
        }

        private async Task UpdateRole(Role inputRole)
        {
            var currentRole = await _db.Roles.FindAsync(inputRole.RoleID);

            if (currentRole == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_ROLE));

            var errorMessage = await ValidateRole(inputRole, currentRole);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            //currentRole.RoleID = inputRole.RoleID;
            currentRole.Name = inputRole.Name;
            currentRole.ProductPermission = inputRole.ProductPermission;
            currentRole.CategoryPermission = inputRole.CategoryPermission;
            currentRole.BrandPermission = inputRole.BrandPermission;
            currentRole.InventoryPermission = inputRole.InventoryPermission;
            currentRole.SalesPermission = inputRole.SalesPermission;
            currentRole.UserPermission = inputRole.UserPermission;
            currentRole.RolePermission = inputRole.RolePermission;
            currentRole.Status = inputRole.Status;
            //currentRole.CreatedDate = inputRole.CreatedDate;
            currentRole.ModifiedDate = DateTime.Now;
        }

        private async Task DeleteRole(Guid RoleID)
        {
            var currentRole = await _db.Roles.FindAsync(RoleID);

            if (currentRole == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_ROLE));

            _db.Roles.Remove(currentRole);
        }

        private async Task InsertRole_TRN(Role inputRole, string requestID, int number = 1)
        {
            var newTrn = new Role_TRN
            {
                RequestID = requestID,
                Number = number,
                RoleID = inputRole.RoleID,
                Name = inputRole.Name,
                ProductPermission = inputRole.ProductPermission,
                CategoryPermission = inputRole.CategoryPermission,
                BrandPermission = inputRole.BrandPermission,
                InventoryPermission = inputRole.InventoryPermission,
                SalesPermission = inputRole.SalesPermission,
                UserPermission = inputRole.UserPermission,
                RolePermission = inputRole.RolePermission,
                Status = inputRole.Status,
                CreatedDate = inputRole.CreatedDate,
                ModifiedDate = inputRole.ModifiedDate
            };

            await _db.Role_TRN.AddAsync(newTrn);
        }

        private async Task<string> ValidateRole(Role newData, Role? oldData = null)
        {
            bool isNameChanged = false;
            bool isNew = true;

            //Check newData if NULL
            if (newData == null)
                return string.Format(Constants.ERROR_NULL, Constants.OBJECT_ROLE);

            //Validate Required Fields for Role
            if (string.IsNullOrEmpty(newData.Name))
                return string.Concat(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_ROLE);

            if (oldData != null)
            {
                isNew = false;

                //Check if new data and old data changed
                if (newData.Name == oldData.Name &&
                    newData.ProductPermission == oldData.ProductPermission &&
                    newData.CategoryPermission == oldData.CategoryPermission &&
                    newData.BrandPermission == oldData.BrandPermission &&
                    newData.InventoryPermission == oldData.InventoryPermission &&
                    newData.SalesPermission == oldData.SalesPermission &&
                    newData.UserPermission == oldData.UserPermission &&
                    newData.RolePermission == oldData.RolePermission &&
                    newData.Status == oldData.Status &&
                    newData.CreatedDate == oldData.CreatedDate &&
                    newData.ModifiedDate == oldData.ModifiedDate)
                    return string.Format(Constants.ERROR_NO_CHANGES, Constants.OBJECT_ROLE);

                isNameChanged = newData.Name != oldData.Name;
            }


            if (isNew || isNameChanged)
            {
                //Check Duplicate Name for New Data
                var duplicate = await _db.Roles.Where(data => data.Name == newData.Name).ToListAsync();

                if (duplicate.Count > 0)
                {
                    if (duplicate.First().Status != Constants.STATUS_ENABLED_INT)
                        return string.Format(Constants.ERROR_NAME_EXIST_DISABLED, Constants.OBJECT_ROLE);

                    return string.Format(Constants.ERROR_NAME_EXIST, Constants.OBJECT_ROLE);
                }
            }

            return string.Empty;
        }
        #endregion
    }
}
