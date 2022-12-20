namespace AllOut.Api.Common
{
    public class Constants
    {
        public const string NA = "N/A";

        #region Forms
        public const string FORM_PRODUCTS = "Products";
        public const string FORM_BRANDS = "Brands";
        public const string FORM_CATEGORIES = "Categories";
        #endregion

        #region Request ID
        public const string REQUEST_ID_FORMAT = "{0}{1}";
        public const string REQUEST_ID_SUFFIX = "0001";
        public const int REQUEST_ID_LENGTH = 12;
        public const int REQUEST_ID_PREFIX_LENGTH = 8;
        public const int REQUEST_ID_SUFFIX_LENGTH = 4;
        #endregion

        #region Request Status
        public const string REQUEST_STATUS_COMPLETED = "A2";
        public const string REQUEST_STATUS_POST_DELETE = "96";
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

        #endregion

        #region Error Messages
        public const string ERROR_ID_NULL = "{0} ID cannot be NULL.";
        public const string ERROR_REQUEST_NULL = "{0} request cannot be NULL.";
        public const string ERROR_NOT_FOUND_CHANGE = "{0} not found, Changes cannot be process.";
        public const string ERROR_NOT_FOUND_DELETE = "{0} not found, Deletion cannot be process.";
        public const string ERROR_NOT_FOUND = "{0} ID not found.";
        public const string ERROR_NAME_EXIST_DISABLED = "{0} Name already Exist in the System. It's currently Disabled.";
        public const string ERROR_NAME_EXIST = "{0} Brand Name already Exist in the System.";
        public const string ERROR_NO_SELECTED = "No {0}(s) selected.";
        public const string ERROR_NAME_REQUIRED = "{0} Name field is Required.";
        public const string ERROR_UNABLE_EDIT = "Unable to Edit {0}.";
        public const string ERROR_EMPTY_CREDENTIAL = "Username or Password field is required.";
        public const string ERROR_INCORRECT_CREDENTIAL = "Username or Password is incorrect.";
        #endregion

        #region Success Message
        public const string SUCCESS_SAVED = "{0} has been Saved Successfully!\n{1}";
        public const string SUCCESS_UPDATE = "Update {0}(s) Status Successfully!\n{1}";
        #endregion

        #region Confirmation Message
        public const string MESSAGE_CONFIRMATION = "Are you sure you want to {0} {1} {2}(s)?";
        #endregion

        #region Titles
        public const string TITLE_ADD = "Add {0}";
        public const string TITLE_EDIT = "Edit {0}";
        public const string TITLE_SAVE = "Save {0}";
        public const string TITLE_UPDATE_STATUS = "Update {0}(s) Status";
        #endregion

        #region Descriptions
        public const string DESC_ADD = "In this page you can add {0}.";
        public const string DESC_EDIT = "In this page you can edit {0}.";
        #endregion

        #region Objects
        public const string OBJECT_PRODUCT = "Product";
        public const string OBJECT_BRAND = "Brand";
        public const string OBJECT_CATEGORY = "Category";
        public const string OBJECT_REQUEST = "Request";
        #endregion

        #region Action Buttons
        public const string BUTTON_NAME_EDIT = "Edit";
        public const string BUTTON_NAME_SELECTION = "Selection";
        public const string BUTTON_HEADER_ACTION = "Action";
        public const string BUTTON_HEADER_SELECT = "Select";
        #endregion
    }
}
