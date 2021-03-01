using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebsiteTuyenSinh
{
    public class GlobalVariables
    {
        private const string UriStringTruong = "http://api.cdktcnqn.edu.vn/";
        private const string UriString = "http://api-bantuyensinh.cdktcnqn.edu.vn/";
        //private const string UriString = "http://localhost:5000/";
        public static HttpClient WebApiClient = new HttpClient();
        public static HttpClient WebApiTruong = new HttpClient();
     
        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri(UriString);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            WebApiTruong.BaseAddress = new Uri(UriStringTruong);
            WebApiTruong.DefaultRequestHeaders.Clear();
            WebApiTruong.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       // public static object WebApiTruong { get; internal set; }
    }
}