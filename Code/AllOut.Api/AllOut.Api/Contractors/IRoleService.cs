using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IRoleService
    {
        Task<int> GetCountRolesAsync();
        Task<int> GetCountRolesByStatusAsync(int status);
        Task<Role> GetRoleByIDAsync(Guid RoleID);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<IEnumerable<Role>> GetRolesByQueryAsync(string query);
        Task<IEnumerable<Role>> GetRolesByStatusAsync(int status);
        Task<string> SaveRoleAsync(SaveRoleRequest request);
        Task<string> UpdateRoleStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
    }
}