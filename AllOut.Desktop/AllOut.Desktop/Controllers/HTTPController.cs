using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace AllOut.Desktop.Controllers
{
    public class HTTPController
    {
        private const string APIBaseUrl = "https://localhost:7252/api/";

        #region GET METHODS
        public static Response GetProducts()
        {
            var response = new Response();
            var url = string.Concat(APIBaseUrl, "Product/GetProducts");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            try
            {
                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();

                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var data = (List<Product>)js.Deserialize(objText, typeof(List<Product>));
                            response.Result = ResponseResult.SUCCESS;
                            response.Data = data;
                        }
                        else
                        {
                            var message = (string)js.Deserialize(objText, typeof(string));
                            response.Result = ResponseResult.API_ERROR;
                            response.Message = message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Result = ResponseResult.SYSTEM_ERROR;
                response.Message = ex.Message;
            }
            return response;
        }
        public static Response GetBrands()
        {
            var response = new Response();
            var url = string.Concat(APIBaseUrl, "Brand/GetBrands");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            try
            {
                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();

                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var data = (List<Brand>)js.Deserialize(objText, typeof(List<Brand>));
                            response.Result = ResponseResult.SUCCESS;
                            response.Data = data;
                        }
                        else
                        {
                            var message = (string)js.Deserialize(objText, typeof(string));
                            response.Result = ResponseResult.API_ERROR;
                            response.Message = message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Result = ResponseResult.SYSTEM_ERROR;
                response.Message = ex.Message;
            }
            return response;
        }
        public static Response GetBrandByID(Guid id)
        {
            var response = new Response();
            var url = string.Concat(APIBaseUrl, "Brand/GetBrandByID/", id);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            try
            {
                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();

                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var data = (Brand)js.Deserialize(objText, typeof(Brand));
                            response.Result = ResponseResult.SUCCESS;
                            response.Data = data;
                        }
                        else
                        {
                            var message = (string)js.Deserialize(objText, typeof(string));
                            response.Result = ResponseResult.API_ERROR;
                            response.Message = message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Result = ResponseResult.SYSTEM_ERROR;
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion

        #region POST METHODS    
        public static Response SaveBrand(BrandRequest request)
        {
            var response = new Response();
            var js = new JavaScriptSerializer();
            string data = js.Serialize(request);
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            var url = string.Concat(APIBaseUrl, "Brand/SaveBrand");
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.KeepAlive = true;
            webRequest.ContentLength = byteArray.Length;

            try
            {
                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                using (var httpResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        var message = (string)js.Deserialize(objText, typeof(string));
                        response.Result = httpResponse.StatusCode == HttpStatusCode.OK ? ResponseResult.SUCCESS : ResponseResult.API_ERROR;
                        response.Message = message;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Result = ResponseResult.SYSTEM_ERROR;
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
