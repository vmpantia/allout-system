using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;

namespace AllOut.Api.Contractors
{
    public interface IUtilityService
    {
        bool CheckProductAvailablity(Product product);
        bool CheckBrandAvailablity(Brand brand);
        bool CheckCategoryAvailablity(Category category);
        int GetCurrentStock(int inventories, int sales);
        bool GetReorderState(int stock, int reorderpoint);
        Task<string> ValidateClientID(Guid ClientID, RequestType requestType, string functionID);
        bool IsValidName(string name);
        bool IsValidEmail(string email);
    }
}