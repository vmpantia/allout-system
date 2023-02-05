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
        public async Task<Response> PostLoginUserAsync(LoginUserRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_LOGIN_USER;
                var data = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PostAsync(url, data);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetUsersAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USERS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetUsersByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USERS_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetUsersByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USERS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetUserByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_USER_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountUsersAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_USERS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountUsersByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_USERS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveUserAsync(SaveUserRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateUserStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetRolesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetRolesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetRolesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetRoleByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_ROLE_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountRolesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_ROLES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountRolesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_ROLES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveRoleAsync(SaveRoleRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateRoleStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetProductsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCTS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetProductsByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCTS_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetProductsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCTS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetProductByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_PRODUCT_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountProductsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_PRODUCTS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountProductsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_PRODUCTS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveProductAsync(SaveProductRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateProductStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetBrandsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRANDS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetBrandsByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRANDS_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetBrandsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRANDS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetBrandByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_BRAND_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountBrandsAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_BRANDS, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountBrandsByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_BRANDS_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveBrandAsync(SaveBrandRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateBrandStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCategoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCategoriesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORIES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCategoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCategoryByIDAsync(Guid clientID, Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_CATEGORY_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountCategoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_CATEGORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountCategoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_CATEGORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveCategoryAsync(SaveCategoryRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateCategoryStatusByIDsAsync(UpdateStatusByGUIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetInventoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetInventoriesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORIES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetInventoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetInventoryByIDAsync(Guid clientID, string id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_INVENTORY_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountInventoriesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_INVENTORIES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountInventoriesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_INVENTORIES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveInventoryAsync(SaveInventoryRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateInventoryStatusByIDsAsync(UpdateStatusByStringIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesByQueryAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_BY_QUERY, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesByIDAsync(Guid clientID, string id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_BY_ID, clientID, id);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountSalesAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_SALES, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetCountSalesByStatusAsync(Guid clientID, int status)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_COUNT_SALES_BY_STATUS, clientID, status);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostSaveSalesAsync(SaveSalesRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> PostUpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request)
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
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesReportAsync(Guid clientID)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_REPORT, clientID);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesReportByYearAsync(Guid clientID, int year)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_REPORT_BY_YEAR, clientID, year);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
        public async Task<Response> GetSalesReportByYearAndMonthAsync(Guid clientID, string query)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Format(Globals.GET_SALES_REPORT_BY_YEAR_MONTH, clientID, query);

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(url);

                //Get content in reponse of API
                var content = await httpResponse.Content.ReadAsStringAsync();

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
