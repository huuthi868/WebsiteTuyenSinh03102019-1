using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        public static List<PhongKhoaViewModel> lstPhongKHoa;
        public static List<PhongKhoa_NgheViewModel> lstNgheDaoTao;
        public static List<TinTuyenSinhViewModel> TinTuyenSinh;
        public static List<TinLienQuanViewModel> TinLienQuan;

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var WebApiClient = new HttpClient();
            WebApiClient.BaseAddress = new Uri("http://api-bantuyensinh.cdktcnqn.edu.vn/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var WebApiTruong = new HttpClient();
            WebApiTruong.BaseAddress = new Uri("http://api.cdktcnqn.edu.vn/");
            WebApiTruong.DefaultRequestHeaders.Clear();
            WebApiTruong.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            var restruong = WebApiTruong.GetAsync("api/PhongKhoa/getall").Result;
            if (restruong.IsSuccessStatusCode)
            {
                var obj = restruong.Content.ReadAsStringAsync().Result;
                lstPhongKHoa = JsonConvert.DeserializeObject<List<PhongKhoaViewModel>>(obj);
            }
            var res = WebApiClient.GetAsync("api/TinTuyenSinh/getall").Result;
            if (res.IsSuccessStatusCode)
            {
                var obj = res.Content.ReadAsStringAsync().Result;
                TinTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            }
            res = WebApiClient.GetAsync("api/TinLienQuan/getall").Result;
            if (res.IsSuccessStatusCode)
            {
                var obj = res.Content.ReadAsStringAsync().Result;
                TinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }
            restruong = WebApiTruong.GetAsync("api/PhongKhoa_Nghe/getall").Result;
            if (restruong.IsSuccessStatusCode)
            {
                var obj = restruong.Content.ReadAsStringAsync().Result;
                lstNgheDaoTao = JsonConvert.DeserializeObject<List<PhongKhoa_NgheViewModel>>(obj);
            }
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
    }

 
}
