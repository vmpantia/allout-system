using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetInventoriesAsync();
        Task<Inventory> GetInventoryByIDAsync(Guid InventoryID);
        Task<string> SaveInventoryAsync(SaveInventoryRequest request);
    }
}