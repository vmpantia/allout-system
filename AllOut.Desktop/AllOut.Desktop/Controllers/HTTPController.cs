﻿using AllOut.Desktop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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


        public static string SaveBrand()
    }
}
