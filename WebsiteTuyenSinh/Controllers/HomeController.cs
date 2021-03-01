using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh.Controllers
{
    [RoutePrefix("trang-chu")]
    public class HomeController : Controller
    {
        public async Task<ActionResult> TrangChu()
        {
            TrangChuViewModel cls = new TrangChuViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/Slider/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.Slider = JsonConvert.DeserializeObject<List<SliderViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync($"api/TinTuyenSinh/getbySkipTake?skip={0}&take={9}");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.Top3TinTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj).Skip(0).Take(3).ToList();
                cls.TinLienQuanTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj).Skip(3).Take(6).ToList();
            }

            //Res = await GlobalVariables.WebApiClient.GetAsync($"api/TinTuyenSinh/getbySkipTake?skip={3}&take={5}");
            //if (Res.IsSuccessStatusCode)
            //{
            //    var obj = Res.Content.ReadAsStringAsync().Result;
            //    cls.TinLienQuanTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            //}

            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinLienQuan/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }
            return View(cls);
        }
    }
}