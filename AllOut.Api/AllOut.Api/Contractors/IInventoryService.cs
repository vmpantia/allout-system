using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryFullInformation>> GetInventoriesAsync();
        Task<Inventory> GetInventoryByIDAsync(string InventoryID);
        Task<string> SaveInventoryAsync(SaveInventoryRequest request);
    }
}