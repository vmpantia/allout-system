using AllOut.Web.Blazor.Commons;
using AllOut.Web.Blazor.Contractors;
using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.enums;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AllOut.Web.Blazor.Services
{
    public class HTTPService : IHTTPService
    {
        private readonly HttpClient _httpClient;
        public HTTPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetRequestAsync(string url, Guid clientID, object? param = null)
        {
            var response = new Response();
            try
            {
                var finalURL = Utility.ParseURL(url, clientID, param);

                //Send GET request to API
                var httpResponse = await _httpClient.GetAsync(finalURL);

                //Get result in response of API
                response.StatusCode = httpResponse.StatusCode.ToString();
                response.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS :
                                                                                 ResponseResult.API_ERROR;

                //Get content in reponse of API
                response.Data = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                //System Error Response
                response.Result = ResponseResult.SYSTEM_ERROR;
                response.Data = ex.Message;
                response.StatusCode = Constants.NA;
            }
            return response;
        }

        public async Task<Response> PostRequestAsync(string url, object request)
        {
            var response = new Response();
            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(request),
                                             Encoding.UTF8,
                                             "application/json");
                //Send POST request to API
                var httpResponse = await _httpClient.PostAsync(url, data);

                //Get result in response of API
                response.StatusCode = httpResponse.StatusCode.ToString();
                response.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS :
                                                                                 ResponseResult.API_ERROR;

                //Get content in reponse of API
                response.Data = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                //System Error Response
                response.Result = ResponseResult.SYSTEM_ERROR;
                response.Data = ex.Message;
                response.StatusCode = Constants.NA;
            }

            return response;
        }
    }
}
