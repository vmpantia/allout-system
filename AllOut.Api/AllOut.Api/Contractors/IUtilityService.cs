using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Contractors
{
    public interface IUtilityService
    {
        bool CheckBrandAvailablity(Brand brand);
        bool CheckCategoryAvailablity(Category category);
        int GetCurrentStock(int inventories, int sales);
        bool GetReorderState(int stock, int reorderpoint);
    }
}