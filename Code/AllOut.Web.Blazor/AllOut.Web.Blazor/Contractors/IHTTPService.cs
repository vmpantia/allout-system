using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.Requests;

namespace AllOut.Web.Blazor.Contractors
{
    public interface IHTTPService
    {
        Task<Response> GetBrandByIDAsync(Guid clientID, Guid id);
        Task<Response> GetBrandsAsync(Guid clientID);
        Task<Response> GetBrandsByQueryAsync(Guid clientID, string query);
        Task<Response> GetBrandsByStatusAsync(Guid clientID, int status);
        Task<Response> GetCategoriesAsync(Guid clientID);
        Task<Response> GetCategoriesByQueryAsync(Guid clientID, string query);
        Task<Response> GetCategoriesByStatusAsync(Guid clientID, int status);
        Task<Response> GetCategoryByIDAsync(Guid clientID, Guid id);
        Task<Response> GetCountBrandsAsync(Guid clientID);
        Task<Response> GetCountBrandsByStatusAsync(Guid clientID, int status);
        Task<Response> GetCountCategoriesAsync(Guid clientID);
        Task<Response> GetCountCategoriesByStatusAsync(Guid clientID, int status);
        Task<Response> GetCountInventoriesAsync(Guid clientID);
        Task<Response> GetCountInventoriesByStatusAsync(Guid clientID, int status);
        Task<Response> GetCountProductsAsync(Guid clientID);
        Task<Response> GetCountProductsByStatusAsync(Guid clientID, int status);
        Task<Response> GetCountRolesAsync(Guid clientID);
        Task<Response> GetCountRolesByStatusAsync(Guid clientID, int status);
        Task<Response> GetCountSalesAsync(Guid clientID);
        Task<Response> GetCountSalesByStatusAsync(Guid clientID, int status);
        Task<Response> GetCountUsersAsync(Guid clientID);
        Task<Response> GetCountUsersByStatusAsync(Guid clientID, int status);
        Task<Response> GetInventoriesAsync(Guid clientID);
        Task<Response> GetInventoriesByQueryAsync(Guid clientID, string query);
        Task<Response> GetInventoriesByStatusAsync(Guid clientID, int status);
        Task<Response> GetInventoryByIDAsync(Guid clientID, string id);
        Task<Response> GetProductByIDAsync(Guid clientID, Guid id);
        Task<Response> GetProductsAsync(Guid clientID);
        Task<Response> GetProductsByQueryAsync(Guid clientID, string query);
        Task<Response> GetProductsByStatusAsync(Guid clientID, int status);
        Task<Response> GetRoleByIDAsync(Guid clientID, Guid id);
        Task<Response> GetRolesAsync(Guid clientID);
        Task<Response> GetRolesByQueryAsync(Guid clientID, string query);
        Task<Response> GetRolesByStatusAsync(Guid clientID, int status);
        Task<Response> GetSalesAsync(Guid clientID);
        Task<Response> GetSalesByIDAsync(Guid clientID, string id);
        Task<Response> GetSalesByQueryAsync(Guid clientID, string query);
        Task<Response> GetSalesByStatusAsync(Guid clientID, int status);
        Task<Response> GetSalesReportAsync(Guid clientID);
        Task<Response> GetSalesReportByYearAndMonthAsync(Guid clientID, string query);
        Task<Response> GetSalesReportByYearAsync(Guid clientID, int year);
        Task<Response> GetUserByIDAsync(Guid clientID, Guid id);
        Task<Response> GetUsersAsync(Guid clientID);
        Task<Response> GetUsersByQueryAsync(Guid clientID, string query);
        Task<Response> GetUsersByStatusAsync(Guid clientID, int status);
        Task<Response> PostLoginUserAsync(LoginUserRequest request);
        Task<Response> PostSaveBrandAsync(SaveBrandRequest request);
        Task<Response> PostSaveCategoryAsync(SaveCategoryRequest request);
        Task<Response> PostSaveInventoryAsync(SaveInventoryRequest request);
        Task<Response> PostSaveProductAsync(SaveProductRequest request);
        Task<Response> PostSaveRoleAsync(SaveRoleRequest request);
        Task<Response> PostSaveSalesAsync(SaveSalesRequest request);
        Task<Response> PostSaveUserAsync(SaveUserRequest request);
        Task<Response> PostUpdateBrandStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Task<Response> PostUpdateCategoryStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Task<Response> PostUpdateInventoryStatusByIDsAsync(UpdateStatusByStringIDsRequest request);
        Task<Response> PostUpdateProductStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Task<Response> PostUpdateRoleStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Task<Response> PostUpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request);
        Task<Response> PostUpdateUserStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
    }
}