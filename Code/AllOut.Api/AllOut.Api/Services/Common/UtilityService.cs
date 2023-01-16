﻿using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;

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

        public async Task<string> ValidateClientID(Guid ClientID)
        {
            //Check if ClientID is Empty
            if (ClientID == Guid.Empty)
                return Constants.ERROR_CLIENT_EMPTY;

            //Check if ClientID is existing
            var client = await _db.Clients.FindAsync(ClientID);
            if (client == null)
                return Constants.ERROR_CLIENT_NOT_EXIST;

            //Check if Client is Active
            if (client.Status != Constants.STATUS_ENABLED_INT)
                return Constants.ERROR_CLIENT_NOT_VALID;

            //Check Number of Request Threshold
            var clientRequests = await _db.ClientRequests.Where(data => data.ClientID == ClientID)
                                                         .OrderBy(data => data.CreatedDate)
                                                         .ToListAsync();
            if (clientRequests.Any() && clientRequests.Count > Constants.NO_REQUEST_THRESHOLD)
                return Constants.ERROR_CLIENT_EXCEED_REQUEST;

            //Check Number of Hours Active Threshold
            var firstClientRequest = clientRequests.First().CreatedDate;
            if (firstClientRequest != null)
            {
                var noofHours = (DateTime.Now - firstClientRequest).Value.TotalHours;
                if (noofHours > Constants.NO_HOURS_ACTIVE_THRESHOLD)
                    return Constants.ERROR_CLIENT_EXCEED_ACTIVE_HOURS;
            }

            return string.Empty;
        }

        public async Task LogClientRequest(Guid ClientID, RequestType type, string statusCode)
        {
            int number = 0;
            var clientRequest = await _db.ClientRequests.Where(data => data.ClientID == ClientID)
                                                         .OrderBy(data => data.CreatedDate)
                                                         .ToListAsync();
            if(clientRequest.Any())
                number = clientRequest.Count();

            var newClientRequest = new ClientRequest
            {
                ClientID = ClientID,
                Number = number,
                Type = ConvertRequestTypeToString(type),
                Response = statusCode,
                CreatedDate = Globals.EXEC_DATETIME
            };

            await _db.ClientRequests.AddAsync(newClientRequest);
            await _db.SaveChangesAsync();
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