namespace AllOut.Api.Commons
{
    public class Constants
    {
        public const string REQUEST_ID_FORMAT = "{0}{1}";
        public const string REQUEST_ID_SUFFIX = "0001";
        public const int REQUEST_ID_LENGTH = 12;
        public const int REQUEST_ID_PREFIX_LENGTH = 8;
        public const int REQUEST_ID_SUFFIX_LENGTH = 4;

        #region PRODUCT FUNCTIONID
        public const string FUNCTION_ID_ADD_PRODUCT_BY_ADMIN = "01A00";
        public const string FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN = "01C00";
        public const string FUNCTION_ID_DELETE_PRODUCT_BY_ADMIN = "01D00";
        #endregion

        #region BRAND FUNCTIONID
        public const string FUNCTION_ID_ADD_BRAND_BY_ADMIN = "02A00";
        public const string FUNCTION_ID_CHANGE_BRAND_BY_ADMIN = "02C00";
        public const string FUNCTION_ID_DELETE_BRAND_BY_ADMIN = "02D00";
        #endregion

        #region CATEGORY FUNCTIONID
        public const string FUNCTION_ID_ADD_CATEGORY_BY_ADMIN = "03A00";
        public const string FUNCTION_ID_CHANGE_CATEGORY_BY_ADMIN = "03C00";
        public const string FUNCTION_ID_DELETE_CATEGORY_BY_ADMIN = "03D00";
        #endregion

        #region ERROR MESSAGES
        public static string ERROR_OBJECT_ID_NULL = "{0} ID cannot be NULL.";
        public static string ERROR_OBJECT_REQUEST_NULL = "{0} Request cannot be NULL.";
        public static string ERROR_OBJECT_NOT_FOUND_CHANGE = "{0} NOT found, Changes cannot be process.";
        public static string ERROR_OBJECT_NOT_FOUND_DELETE = "{0} NOT found, Deletion cannot be process.";
        public static string ERROR_OBJECT_NOT_FOUND = "{0} ID NOT found.";
        #endregion

        #region Object
        public static string OBJECT_PRODUCT = "Product";
        public static string OBJECT_BRAND = "Brand";
        public static string OBJECT_CATEGORY = "Category";
        public static string OBJECT_REQUEST = "Request";
        #endregion
    }
}
