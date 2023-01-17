using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    public class Globals
    {
        public static string POST_LOGIN_USER = string.Concat(Constants.API_BASE, "User/LoginUser");
        public static string GET_USERS = string.Concat(Constants.API_BASE, "User/GetUsers?clientID={0}");
        public static string GET_USERS_BY_QUERY = string.Concat(Constants.API_BASE, "User/GetUsersByQuery?clientID={0}&query={1}");
        public static string GET_USER_BY_ID = string.Concat(Constants.API_BASE, "User/GetUsersByQuery?clientID={0}&id={1}");
        public static string POST_SAVE_USER = string.Concat(Constants.API_BASE, "User/SaveUser");
        public static string POST_UPDATE_USER_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "User/UpdateUserStatusByIDs");

        public static string GET_PRODUCTS = string.Concat(Constants.API_BASE, "Product/GetProducts?clientID={0}");
        public static string GET_PRODUCTS_BY_QUERY = string.Concat(Constants.API_BASE, "Product/GetProductsByQuery?clientID={0}&query={1}");
        public static string GET_PRODUCT_BY_ID = string.Concat(Constants.API_BASE, "Product/GetProductsByQuery?clientID={0}&id={1}");
        public static string POST_SAVE_PRODUCT = string.Concat(Constants.API_BASE, "Product/SaveProduct");
        public static string POST_UPDATE_PRODUCT_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Product/UpdateProductStatusByIDs");

        public static string GET_BRANDS = string.Concat(Constants.API_BASE, "Brand/GetBrands?clientID={0}");
        public static string GET_BRANDS_BY_QUERY = string.Concat(Constants.API_BASE, "Brand/GetBrandsByQuery?clientID={0}&query={1}");
        public static string GET_BRAND_BY_ID = string.Concat(Constants.API_BASE, "Brand/GetBrandsByQuery?clientID={0}&id={1}");
        public static string POST_SAVE_BRAND = string.Concat(Constants.API_BASE, "Brand/SaveBrand");
        public static string POST_UPDATE_BRAND_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Brand/UpdateBrandStatusByIDs");

        public static string GET_CATEGORIES = string.Concat(Constants.API_BASE, "Category/GetCategories?clientID={0}");
        public static string GET_CATEGORIES_BY_QUERY = string.Concat(Constants.API_BASE, "Category/GetCategoriesByQuery?clientID={0}&query={1}");
        public static string GET_CATEGORY_BY_ID = string.Concat(Constants.API_BASE, "Category/GetCategoriesByQuery?clientID={0}&id={1}");
        public static string POST_SAVE_CATEGORY = string.Concat(Constants.API_BASE, "Category/SaveCategory");
        public static string POST_UPDATE_CATEGORY_STATUS_BY_IDS = string.Concat(Constants.API_BASE, "Category/UpdateCategoriestatusByIDs");

        public static string GET_INVENTORIES = string.Concat(Constants.API_BASE, "Inventory/GetInventories?clientID={0}");
        public static string GET_INVENTORIES_BY_QUERY = string.Concat(Constants.API_BASE, "Inventory/GetInventoriesByQuery?clientID={0}&query={1}");
        public static string GET_INVENTORY_BY_ID = string.Concat(Constants.API_BASE, "Inventory/GetInventoriesByQuery?clientID={0}&id={1}");
        public static string POST_SAVE_INVENTORY = string.Concat(Constants.API_BASE, "Inventory/SaveInventory");

        public static string POST_SAVE_SALES = string.Concat(Constants.API_BASE, "Sales/SaveSales");
    }
}
