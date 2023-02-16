namespace AllOut.Web.Blazor.Commons
{
    public class Constants
    {
        public const string HASH = "@l10uTxK@lr0T1r35";

        #region Open Iconic
        public const string OI_PLUS = "oi oi-plus";
        public const string OI_PENCIL = "oi oi-pencil";
        #endregion

        #region Data Type in String
        public const string DT_INT = "int";
        public const string DT_GUID = "Guid";
        #endregion

        #region Common Format
        public const string DATE_FORMAT = "yyyy/MM/dd";
        public const string NA = "N/A";
        public const string NEWLINE = "\n";
        public const string API_BASE = "http://www.allout.api.com/";
        //public const string API_BASE = "https://localhost:7252/";
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

        #region User
        public const string FUNCTION_ID_ADD_USER_BY_ADMIN = "06A00";
        public const string FUNCTION_ID_ADD_USER = "06A01";
        public const string FUNCTION_ID_CHANGE_USER_BY_ADMIN = "06C00";
        public const string FUNCTION_ID_CHANGE_USER = "06C01";
        public const string FUNCTION_ID_BULK_CHANGE_USER_BY_ADMIN = "16C00";
        public const string FUNCTION_ID_DELETE_USER_BY_ADMIN = "06D00";
        public const string FUNCTION_ID_BULK_DELETE_USER_BY_ADMIN = "16D00";
        #endregion

        #region Role
        public const string FUNCTION_ID_ADD_ROLE_BY_ADMIN = "07A00";
        public const string FUNCTION_ID_CHANGE_ROLE_BY_ADMIN = "07C00";
        public const string FUNCTION_ID_BULK_CHANGE_ROLE_BY_ADMIN = "17C00";
        public const string FUNCTION_ID_DELETE_ROLE_BY_ADMIN = "07D00";
        public const string FUNCTION_ID_BULK_DELETE_ROLE_BY_ADMIN = "17D00";
        #endregion

        #endregion

        #region Error Messages
        public const string ERROR_NO_RECORDS = "No records found in the system.";
        #endregion

        #region Forms
        public const string LINK_LOGIN = "/Login";
        public const string LINK_DASHBOARD = "/Dashboard";
        public const string LINK_INVENTORY = "/Inventory";
        public const string LINK_SALES = "/Sales";
        public const string LINK_PRODUCT = "/Product";
        public const string LINK_BRAND = "/Brand";
        public const string LINK_CATEGORY = "/Category";
        public const string LINK_USER = "/User";
        public const string LINK_ROLE = "/Role";
        #endregion

        #region Titles
        public const string TITLE_ADD = "Add {0}";
        public const string TITLE_EDIT = "Edit {0}";
        #endregion

        #region Descriptions
        public const string DESC_ADD = "In this page you can add {0}.";
        public const string DESC_EDIT = "In this page you can edit {0}.";
        #endregion

        #region Objects
        public const string OBJECT_USER = "User";
        public const string OBJECT_ROLE = "Role";
        public const string OBJECT_PRODUCT = "Product";
        public const string OBJECT_BRAND = "Brand";
        public const string OBJECT_CATEGORY = "Category";
        public const string OBJECT_INVENTORY = "Inventory";
        public const string OBJECT_SALES = "Sales";
        public const string OBJECT_REQUEST = "Request";

        public const string OBJECT_PERMISSION = "Permission";
        #endregion
    }
}
