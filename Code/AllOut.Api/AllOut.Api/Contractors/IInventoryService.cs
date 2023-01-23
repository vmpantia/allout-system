using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryFullInformation>> GetInventoriesAsync();
        Task<IEnumerable<InventoryFullInformation>> GetInventoriesByQueryAsync(string query);
        Task<IEnumerable<InventoryFullInformation>> GetInventoriesByStatusAsync(int status);
        Task<Inventory> GetInventoryByIDAsync(string InventoryID);
        Task<int> GetCountInventoriesAsync();
        Task<int> GetCountInventoriesByStatusAsync(int status);
        Task<string> SaveInventoryAsync(SaveInventoryRequest request);
        Task<string> UpdateInventoryStatusByIDsAsync(UpdateStatusByStringIDsRequest request);
    }
}