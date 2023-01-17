namespace AllOut.Api.Common
{
    public class Constants
    {
        public const string NA = "N/A";
        public const string NAME_FORMAT = "{0}, {1}";
        public const char ZERO = '0';
        public const string HASH = "@l10uTxK@lr0T1r35";

        #region Regex Pattern
        public const string REGEX_EMAIL_PATTERN = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";
        public const string REGEX_NAME_PATTERN = "^[A-Z][-a-zA-Z]+$";
        public const string REGEX_PASSWORD_PATTERN = "^^(?=.*[a-z].*[a-z])(?=.*[!\"#...\\d].*[!\"#...\\d]).{8,15}$";
        #endregion

        #region Client Thresholds
        public const int NO_HOURS_ACTIVE_THRESHOLD = 2;
        #endregion

        #region ID
        public const string REQUEST_ID_FORMAT = "RE{0}{1}";
        public const string INVENTORY_ID_FORMAT = "IN{0}{1}";
        public const string SALES_ID_FORMAT = "SA{0}{1}";

        public const string ID_DEFAULT_SUFFIX = "00001";
        public const int ID_LENGTH = 15;
        public const int ID_PREFIX_LENGTH = 10;
        public const int ID_SUFFIX_LENGTH = 5;
        #endregion

        #region Status Codes
        public const string STATUS_CODE_OK = "OK | 200";
        public const string STATUS_CODE_NOTFOUND = "NOT FOUND | 404";
        public const string STATUS_CODE_CONFLICT = "CONFLICT | 409";
        public const string STATUS_CODE_UNAUTHORIZED = "UNAUTHORIZED | 401";
        #endregion

        #region Request Status
        public const string REQUEST_STATUS_COMPLETED = "A2";
        public const string REQUEST_STATUS_POST_DELETE = "96";
        #endregion

        #region Request Types
        public const string POST_LOGIN_USER = "POST_LOGIN_USER";
        public const string GET_USERS = "GET_USERS";
        public const string GET_USERS_BY_QUERY = "GET_USERS_BY_QUERY";
        public const string GET_USER_BY_ID = "GET_USER_BY_ID";
        public const string POST_SAVE_USER = "POST_SAVE_USER";
        public const string POST_UPDATE_USER_STATUS_BY_IDS = "POST_UPDATE_USER_STATUS_BY_IDS";

        public const string GET_PRODUCTS = "GET_PRODUCTS";
        public const string GET_PRODUCTS_BY_QUERY = "GET_PRODUCTS_BY_QUERY";
        public const string GET_PRODUCT_BY_ID = "GET_PRODUCT_BY_ID";
        public const string POST_SAVE_PRODUCT = "POST_SAVE_PRODUCT";
        public const string POST_UPDATE_PRODUCT_STATUS_BY_IDS = "POST_UPDATE_PRODUCT_STATUS_BY_IDS";

        public const string GET_BRANDS = "GET_BRANDS";
        public const string GET_BRANDS_BY_QUERY = "GET_BRANDS_BY_QUERY";
        public const string GET_BRAND_BY_ID = "GET_BRAND_BY_ID";
        public const string POST_SAVE_BRAND = "POST_SAVE_BRAND";
        public const string POST_UPDATE_BRAND_STATUS_BY_IDS = "POST_UPDATE_BRAND_STATUS_BY_IDS";

        public const string GET_CATEGORIES = "GET_CATEGORIES";
        public const string GET_CATEGORIES_BY_QUERY = "GET_CATEGORIES_BY_QUERY";
        public const string GET_CATEGORY_BY_ID = "GET_CATEGORY_BY_ID";
        public const string POST_SAVE_CATEGORY = "POST_SAVE_CATEGORY";
        public const string POST_UPDATE_CATEGORY_STATUS_BY_IDS = "POST_UPDATE_CATEGORY_STATUS_BY_IDS";

        public const string GET_INVENTORIES = "GET_INVENTORIES";
        public const string GET_INVENTORIES_BY_QUERY = "GET_INVENTORIES_BY_QUERY";
        public const string GET_INVENTORY_BY_ID = "GET_INVENTORY_BY_ID";
        public const string POST_SAVE_INVENTORY = "POST_SAVE_INVENTORY";

        public const string POST_SAVE_SALES = "POST_SAVE_SALES";
        #endregion

        #region Status
        public const string STATUS_ENABLED_STRING = "Enabled";
        public const string STATUS_DISABLED_STRING = "Disabled";
        public const string STATUS_DELETION_STRING = "Deletion";

        public const string STATUS_ENABLE_STRING = "Enable";
        public const string STATUS_DISABLE_STRING = "Disable";
        public const string STATUS_DELETE_STRING = "Delete";

        public const int STATUS_ENABLED_INT = 0;
        public const int STATUS_DISABLED_INT = 1;
        public const int STATUS_DELETION_INT = 2;
        #endregion

        #region Function ID

        #region User
        public const string FUNCTION_ID_ADD_USER_BY_ADMIN = "00A00";
        public const string FUNCTION_ID_ADD_USER = "00A01";
        public const string FUNCTION_ID_CHANGE_USER_BY_ADMIN = "00C00";
        public const string FUNCTION_ID_CHANGE_USER = "00C01";
        public const string FUNCTION_ID_BULK_CHANGE_USER_BY_ADMIN = "10C00";
        public const string FUNCTION_ID_DELETE_USER_BY_ADMIN = "00D00";
        public const string FUNCTION_ID_BULK_DELETE_USER_BY_ADMIN = "10D00";
        #endregion

        #region Product
        public const string FUNCTION_ID_ADD_PRODUCT_BY_ADMIN = "01A00";
        public const string FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN = "01C00";
        public const string FUNCTION_ID_BULK_CHANGE_PRODUCT_BY_ADMIN = "11C00";
        public const string FUNCTION_ID_DELETE_PRODUCT_BY_ADMIN = "01D00";
        public const string FUNCTION_ID_BULK_DELETE_PRODUCT_BY_ADMIN = "11D00";
        #endregion

        #region Brand
        public const string FUNCTION_ID_ADD_BRAND_BY_ADMIN = "02A00";
        public const string FUNCTION_ID_CHANGE_BRAND_BY_ADMIN = "02C00";
        public const string FUNCTION_ID_BULK_CHANGE_BRAND_BY_ADMIN = "12C00";
        public const string FUNCTION_ID_DELETE_BRAND_BY_ADMIN = "02D00";
        public const string FUNCTION_ID_BULK_DELETE_BRAND_BY_ADMIN = "12D00";
        #endregion

        #region Category
        public const string FUNCTION_ID_ADD_CATEGORY_BY_ADMIN = "03A00";
        public const string FUNCTION_ID_CHANGE_CATEGORY_BY_ADMIN = "03C00";
        public const string FUNCTION_ID_BULK_CHANGE_CATEGORY_BY_ADMIN = "13C00";
        public const string FUNCTION_ID_DELETE_CATEGORY_BY_ADMIN = "03D00";
        public const string FUNCTION_ID_BULK_DELETE_CATEGORY_BY_ADMIN = "13D00";
        #endregion

        #region Inventory
        public const string FUNCTION_ID_ADD_INVENTORY_BY_ADMIN = "04A00";
        public const string FUNCTION_ID_CHANGE_INVENTORY_BY_ADMIN = "04C00";
        public const string FUNCTION_ID_BULK_CHANGE_INVENTORY_BY_ADMIN = "14C00";
        public const string FUNCTION_ID_DELETE_INVENTORY_BY_ADMIN = "04D00";
        public const string FUNCTION_ID_BULK_DELETE_INVENTORY_BY_ADMIN = "14D00";
        #endregion

        #region Sales
        public const string FUNCTION_ID_ADD_SALES_BY_ADMIN = "05A00";
        public const string FUNCTION_ID_ADD_SALES = "05A01";
        public const string FUNCTION_ID_CHANGE_SALES_BY_ADMIN = "05C00";
        public const string FUNCTION_ID_CHANGE_SALES = "05C01";
        public const string FUNCTION_ID_BULK_CHANGE_SALES_BY_ADMIN = "15C00";
        public const string FUNCTION_ID_DELETE_SALES_BY_ADMIN = "05D00";
        public const string FUNCTION_ID_BULK_DELETE_SALES_BY_ADMIN = "15D00";
        #endregion

        #endregion

        #region Error Messages
        public const string ERROR_NULL = "{0} cannot be NULL.";
        public const string ERROR_ID_NULL = "{0} ID cannot be NULL.";
        public const string ERROR_REQUEST_NULL = "{0} request cannot be NULL.";
        public const string ERROR_NOT_FOUND_CHANGE = "{0} not found, Changes cannot be process.";
        public const string ERROR_NOT_FOUND_DELETE = "{0} not found, Deletion cannot be process.";
        public const string ERROR_NOT_FOUND = "{0} ID not found.";
        public const string ERROR_NAME_EXIST_DISABLED = "{0} Name already Exist in the System. It's currently Disabled.";
        public const string ERROR_NAME_EXIST = "{0} Name already Exist in the System.";
        public const string ERROR_NO_CHANGES = "No changes made in {0}.";
        public const string ERROR_NAME_REQUIRED = "{0} Name field is Required.";
        public const string ERROR_REQUIRED_FIELDS = "Required fields must have values.";
        public const string ERROR_PRODUCT_NOT_EXIST = "Product not Exist in the System";
        public const string ERROR_EMPTY_CREDENTIAL = "Username/Email or Password field is required.";
        public const string ERROR_INCORRECT_CREDENTIAL = "Username/Email or Password is incorrect.";
        public const string ERROR_GENERATE_CLIENT = "Error in generating user client.";
        public const string ERROR_CLIENT_NOT_VALID = "Your Client ID is NOT authorized to process this request.";
        public const string ERROR_EMAIL_NOT_VALID = "{0} is not a valid email.";
        public const string ERROR_NAME_NOT_VALID = "First Name or Last Name is not a valid name.";
        public const string ERROR_PASSWORD_NOT_VALID = "Password is not a valid password for the system.";
        #endregion

        #region Objects
        public const string OBJECT_USER = "User";
        public const string OBJECT_PRODUCT = "Product";
        public const string OBJECT_BRAND = "Brand";
        public const string OBJECT_CATEGORY = "Category";
        public const string OBJECT_INVENTORY = "Inventory";
        public const string OBJECT_SALES = "Sales";
        public const string OBJECT_REQUEST = "Request";
        #endregion
    }
}
