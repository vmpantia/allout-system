using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IUserService
    {
        Task<ClientInformation> LoginUserAsync(LoginUserRequest request);
        Task<User> GetUserByIDAsync(Guid userID);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersByQueryAsync(string query);
        Task<string> SaveUserAsync(SaveUserRequest request);
        Task<string> UpdateUserStatusByIDsAsync(UpdateStatusByIDsRequest request);
    }
}