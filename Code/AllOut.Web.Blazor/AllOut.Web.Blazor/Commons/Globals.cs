using AllOut.Web.Blazor.Models;
using System.Net.Security;

namespace AllOut.Web.Blazor.Commons
{
    public class Globals
    {
        public static Guid TEMP_CLIENT_ID = Guid.Parse("8435DC1B-356F-4F6E-A727-08DB05D958A1");
        public static Client TEMP_CLIENT = new Client {
            ClientID = TEMP_CLIENT_ID,
            UserID = Guid.Parse("0718EF62-4239-4A4C-B262-B2670FB76930"),
            Name = "ADMIN, ADMIN",
            Browser = Constants.NA,
            IPAddress = Constants.NA,
            WindowsVersion = Constants.NA,
            Status = 0,
            CreatedDate = DateTime.Parse("2024-02-03 20:43:40.6506777")
        };

        public static string POST_LOGIN_USER = string.Concat(Constants.API_BASE, "User/LoginUser");
        public static string GET_USERS = string.Concat(Constants.API_BASE, "User/GetUsers?clientID={0}");
        public static string GET_USERS_BY_QUERY = string.Concat(Constants.API_BASE, "User/GetUsersByQuery?clientID={0}&query={1}");
        public static string GET_USERS_BY_STATUS = string.Concat(Constants.API_BASE, "User/GetUsersByStatus?clientID={0}&status={1}");
        public static string GET_USER_BY_ID = string.Concat(Constants.API_BASE, "User/GetUserByID?clientID={0}&id={1}");
        public static string GET_COUNT_USERS = string.Concat(Constants.API_BASE, "User/GetCountUsers?clientID={0}");
        public static string GET_COUNT_USERS_BY_STATUS = string.Concat(Constants.API_BASE, "User/GetCountUsersByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_USER = string.Concat(Constants.API_BASE, "User/SaveUser");
        public static string POST_UPDATE_USER_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "User/UpdateUserStatusByIDs");

        public static string GET_ROLES = string.Concat(Constants.API_BASE, "Role/GetRoles?clientID={0}");
        public static string GET_ROLES_BY_QUERY = string.Concat(Constants.API_BASE, "Role/GetRolesByQuery?clientID={0}&query={1}");
        public static string GET_ROLES_BY_STATUS = string.Concat(Constants.API_BASE, "Role/GetRolesByStatus?clientID={0}&status={1}");
        public static string GET_ROLE_BY_ID = string.Concat(Constants.API_BASE, "Role/GetRoleByID?clientID={0}&id={1}");
        public static string GET_COUNT_ROLES = string.Concat(Constants.API_BASE, "Role/GetCountRoles?clientID={0}");
        public static string GET_COUNT_ROLES_BY_STATUS = string.Concat(Constants.API_BASE, "Role/GetCountRolesByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_ROLE = string.Concat(Constants.API_BASE, "Role/SaveRole");
        public static string POST_UPDATE_ROLE_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Role/UpdateRoleStatusByIDs");

        public static string GET_PRODUCTS = string.Concat(Constants.API_BASE, "Product/GetProducts?clientID={0}");
        public static string GET_PRODUCTS_BY_QUERY = string.Concat(Constants.API_BASE, "Product/GetProductsByQuery?clientID={0}&query={1}");
        public static string GET_PRODUCTS_BY_STATUS = string.Concat(Constants.API_BASE, "Product/GetProductsByStatus?clientID={0}&status={1}");
        public static string GET_PRODUCT_BY_ID = string.Concat(Constants.API_BASE, "Product/GetProductByID?clientID={0}&id={1}");
        public static string GET_COUNT_PRODUCTS = string.Concat(Constants.API_BASE, "Product/GetCountProducts?clientID={0}");
        public static string GET_COUNT_PRODUCTS_BY_STATUS = string.Concat(Constants.API_BASE, "Product/GetCountProductsByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_PRODUCT = string.Concat(Constants.API_BASE, "Product/SaveProduct");
        public static string POST_UPDATE_PRODUCT_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Product/UpdateProductStatusByIDs");

        public static string GET_BRANDS = string.Concat(Constants.API_BASE, "Brand/GetBrands?clientID={0}");
        public static string GET_BRANDS_BY_QUERY = string.Concat(Constants.API_BASE, "Brand/GetBrandsByQuery?clientID={0}&query={1}");
        public static string GET_BRANDS_BY_STATUS = string.Concat(Constants.API_BASE, "Brand/GetBrandsByStatus?clientID={0}&status={1}");
        public static string GET_BRAND_BY_ID = string.Concat(Constants.API_BASE, "Brand/GetBrandByID?clientID={0}&id={1}");
        public static string GET_COUNT_BRANDS = string.Concat(Constants.API_BASE, "Brand/GetCountBrands?clientID={0}");
        public static string GET_COUNT_BRANDS_BY_STATUS = string.Concat(Constants.API_BASE, "Brand/GetCountBrandsByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_BRAND = string.Concat(Constants.API_BASE, "Brand/SaveBrand");
        public static string POST_UPDATE_BRAND_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Brand/UpdateBrandStatusByIDs");

        public static string GET_CATEGORIES = string.Concat(Constants.API_BASE, "Category/GetCategories?clientID={0}");
        public static string GET_CATEGORIES_BY_QUERY = string.Concat(Constants.API_BASE, "Category/GetCategoriesByQuery?clientID={0}&query={1}");
        public static string GET_CATEGORIES_BY_STATUS = string.Concat(Constants.API_BASE, "Category/GetCategoriesByStatus?clientID={0}&status={1}");
        public static string GET_CATEGORY_BY_ID = string.Concat(Constants.API_BASE, "Category/GetCategoryByID?clientID={0}&id={1}");
        public static string GET_COUNT_CATEGORIES = string.Concat(Constants.API_BASE, "Category/GetCountCategories?clientID={0}");
        public static string GET_COUNT_CATEGORIES_BY_STATUS = string.Concat(Constants.API_BASE, "Category/GetCountCategoriesByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_CATEGORY = string.Concat(Constants.API_BASE, "Category/SaveCategory");
        public static string POST_UPDATE_CATEGORY_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Category/UpdateCategoryStatusByIDs");

        public static string GET_INVENTORIES = string.Concat(Constants.API_BASE, "Inventory/GetInventories?clientID={0}");
        public static string GET_INVENTORIES_BY_QUERY = string.Concat(Constants.API_BASE, "Inventory/GetInventoriesByQuery?clientID={0}&query={1}");
        public static string GET_INVENTORIES_BY_STATUS = string.Concat(Constants.API_BASE, "Inventory/GetInventoriesByStatus?clientID={0}&status={1}");
        public static string GET_INVENTORY_BY_ID = string.Concat(Constants.API_BASE, "Inventory/GetInventoryByID?clientID={0}&id={1}");
        public static string GET_COUNT_INVENTORIES = string.Concat(Constants.API_BASE, "Inventory/GetCountInventories?clientID={0}");
        public static string GET_COUNT_INVENTORIES_BY_STATUS = string.Concat(Constants.API_BASE, "Inventory/GetCountInventoriesByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_INVENTORY = string.Concat(Constants.API_BASE, "Inventory/SaveInventory");
        public static string POST_UPDATE_INVENTORY_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Inventory/UpdateInventoryStatusByIDs");

        public static string GET_SALES = string.Concat(Constants.API_BASE, "Sales/GetSales?clientID={0}");
        public static string GET_SALES_BY_QUERY = string.Concat(Constants.API_BASE, "Sales/GetSalesByQuery?clientID={0}&query={1}");
        public static string GET_SALES_BY_STATUS = string.Concat(Constants.API_BASE, "Sales/GetSalesByStatus?clientID={0}&status={1}");
        public static string GET_SALES_BY_ID = string.Concat(Constants.API_BASE, "Sales/GetSalesByID?clientID={0}&id={1}");
        public static string GET_COUNT_SALES = string.Concat(Constants.API_BASE, "Sales/GetCountSales?clientID={0}");
        public static string GET_COUNT_SALES_BY_STATUS = string.Concat(Constants.API_BASE, "Sales/GetCountSalesByStatus?clientID={0}&status={1}");
        public static string POST_SAVE_SALES = string.Concat(Constants.API_BASE, "Sales/SaveSales");
        public static string POST_UPDATE_SALES_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Sales/UpdateSalesStatusByIDs");

        public static string GET_SALES_REPORT = string.Concat(Constants.API_BASE, "Report/GetSalesReport?clientID={0}");
        public static string GET_SALES_REPORT_BY_YEAR = string.Concat(Constants.API_BASE, "Report/GetSalesReportByYear?clientID={0}&year={1}");
        public static string GET_SALES_REPORT_BY_YEAR_MONTH = string.Concat(Constants.API_BASE, "Report/GetSalesReportByYearAndMonth?clientID={0}&query={1}");
    }
}
