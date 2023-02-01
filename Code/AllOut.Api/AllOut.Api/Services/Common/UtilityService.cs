using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.enums;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AllOut.Api.Services.Common
{
    public class UtilityService : IUtilityService
    {
        private readonly AllOutDbContext _db;
        public UtilityService(AllOutDbContext context)
        {
            _db = context;
        }

        #region Public Methods
        public bool CheckProductAvailablity(Product product)
        {
            if (null == product)
                return false;

            return product.Status == Constants.STATUS_ENABLED_INT;
        }

        public bool CheckBrandAvailablity(Brand brand)
        {
            if (null == brand)
                return false;

            return brand.Status == Constants.STATUS_ENABLED_INT;
        }

        public bool CheckCategoryAvailablity(Category category)
        {
            if (null == category)
                return false;

            return category.Status == Constants.STATUS_ENABLED_INT;
        }

        public bool CheckUserAvailability(User user)
        {
            if (null == user)
                return false;

            return user.Status == Constants.STATUS_ENABLED_INT;
        }

        public int GetCurrentStock(int inventories, int sales)
        {
            var result = inventories - sales;
            if (result < 0)
                return 0;
            return result;
        }

        public bool GetReorderState(int stock, int reorderpoint)
        {
            return stock <= reorderpoint;
        }

        public decimal GetTotal(decimal totalItems, decimal totalAdditional, decimal totalDeduction)
        {
            var total = totalItems + totalAdditional + totalDeduction;
            return Math.Round(total, 2);
        }

        public async Task<string> ValidateClient(Guid ClientID, RequestType requestType, string functionID)
        {
            if ((requestType == RequestType.POST_LOGIN_USER) || /*Not Required for ClientID Validation if the Request is Login*/
                (requestType == RequestType.POST_SAVE_USER && 
                 functionID != null && functionID == Constants.FUNCTION_ID_ADD_USER)) /*Not Required for ClientID Validation if the Request is User Registration*/
                return string.Empty;

            //Check if ClientID is Empty
            if (ClientID == Guid.Empty)
                return Constants.ERROR_CLIENT_NOT_VALID;

            //Check if ClientID is existing
            var client = await _db.Clients.FindAsync(ClientID);
            if (client == null)
                return Constants.ERROR_CLIENT_NOT_VALID;

            //Check if Client is Active
            if (client.Status != Constants.STATUS_ENABLED_INT)
                return Constants.ERROR_CLIENT_NOT_VALID;

            //Check Number of Hours Active Threshold
            var firstClientCreated = client.CreatedDate;
            var noofHours = (DateTime.Now - firstClientCreated).TotalHours;
            if (noofHours > Constants.NO_HOURS_ACTIVE_THRESHOLD)
                return Constants.ERROR_CLIENT_NOT_VALID;
            
            var userID = await _db.Users.FindAsync(client.UserID);
            if (userID == null)
                return Constants.ERROR_CLIENT_NOT_VALID;

            if(client.Status != Constants.STATUS_ENABLED_INT)
                return Constants.ERROR_CLIENT_NOT_VALID;


            return string.Empty;
        }

        public bool IsValidName(string name)
        {
            var regex = new Regex(Constants.REGEX_NAME_PATTERN);
            return regex.IsMatch(name);
        }

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(Constants.REGEX_EMAIL_PATTERN);
            return regex.IsMatch(email);
        }

        public bool IsValidPassword(string password)
        {
            var regex = new Regex(Constants.REGEX_PASSWORD_PATTERN);
            var value = DecodePassword(password);
            return regex.IsMatch(value);
        }

        public string EncodePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return password;

            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public string DecodePassword(string password)
        {
            var bytes = Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(bytes);
        }

        #endregion

        #region Private Methods
        private string ConvertRequestTypeToString(RequestType type)
        {
            switch (type)
            {
                case RequestType.POST_LOGIN_USER:
                    return Constants.POST_LOGIN_USER;
                case RequestType.GET_USERS:
                    return Constants.GET_USERS;
                case RequestType.GET_USERS_BY_QUERY:
                    return Constants.GET_USERS_BY_QUERY;
                case RequestType.GET_USER_BY_ID:
                    return Constants.GET_USER_BY_ID;
                case RequestType.POST_SAVE_USER:
                    return Constants.POST_SAVE_USER;
                case RequestType.POST_UPDATE_USER_STATUS_BY_IDS:
                    return Constants.POST_UPDATE_USER_STATUS_BY_IDS;

                case RequestType.GET_PRODUCTS:
                    return Constants.GET_PRODUCTS;
                case RequestType.GET_PRODUCTS_BY_QUERY:
                    return Constants.GET_PRODUCTS_BY_QUERY;
                case RequestType.GET_PRODUCT_BY_ID:
                    return Constants.GET_PRODUCT_BY_ID;
                case RequestType.POST_SAVE_PRODUCT:
                    return Constants.POST_SAVE_PRODUCT;
                case RequestType.POST_UPDATE_PRODUCT_STATUS_BY_IDS:
                    return Constants.POST_UPDATE_PRODUCT_STATUS_BY_IDS;

                case RequestType.GET_BRANDS:
                    return Constants.GET_BRANDS;
                case RequestType.GET_BRANDS_BY_QUERY:
                    return Constants.GET_BRANDS_BY_QUERY;
                case RequestType.GET_BRAND_BY_ID:
                    return Constants.GET_BRAND_BY_ID;
                case RequestType.POST_SAVE_BRAND:
                    return Constants.POST_SAVE_BRAND;
                case RequestType.POST_UPDATE_BRAND_STATUS_BY_IDS:
                    return Constants.POST_UPDATE_BRAND_STATUS_BY_IDS;

                case RequestType.GET_CATEGORIES:
                    return Constants.GET_CATEGORIES;
                case RequestType.GET_CATEGORIES_BY_QUERY:
                    return Constants.GET_CATEGORIES_BY_QUERY;
                case RequestType.GET_CATEGORY_BY_ID:
                    return Constants.GET_CATEGORY_BY_ID;
                case RequestType.POST_SAVE_CATEGORY:
                    return Constants.POST_SAVE_CATEGORY;
                case RequestType.POST_UPDATE_CATEGORY_STATUS_BY_IDS:
                    return Constants.POST_UPDATE_CATEGORY_STATUS_BY_IDS;

                case RequestType.GET_INVENTORIES:
                    return Constants.GET_INVENTORIES;
                case RequestType.GET_INVENTORIES_BY_QUERY:
                    return Constants.GET_INVENTORIES_BY_QUERY;
                case RequestType.GET_INVENTORY_BY_ID:
                    return Constants.GET_INVENTORY_BY_ID;
                case RequestType.POST_SAVE_INVENTORY:
                    return Constants.POST_SAVE_INVENTORY;

                case RequestType.POST_SAVE_SALES:
                    return Constants.POST_SAVE_SALES;

                default:
                    return Constants.NA;
            }
        }
        #endregion
    }
}
