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
        public async Task<Response> GetRequestAsync(string url, Guid clientID, object? param = null)
        {
            var response = new Response();
            var finalUrl = string.Empty;
            try
            {
                if(param != null)
                {
                    var type = param.GetType();
                    switch (type.Name)
                    {
                        case "Guid":
                            finalUrl = string.Format(url, clientID, (Guid)param);
                            break;
                        case "int":
                            finalUrl = string.Format(url, clientID, (int)param);
                            break;
                        default:
                            finalUrl = string.Format(url, clientID, (string)param);
                            break;
                    }
                }
                else
                {
                    finalUrl = string.Format(url, clientID);
                }

                //Send GET request to API
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync(finalUrl);

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
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PostAsync(url, data);

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
