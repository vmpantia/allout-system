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
        public static async Task<Response> PostLoginUserAsync(LoginUserRequest request)
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
                if(httpResponse.StatusCode == HttpStatusCode.OK)
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
        public static async Task<Response> PostSaveUserAsync(SaveUserRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = Globals.POST_SAVE_USER;
                var data = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                //Send POST request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PostAsync(url, data);

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
        public static async Task<Response> GetProductsAsync(Guid clientID)
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
        public static async Task<Response> GetProductsByQueryAsync(Guid clientID, string query)
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
        public static async Task<Response> GetProductByIDAsync(Guid clientID, Guid id)
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
        public static async Task<Response> PostSaveProductAsync(SaveProductRequest request)
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
                var httpResponse = await httpClient.PostAsync(url, data);

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
        public static async Task<Response> PostUpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request)
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
                var httpResponse = await httpClient.PostAsync(url, data);

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
        public static async Task<Response> GetBrandsAsync(Guid clientID)
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
            catch(Exception ex)
            {
                //System Error Response
                customResponse.Result = ResponseResult.SYSTEM_ERROR;
                customResponse.Data = ex.Message;
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static async Task<Response> GetBrandsByQueryAsync(Guid clientID, string query)
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
        public static async Task<Response> GetBrandByIDAsync(Guid clientID, Guid id)
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
        public static async Task<Response> PostSaveBrandAsync(SaveBrandRequest request)
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
                var httpResponse = await httpClient.PostAsync(url, data);

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
        public static async Task<Response> PostUpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request)
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
                var httpResponse = await httpClient.PostAsync(url, data);

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
        public static async Task<Response> GetCategoriesAsync(Guid clientID)
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
        public static async Task<Response> GetCategoriesByQueryAsync(Guid clientID, string query)
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
        public static async Task<Response> GetCategoryByIDAsync(Guid clientID, Guid id)
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
        public static async Task<Response> PostSaveCategoryAsync(SaveCategoryRequest request)
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
                var httpResponse = await httpClient.PostAsync(url, data);

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
        public static async Task<Response> PostUpdateCategoryStatusByIDsAsync(UpdateStatusByIDsRequest request)
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
                var httpResponse = await httpClient.PostAsync(url, data);

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
    }
}
