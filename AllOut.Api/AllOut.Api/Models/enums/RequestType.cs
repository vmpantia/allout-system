namespace AllOut.Api.Models.enums
{
    public enum RequestType
    {
        //User Request
        POST_LOGIN_USER = 0,
        GET_USERS,
        GET_USERS_BY_QUERY,
        GET_USER_BY_ID,
        POST_SAVE_USER,
        POST_UPDATE_USER_STATUS_BY_IDS,
        //Product Request
        GET_PRODUCTS,
        GET_PRODUCTS_BY_QUERY,
        GET_PRODUCT_BY_ID,
        POST_SAVE_PRODUCT,
        POST_UPDATE_PRODUCT_STATUS_BY_IDS,
        //Brand Request
        GET_BRANDS,
        GET_BRANDS_BY_QUERY,
        GET_BRAND_BY_ID,
        POST_SAVE_BRAND,
        POST_UPDATE_BRAND_STATUS_BY_IDS,
        //Category Request
        GET_CATEGORIES,
        GET_CATEGORIES_BY_QUERY,
        GET_CATEGORY_BY_ID,
        POST_SAVE_CATEGORY,
        POST_UPDATE_CATEGORY_STATUS_BY_IDS,
        //Inventory Request
        GET_INVENTORIES,
        GET_INVENTORY_BY_ID,
        POST_SAVE_INVENTORY,
        //Sales Request
        POST_SAVE_SALES,
    }
}
