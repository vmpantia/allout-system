namespace AllOut.Api.Models.enums
{
    public enum RequestType
    {
        //User Request
        POST_LOGIN_USER = 0,
        GET_USERS,
        GET_USERS_BY_QUERY,
        GET_USERS_BY_STATUS,
        GET_USER_BY_ID,
        GET_COUNT_USERS,
        GET_COUNT_USERS_BY_STATUS,
        POST_SAVE_USER,
        POST_UPDATE_USER_STATUS_BY_IDS,
        //Product Request
        GET_PRODUCTS,
        GET_PRODUCTS_BY_QUERY,
        GET_PRODUCTS_BY_STATUS,
        GET_PRODUCT_BY_ID,
        GET_COUNT_PRODUCTS,
        GET_COUNT_PRODUCTS_BY_STATUS,
        POST_SAVE_PRODUCT,
        POST_UPDATE_PRODUCT_STATUS_BY_IDS,
        //Brand Request
        GET_BRANDS,
        GET_BRANDS_BY_QUERY,
        GET_BRANDS_BY_STATUS,
        GET_BRAND_BY_ID,
        GET_COUNT_BRANDS,
        GET_COUNT_BRANDS_BY_STATUS,
        POST_SAVE_BRAND,
        POST_UPDATE_BRAND_STATUS_BY_IDS,
        //Category Request
        GET_CATEGORIES,
        GET_CATEGORIES_BY_QUERY,
        GET_CATEGORIES_BY_STATUS,
        GET_CATEGORY_BY_ID,
        GET_COUNT_CATEGORIES,
        GET_COUNT_CATEGORIES_BY_STATUS,
        POST_SAVE_CATEGORY,
        POST_UPDATE_CATEGORY_STATUS_BY_IDS,
        //Inventory Request
        GET_INVENTORIES,
        GET_INVENTORIES_BY_QUERY,
        GET_INVENTORIES_BY_STATUS,
        GET_INVENTORY_BY_ID,
        GET_COUNT_INVENTORIES,
        GET_COUNT_INVENTORIES_BY_STATUS,
        POST_SAVE_INVENTORY,
        //Sales Request
        GET_SALES,
        GET_SALES_BY_QUERY,
        GET_SALES_BY_ID,
        POST_SAVE_SALES,
        //Report 
        GET_SALES_REPORT,
        GET_SALES_REPORT_BY_YEAR,
        GET_SALES_REPORT_BY_YEAR_MONTH,
    }
}
