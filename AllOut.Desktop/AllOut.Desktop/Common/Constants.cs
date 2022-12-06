using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    internal class Constants
    {
        public const string NA = "N/A";

        public const string FORM_PRODUCTS = "Products";
        public const string FORM_BRANDS = "Brands";

        #region STATUS
        /*-----------------STRING STATUS-----------------*/
        public const string STRING_STATUS_ENABLED = "Enabled";
        public const string STRING_STATUS_DISABLED = "Disabled";
        public const string STRING_STATUS_DELETION = "Deletion";

        /*-----------------INT STATUS-----------------*/
        public const int INT_STATUS_ENABLED = 0;
        public const int INT_STATUS_DISABLED = 1;
        public const int INT_STATUS_DELETION = 2;

        /*-----------------COLOR STATUS-----------------*/
        public static Color COLOR_STATUS_ENABLED = Color.FromArgb(39, 174, 96);
        public static Color COLOR_STATUS_DISABLED = Color.FromArgb(64, 64, 64);
        public static Color COLOR_STATUS_DELETION = Color.FromArgb(192, 57, 43);
        #endregion

        #region BRAND
        /*-----------------TITLE-----------------*/
        public const string TITLE_ADD_BRAND = "Add Brand";
        public const string TITLE_EDIT_BRAND = "Edit Brand";

        /*-----------------DESCRIPTIONS-----------------*/
        public const string DESCRIPTION_ADD_BRAND = "In this page you can add brand.";
        public const string DESCRIPTION_EDIT_BRAND = "In this page you can edit brand.";

        /*-----------------FUNCTION ID-----------------*/
        public const string FUNCTION_ID_ADD_BRAND_BY_ADMIN = "02A00";
        public const string FUNCTION_ID_CHANGE_BRAND_BY_ADMIN = "02C00";
        public const string FUNCTION_ID_DELETE_BRAND_BY_ADMIN = "02D00";
        #endregion

        #region REQUEST STATUS
        public const string REQUEST_STATUS_COMPLETED = "A2";
        #endregion

        public const string ERROR_EMPTY_CREDENTIAL = "Username or Password field is required.";
        public const string ERROR_INCORRECT_CREDENTIAL = "Incorrect Username or Password.";
    }
}
