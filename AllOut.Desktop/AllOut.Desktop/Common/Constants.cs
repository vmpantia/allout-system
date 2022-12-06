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

        #region FORMS
        public const string FORM_PRODUCTS = "Products";
        public const string FORM_BRANDS = "Brands";
        #endregion

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

        public static Font FONT_STATUS = new Font("Segoe UI", 9, FontStyle.Bold);
        #endregion

        #region BRAND
        /*-----------------TITLE-----------------*/
        public const string TITLE_ADD_BRAND = "Add Brand";
        public const string TITLE_EDIT_BRAND = "Edit Brand";
        public const string TITLE_SAVE_BRAND = "Save Brand";

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

        #region MESSAGE
        public const string MESSAGE_OBJECT_SAVED = "{0} has been Saved Successfully! \n";
        public const string MESSAGE_OBJECT_NAME_REQUIRED = "{0} Name field is Required.";
        public const string MESSAGE_OBJECT_UNABLE_EDIT = "Unable to Edit {0}.";
        public const string MESSAGE_EMPTY_CREDENTIAL = "Username or Password field is required.";
        public const string MESSAGE_INCORRECT_CREDENTIAL = "Incorrect Username or Password.";
        #endregion

        #region OBJECT
        public const string OBJECT_PRODUCT = "Product";
        public const string OBJECT_BRAND = "Brand";
        public const string OBJECT_CATEGORY = "Category";
        public const string OBJECT_REQUEST = "Request";
        #endregion

        #region ACTIONS
        public const string BUTTON_NAME_EDIT = "Edit";
        public const string BUTTON_NAME_SELECTION = "Selection";
        public const string BUTTON_HEADER_ACTION = "Action";
        public const string BUTTON_HEADER_SELECT = "Select";
        #endregion

    }
}
