using AllOut.Desktop.Common;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Controllers
{
    public class HttpController
    {
        #region User
        public static Response PostLoginUserAsync(LoginUserRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_LOGIN_USER;
                var data = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<Client>(content);
                    return customResponse;
                }
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostLogoutUserAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = string.Format(Globals.POST_LOGOUT_USER, clientID);

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, null).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    customResponse.Result = ResponseResult.SUCCESS;
                    return customResponse;
                }
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetUsersAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USERS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<UserFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetUsersByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USERS_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<UserFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetUsersByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USERS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<UserFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetUserByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USER_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<User>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountUsersAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_USERS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountUsersByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_USERS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveUserAsync(SaveUserRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_USER;
                var data = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateUserStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_USER_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region Role
        public static Response GetRolesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Role>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetRolesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Role>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetRolesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Role>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetRoleByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLE_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<Role>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountRolesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_ROLES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountRolesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_ROLES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveRoleAsync(SaveRoleRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_ROLE;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateRoleStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_ROLE_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region Product
        public static Response GetProductsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCTS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<ProductFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetProductsByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCTS_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<ProductFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetProductsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCTS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<ProductFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetProductByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCT_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<Product>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountProductsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_PRODUCTS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountProductsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_PRODUCTS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveProductAsync(SaveProductRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_PRODUCT;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateProductStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_PRODUCT_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region Brand
        public static Response GetBrandsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRANDS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Brand>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetBrandsByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRANDS_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Brand>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetBrandsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRANDS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Brand>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetBrandByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRAND_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<Brand>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountBrandsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_BRANDS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountBrandsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_BRANDS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveBrandAsync(SaveBrandRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_BRAND;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateBrandStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_BRAND_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region Category
        public static Response GetCategoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Category>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCategoriesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORIES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Category>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCategoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<Category>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCategoryByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORY_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<Category>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountCategoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_CATEGORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountCategoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_CATEGORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveCategoryAsync(SaveCategoryRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_CATEGORY;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateCategoryStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_CATEGORY_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region Inventories
        public static Response GetInventoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<InventoryFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetInventoriesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORIES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<InventoryFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetInventoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<InventoryFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetInventoryByIDAsync(Guid clientID, string id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORY_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<Inventory>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountInventoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_INVENTORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountInventoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_INVENTORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveInventoryAsync(SaveInventoryRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_INVENTORY;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateInventoryStatusByIDsAsync(UpdateStatusByStringIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_INVENTORY_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region Sales
        public static Response GetSalesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<SalesFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetSalesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<SalesFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetSalesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<SalesFullInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetSalesByIDAsync(Guid clientID, string id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<SalesFullInformation>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountSalesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_SALES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetCountSalesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_SALES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostSaveSalesAsync(SaveSalesRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_SALES;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response PostUpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_UPDATE_SALES_STATUS_BY_IDS;
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(url, data).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                customResponse.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion

        #region SalesReport
        public static Response GetSalesReportAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_REPORT, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<SalesReportInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetSalesReportByYearAsync(Guid clientID, int year)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_REPORT_BY_YEAR, clientID, year);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<SalesReportInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static Response GetSalesReportByYearAndMonthAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_REPORT_BY_YEAR_MONTH, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync(url).Result;

                //Get content in reponse of API
                var content = httpResponse.Content.ReadAsStringAsync().Result;

                //Generate custom response based on the response of API
                customResponse.StatusCode = httpResponse.StatusCode.ToString();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Success Response
                    customResponse.Result = ResponseResult.SUCCESS;
                    customResponse.Data = JsonConvert.DeserializeObject<List<SalesReportInformation>>(content);
                    return customResponse;
                }
                //API Error Response
                customResponse.Result = ResponseResult.API_ERROR;
                customResponse.Data = content;
            }
            catch (Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion
    }
}
