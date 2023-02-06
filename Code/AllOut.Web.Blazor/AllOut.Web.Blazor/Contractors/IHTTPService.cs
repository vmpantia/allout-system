using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.Requests;

namespace AllOut.Web.Blazor.Contractors
{
    public interface IHTTPService
    {
        Response GetBrandByID(Guid clientID, Guid id);
        Response GetBrands(Guid clientID);
        Response GetBrandsByQuery(Guid clientID, string query);
        Response GetBrandsByStatus(Guid clientID, int status);
        Response GetCategories(Guid clientID);
        Response GetCategoriesByQuery(Guid clientID, string query);
        Response GetCategoriesByStatus(Guid clientID, int status);
        Response GetCategoryByID(Guid clientID, Guid id);
        Response GetCountBrands(Guid clientID);
        Response GetCountBrandsByStatus(Guid clientID, int status);
        Response GetCountCategories(Guid clientID);
        Response GetCountCategoriesByStatus(Guid clientID, int status);
        Response GetCountInventories(Guid clientID);
        Response GetCountInventoriesByStatus(Guid clientID, int status);
        Response GetCountProducts(Guid clientID);
        Response GetCountProductsByStatus(Guid clientID, int status);
        Response GetCountRoles(Guid clientID);
        Response GetCountRolesByStatus(Guid clientID, int status);
        Response GetCountSales(Guid clientID);
        Response GetCountSalesByStatus(Guid clientID, int status);
        Response GetCountUsers(Guid clientID);
        Response GetCountUsersByStatus(Guid clientID, int status);
        Response GetInventories(Guid clientID);
        Response GetInventoriesByQuery(Guid clientID, string query);
        Response GetInventoriesByStatus(Guid clientID, int status);
        Response GetInventoryByID(Guid clientID, string id);
        Response GetProductByID(Guid clientID, Guid id);
        Response GetProducts(Guid clientID);
        Response GetProductsByQuery(Guid clientID, string query);
        Response GetProductsByStatus(Guid clientID, int status);
        Response GetRoleByID(Guid clientID, Guid id);
        Response GetRoles(Guid clientID);
        Response GetRolesByQuery(Guid clientID, string query);
        Response GetRolesByStatus(Guid clientID, int status);
        Response GetSales(Guid clientID);
        Response GetSalesByID(Guid clientID, string id);
        Response GetSalesByQuery(Guid clientID, string query);
        Response GetSalesByStatus(Guid clientID, int status);
        Response GetSalesReport(Guid clientID);
        Response GetSalesReportByYearAndMonth(Guid clientID, string query);
        Response GetSalesReportByYear(Guid clientID, int year);
        Response GetUserByID(Guid clientID, Guid id);
        Response GetUsers(Guid clientID);
        Response GetUsersByQuery(Guid clientID, string query);
        Response GetUsersByStatus(Guid clientID, int status);
        Response PostLoginUser(LoginUserRequest request);
        Response PostSaveBrand(SaveBrandRequest request);
        Response PostSaveCategory(SaveCategoryRequest request);
        Response PostSaveInventory(SaveInventoryRequest request);
        Response PostSaveProduct(SaveProductRequest request);
        Response PostSaveRole(SaveRoleRequest request);
        Response PostSaveSales(SaveSalesRequest request);
        Response PostSaveUser(SaveUserRequest request);
        Response PostUpdateBrandStatusByIDs(UpdateStatusByGUIDsRequest request);
        Response PostUpdateCategoryStatusByIDs(UpdateStatusByGUIDsRequest request);
        Response PostUpdateInventoryStatusByIDs(UpdateStatusByStringIDsRequest request);
        Response PostUpdateProductStatusByIDs(UpdateStatusByGUIDsRequest request);
        Response PostUpdateRoleStatusByIDs(UpdateStatusByGUIDsRequest request);
        Response PostUpdateSalesStatusByIDs(UpdateStatusByStringIDsRequest request);
        Response PostUpdateUserStatusByIDs(UpdateStatusByGUIDsRequest request);
    }
}