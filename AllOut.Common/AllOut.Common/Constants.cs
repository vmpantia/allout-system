namespace AllOut.Common
{
    public class Constants
    {
        #region Request ID
        public const string REQUEST_ID_FORMAT = "{0}{1}";
        public const string REQUEST_ID_SUFFIX = "0001";
        public const int REQUEST_ID_LENGTH = 12;
        public const int REQUEST_ID_PREFIX_LENGTH = 8;
        public const int REQUEST_ID_SUFFIX_LENGTH = 4;
        #endregion

        #region Status
        public const string STATUS_ENABLED_STRING = "Enabled";
        public const string STATUS_DISABLED_STRING = "Disabled";
        public const string STATUS_DELETION_STRING = "Deletion";

        public const int STATUS_ENABLED_INT= 0;
        public const int STATUS_DISABLED_INT = 1;
        public const int STATUS_DELETION_INT = 2;
        #endregion

        #region Function ID
            #region Product
            public const string FUNCTION_ID_ADD_PRODUCT_BY_ADMIN = "01A00";
            public const string FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN = "01C00";
            public const string FUNCTION_ID_DELETE_PRODUCT_BY_ADMIN = "01D00";
            #endregion

            #region Brand
            public const string FUNCTION_ID_ADD_BRAND_BY_ADMIN = "02A00";
            public const string FUNCTION_ID_CHANGE_BRAND_BY_ADMIN = "02C00";
            public const string FUNCTION_ID_DELETE_BRAND_BY_ADMIN = "02D00";
            #endregion

            #region Category
            public const string FUNCTION_ID_ADD_CATEGORY_BY_ADMIN = "03A00";
            public const string FUNCTION_ID_CHANGE_CATEGORY_BY_ADMIN = "03C00";
            public const string FUNCTION_ID_DELETE_CATEGORY_BY_ADMIN = "03D00";
        #endregion
        #endregion

        #region Error Messages
        public const string ERROR_OBJECT_ID_NULL = "{0} ID cannot be NULL.";
        public const string ERROR_OBJECT_REQUEST_NULL = "{0} request cannot be NULL.";
        public const string ERROR_OBJECT_NOT_FOUND_CHANGE = "{0} not found, Changes cannot be process.";
        public const string ERROR_OBJECT_NOT_FOUND_DELETE = "{0} not found, Deletion cannot be process.";
        public const string ERROR_OBJECT_NOT_FOUND = "{0} ID not found.";
        public const string ERROR_OBJECT_NAME_EXIST_DISABLED = "{0} Name already Exist in the System. It's currently Disabled.";
        public const string ERROR_OBJECT_NAME_EXIST = "{0} Brand Name already Exist in the System.";
        #endregion

        #region Objects
        public const string OBJECT_PRODUCT = "Product";
        public const string OBJECT_BRAND = "Brand";
        public const string OBJECT_CATEGORY = "Category";
        public const string OBJECT_REQUEST = "Request";
        #endregion

    }
}