using AllOut.Web.Blazor.Commons;
using AllOut.Web.Blazor.Contractors;
using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.enums;
using AllOut.Web.Blazor.Models.Requests;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AllOut.Web.Blazor.Services
{
    public class HTTPService : IHTTPService
    {
        public HTTPService()
        {
        }

        #region User
        public Response PostLoginUser(LoginUserRequest request)
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
        public Response GetUsers(Guid clientID)
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
        public Response GetUsersByQuery(Guid clientID, string query)
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
        public Response GetUsersByStatus(Guid clientID, int status)
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
        public Response GetUserByID(Guid clientID, Guid id)
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
        public Response GetCountUsers(Guid clientID)
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
        public Response GetCountUsersByStatus(Guid clientID, int status)
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
        public Response PostSaveUser(SaveUserRequest request)
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
        public Response PostUpdateUserStatusByIDs(UpdateStatusByGUIDsRequest request)
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
        public Response GetRoles(Guid clientID)
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
        public Response GetRolesByQuery(Guid clientID, string query)
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
        public Response GetRolesByStatus(Guid clientID, int status)
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
        public Response GetRoleByID(Guid clientID, Guid id)
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
        public Response GetCountRoles(Guid clientID)
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
        public Response GetCountRolesByStatus(Guid clientID, int status)
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
        public Response PostSaveRole(SaveRoleRequest request)
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
        public Response PostUpdateRoleStatusByIDs(UpdateStatusByGUIDsRequest request)
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
        public Response GetProducts(Guid clientID)
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
        public Response GetProductsByQuery(Guid clientID, string query)
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
        public Response GetProductsByStatus(Guid clientID, int status)
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
        public Response GetProductByID(Guid clientID, Guid id)
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
        public Response GetCountProducts(Guid clientID)
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
        public Response GetCountProductsByStatus(Guid clientID, int status)
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
        public Response PostSaveProduct(SaveProductRequest request)
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
        public Response PostUpdateProductStatusByIDs(UpdateStatusByGUIDsRequest request)
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
        public Response GetBrands(Guid clientID)
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
        public Response GetBrandsByQuery(Guid clientID, string query)
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
        public Response GetBrandsByStatus(Guid clientID, int status)
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
        public Response GetBrandByID(Guid clientID, Guid id)
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
        public Response GetCountBrands(Guid clientID)
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
        public Response GetCountBrandsByStatus(Guid clientID, int status)
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
        public Response PostSaveBrand(SaveBrandRequest request)
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
        public Response PostUpdateBrandStatusByIDs(UpdateStatusByGUIDsRequest request)
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
        public Response GetCategories(Guid clientID)
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
        public Response GetCategoriesByQuery(Guid clientID, string query)
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
        public Response GetCategoriesByStatus(Guid clientID, int status)
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
        public Response GetCategoryByID(Guid clientID, Guid id)
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
        public Response GetCountCategories(Guid clientID)
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
        public Response GetCountCategoriesByStatus(Guid clientID, int status)
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
        public Response PostSaveCategory(SaveCategoryRequest request)
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
        public Response PostUpdateCategoryStatusByIDs(UpdateStatusByGUIDsRequest request)
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
        public Response GetInventories(Guid clientID)
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
        public Response GetInventoriesByQuery(Guid clientID, string query)
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
        public Response GetInventoriesByStatus(Guid clientID, int status)
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
        public Response GetInventoryByID(Guid clientID, string id)
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
        public Response GetCountInventories(Guid clientID)
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
        public Response GetCountInventoriesByStatus(Guid clientID, int status)
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
        public Response PostSaveInventory(SaveInventoryRequest request)
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
        public Response PostUpdateInventoryStatusByIDs(UpdateStatusByStringIDsRequest request)
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
        public Response GetSales(Guid clientID)
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
        public Response GetSalesByQuery(Guid clientID, string query)
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
        public Response GetSalesByStatus(Guid clientID, int status)
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
        public Response GetSalesByID(Guid clientID, string id)
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
        public Response GetCountSales(Guid clientID)
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
        public Response GetCountSalesByStatus(Guid clientID, int status)
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
        public Response PostSaveSales(SaveSalesRequest request)
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
        public Response PostUpdateSalesStatusByIDs(UpdateStatusByStringIDsRequest request)
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
        public Response GetSalesReport(Guid clientID)
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
        public Response GetSalesReportByYear(Guid clientID, int year)
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
        public Response GetSalesReportByYearAndMonth(Guid clientID, string query)
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
