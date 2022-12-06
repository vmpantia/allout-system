using AllOut.Desktop.Common;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Controllers
{
    public class HttpController 
    {
        private static readonly string APIBaseURL = "https://localhost:7252/api/";

        #region GET METHODS
        public static async Task<Response> GetProducts()
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Concat(APIBaseURL, "Product/GetProducts");

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
                    customResponse.Data = JsonConvert.DeserializeObject<List<Product>>(content);
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
                customResponse.Data = ex.ToString();
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static async Task<Response> GetBrands()
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Concat(APIBaseURL, "Brand/GetBrands");

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
                customResponse.Data = ex.ToString();
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static async Task<Response> GetBrandByID(Guid id)
        {
            var customResponse = new Response();
            try
            {
                //Prepare API URL
                var url = string.Concat(APIBaseURL, "Brand/GetBrandByID/", id);

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
                customResponse.Data = ex.ToString();
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion


        #region POST METHODS    
        public static async Task<Response> PostSaveBrand(BrandRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = string.Concat(APIBaseURL, "Brand/SaveBrand");
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
                customResponse.Data = ex.ToString();
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        public static async Task<Response> PostUpdateStatusByIDs(UpdateStatusByIDsRequest request)
        {
            var customResponse = new Response();
            try
            {
                //Prepare Data and API URL
                var url = string.Concat(APIBaseURL, "Brand/UpdateStatusByIDs");
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
                customResponse.Data = ex.ToString();
                customResponse.StatusCode = Constants.NA;
            }
            return customResponse;
        }
        #endregion
    }
}
