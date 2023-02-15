using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    public class Constants
    {
        public const string HASH = "@l10uTxK@lr0T1r35";
        public const string APP_VERSION = "AllOut.Version 2023.02";
        //public const string API_BASE = "http://www.allout.api.com/";
        public const string API_BASE = "https://localhost:7252/";

        #region Common
        public const string FOLDER_PATH_FORMAT = @"{0}\{1}\";
        public const string EXCEL_FILE_FORMAT = "{0}_{1}.xlsx";
        public const string YEAR_MONTH_FORMAT = "{0}-{1}";
        public const string DATE_FORMAT = "yyyy/MM/dd";
        public const string DATETIME_FORMAT = "yyyyyMMddHHmmss";
        public const string NA = "N/A";
        public const string NAME_FORMAT = "{0}, {1}";
        public const string USERNAME_FORMAT = "{0}.{1}";
        public const char ZERO = '0';
        public const string NEWLINE = "\n";
        #endregion

        #region Regex Patterns
        public const string REGEX_NUMBER_PATTERN = "^-?[0-9]\\d*(\\.\\d+)?$";
        #endregion

        #region Chart Series
        public const string SERIES_TOTAL = "Total";
        #endregion

        #region Sales Format
        public const string PESO_FORMAT = "₱ {0}";
        public const string DEFAULT_AMOUNT = "₱ 0.00";
        public const string N0_FORMAT = "N2";
        public const string CASHIER_POS_FORMAT = "Cashier: {0}";
        public const string SALESID_POS_FORMAT = "Sales ID: {0}";
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
        public const string ERROR_NAME_REQUIRED = "{0} Name field is Required.";
        public const string ERROR_PASSWORD_NOT_MATCH = "Password doesn't match in Confirm Password.";
        public const string ERROR_NO_RECORDS = "No records found in the system.";
        #endregion

        #region Success Message
        public const string SUCCESS_SAVED = "{0} has been Saved Successfully!\n{1}";
        public const string SUCCESS_UPDATE = "Update {0}(s) Status Successfully!\n{1}";
        #endregion

        #region Confirmation Message
        public const string MESSAGE_CONFIRMATION = "Are you sure you want to {0} {1} {2}(s)?";
        #endregion

        #region Forms
        public const string FORM_DASHBOARD = "Dashboard";
        public const string FORM_INVENTORY = "Inventory";
        public const string FORM_SALES = "Sales";
        public const string FORM_PRODUCT = "Product";
        public const string FORM_BRAND = "Brand";
        public const string FORM_CATEGORY = "Category";
        public const string FORM_USER = "User";
        public const string FORM_ROLE = "Role";

        public const string FORM_SALES_REPORT = "Sales Report";
        public const string FORM_PRODUCTS_REPORT = "Products Report";
        #endregion

        #region Titles
        public const string TITLE_ADD = "Add {0}";
        public const string TITLE_EDIT = "Edit {0}";
        public const string TITLE_SAVE = "Save {0}";
        public const string TITLE_REGISTER = "Register {0}";
        public const string TITLE_UPDATE_STATUS = "Update {0}(s) Status";
        #endregion

        #region Descriptions
        public const string DESC_ADD = "In this page you can add {0}.";
        public const string DESC_EDIT = "In this page you can edit {0}.";
        public const string DESC_FORM = "In this page you can view all the {0} that is saved in the system.";
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

        #region Action Buttons
        public const string BUTTON_NAME_DELETE = "Delete";
        public const string BUTTON_NAME_EDIT = "Edit";
        public const string BUTTON_NAME_SELECTION = "Selection";
        public const string BUTTON_HEADER_ACTION = "Action";
        public const string BUTTON_HEADER_SELECT = "Select";
        #endregion

        #region ToolTip
        public const string TOOLTIP_SEARCH = "Search {0}";
        #endregion

        #region Combobox Configuration
        public const string CMB_PLACEHOLDER = "Select {0}";
        public const string CMB_DISPLAY_NAME = "Name";
        public const string CMB_DISPLAY_PRODUCT_NAME = "ProductName";
        public const string CMB_VALUE_PRODUCT_ID = "ProductID";
        public const string CMB_VALUE_BRAND_ID = "BrandID";
        public const string CMB_VALUE_CATEGORY_ID = "CategoryID"; 
        public const string CMB_VALUE_ROLE_ID = "RoleID";


        public const string CMB_DISPLAY_MONTH_STRING = "MonthString";
        public const string CMB_VALUE_MONTH_INT = "MonthInt";
        public const string CMB_DISPLAY_YEAR_STRING = "YearString";
        public const string CMB_VALUE_YEAR_INT = "YearInt";
        #endregion

        #region Months
        public const string ALL = "All";
        public const string MONTH_JAN = "JANUARY";
        public const string MONTH_FEB = "FEBRUARY";
        public const string MONTH_MAR = "MARCH";
        public const string MONTH_APR = "APRIL";
        public const string MONTH_MAY = "MAY";
        public const string MONTH_JUN = "JUNE";
        public const string MONTH_JUL = "JULY";
        public const string MONTH_AUG = "AUGUST";
        public const string MONTH_SEP = "SEPTEMBER";
        public const string MONTH_OCT = "OCTOBER";
        public const string MONTH_NOV = "NOVEMBER";
        public const string MONTH_DEC = "DECEMBER";
        #endregion

        #region Data Type
        public const string DATA_TYPE_DECIMAL = "Decimal";
        #endregion

        #region Property
        public const string PROPERTY_STATUS = "Status";
        public const string PROPERTY_DATE = "Date";
        #endregion
    }
}
