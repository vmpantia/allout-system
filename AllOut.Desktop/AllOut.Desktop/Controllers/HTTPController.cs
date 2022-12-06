using AllOut.Desktop.Models;
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

        public static List<Product> GetProducts()
        {
            var url = string.Concat(APIBaseUrl, "Product/GetProducts");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            try
            {
                var result = new List<Product>();
                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("Request Failed\n");
                    }
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
                        result = (List<Product>)js.Deserialize(objText, typeof(List<Product>));
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Brand> GetBrands()
        {
            var url = string.Concat(APIBaseUrl, "Brand/GetBrands");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            try
            {
                var result = new List<Brand>();
                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("Request Failed\n");
                    }
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
                        result = (List<Brand>)js.Deserialize(objText, typeof(List<Brand>));
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Brand GetBrandByID(Guid brandID)
        {
            var url = string.Concat(APIBaseUrl, "Brand/GetBrandID/", brandID);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            try
            {
                var result = new Brand();
                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("Request Failed\n");
                    }
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
                        result = (Brand)js.Deserialize(objText, typeof(Brand));
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string SaveBrand(BrandRequest request)
        {
            var serializer = new JavaScriptSerializer();
            string data = serializer.Serialize(request);
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
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("Request Failed\n");
                    }
                    using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
                        var result = (string)js.Deserialize(objText, typeof(string));
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
