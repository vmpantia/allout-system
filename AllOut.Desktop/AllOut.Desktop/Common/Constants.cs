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
        public const string FORM_PRODUCTS = "Products";
        public const string FORM_BRANDS = "Brands";

        #region STATUS
        public const string STRING_STATUS_ENABLED = "Enabled";
        public const string STRING_STATUS_DISABLED = "Disabled";
        public const string STRING_STATUS_DELETION = "Deletion";
        public const int INT_STATUS_ENABLED = 0;
        public const int INT_STATUS_DISABLED = 1;
        public const int INT_STATUS_DELETION = 2;
        public static Color COLOR_STATUS_ENABLED = Color.FromArgb(39, 174, 96);
        public static Color COLOR_STATUS_DISABLED = Color.FromArgb(64, 64, 64);
        public static Color COLOR_STATUS_DELETION = Color.FromArgb(192, 57, 43);
        #endregion

        #region BRAND
        public const string TITLE_ADD_BRAND = "Add Brand";
        public const string DESCRIPTION_ADD_BRAND = "In this page you can add brand.";
        public const string TITLE_EDIT_BRAND = "Edit Brand";
        public const string DESCRIPTION_EDIT_BRAND = "In this page you can edit brand.";
        #endregion

        public const string ERROR_EMPTY_CREDENTIAL = "Username or Password field is required.";
        public const string ERROR_INCORRECT_CREDENTIAL = "Incorrect Username or Password.";
    }
}
