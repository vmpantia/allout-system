namespace AllOut.Api.Commons
{
    public class Constants
    {
        public const string FUNCTION_ID_ADD_PRODUCT_BY_ADMIN = "01A00";
        public const string FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN = "01C00";
        public const string FUNCTION_ID_DELETE_PRODUCT_BY_ADMIN = "01D00";

        public static string ERROR_REQUEST_ID_NULL = "Request ID cannot be NULL.";
        public static string ERROR_PRODUCT_REQUEST_NULL = "Product Request cannot be NULL.";
        public static string ERROR_PRODUCT_NOT_FOUND_CHANGE = "Product NOT found, Changes cannot be process.";
        public static string ERROR_PRODUCT_NOT_FOUND_DELETE = "Product NOT found, Deletion cannot be process.";
    }
}
