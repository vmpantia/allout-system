using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.Requests;

namespace AllOut.Web.Blazor.Contractors
{
    public interface IHTTPService
    {
        Response GetBrandByIDAsync(Guid clientID, Guid id);
        Response GetBrandsAsync(Guid clientID);
        Response GetBrandsByQueryAsync(Guid clientID, string query);
        Response GetBrandsByStatusAsync(Guid clientID, int status);
        Response GetCategoriesAsync(Guid clientID);
        Response GetCategoriesByQueryAsync(Guid clientID, string query);
        Response GetCategoriesByStatusAsync(Guid clientID, int status);
        Response GetCategoryByIDAsync(Guid clientID, Guid id);
        Response GetCountBrandsAsync(Guid clientID);
        Response GetCountBrandsByStatusAsync(Guid clientID, int status);
        Response GetCountCategoriesAsync(Guid clientID);
        Response GetCountCategoriesByStatusAsync(Guid clientID, int status);
        Response GetCountInventoriesAsync(Guid clientID);
        Response GetCountInventoriesByStatusAsync(Guid clientID, int status);
        Response GetCountProductsAsync(Guid clientID);
        Response GetCountProductsByStatusAsync(Guid clientID, int status);
        Response GetCountRolesAsync(Guid clientID);
        Response GetCountRolesByStatusAsync(Guid clientID, int status);
        Response GetCountSalesAsync(Guid clientID);
        Response GetCountSalesByStatusAsync(Guid clientID, int status);
        Response GetCountUsersAsync(Guid clientID);
        Response GetCountUsersByStatusAsync(Guid clientID, int status);
        Response GetInventoriesAsync(Guid clientID);
        Response GetInventoriesByQueryAsync(Guid clientID, string query);
        Response GetInventoriesByStatusAsync(Guid clientID, int status);
        Response GetInventoryByIDAsync(Guid clientID, string id);
        Response GetProductByIDAsync(Guid clientID, Guid id);
        Response GetProductsAsync(Guid clientID);
        Response GetProductsByQueryAsync(Guid clientID, string query);
        Response GetProductsByStatusAsync(Guid clientID, int status);
        Response GetRoleByIDAsync(Guid clientID, Guid id);
        Response GetRolesAsync(Guid clientID);
        Response GetRolesByQueryAsync(Guid clientID, string query);
        Response GetRolesByStatusAsync(Guid clientID, int status);
        Response GetSalesAsync(Guid clientID);
        Response GetSalesByIDAsync(Guid clientID, string id);
        Response GetSalesByQueryAsync(Guid clientID, string query);
        Response GetSalesByStatusAsync(Guid clientID, int status);
        Response GetSalesReportAsync(Guid clientID);
        Response GetSalesReportByYearAndMonthAsync(Guid clientID, string query);
        Response GetSalesReportByYearAsync(Guid clientID, int year);
        Response GetUserByIDAsync(Guid clientID, Guid id);
        Response GetUsersAsync(Guid clientID);
        Response GetUsersByQueryAsync(Guid clientID, string query);
        Response GetUsersByStatusAsync(Guid clientID, int status);
        Response PostLoginUserAsync(LoginUserRequest request);
        Response PostSaveBrandAsync(SaveBrandRequest request);
        Response PostSaveCategoryAsync(SaveCategoryRequest request);
        Response PostSaveInventoryAsync(SaveInventoryRequest request);
        Response PostSaveProductAsync(SaveProductRequest request);
        Response PostSaveRoleAsync(SaveRoleRequest request);
        Response PostSaveSalesAsync(SaveSalesRequest request);
        Response PostSaveUserAsync(SaveUserRequest request);
        Response PostUpdateBrandStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Response PostUpdateCategoryStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Response PostUpdateInventoryStatusByIDsAsync(UpdateStatusByStringIDsRequest request);
        Response PostUpdateProductStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Response PostUpdateRoleStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
        Response PostUpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request);
        Response PostUpdateUserStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
    }
}