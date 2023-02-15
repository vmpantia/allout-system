using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.enums;

namespace AllOut.Api.Contractors
{
    public interface IUtilityService
    {
        bool CheckProductAvailablity(Product product);
        bool CheckBrandAvailablity(Brand brand);
        bool CheckCategoryAvailablity(Category category);
        bool CheckUserAvailability(User user);
        bool CheckRoleAvailability(Role role); 
        bool CheckSalesAvailability(Sales sales);
        int GetCurrentStock(int inventories, int sales);
        bool GetReorderState(int stock, int reorderpoint);
        decimal GetTotal(decimal totalItems, decimal totalAdditional, decimal totalDeduction);
        Task<string> ValidateClient(Guid ClientID, RequestType requestType, string functionID);
        bool IsValidName(string name);
        bool IsValidEmail(string email);
        bool IsValidPassword(string password);
        string ParsePassword(string password, bool isEncrypt);
    }
}