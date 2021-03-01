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
    [RoutePrefix("tin-tuyen-sinh")]
    public class TinTuyenSinhController : Controller
    {
        [Route("thong-bao-tuyen-sinh")]
        public async Task<ActionResult> TinTuyenSinh()
        {
            ThongBaoTuyenSinhViewModel cls = new ThongBaoTuyenSinhViewModel();
            var Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getTop10TinMoi");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            }
            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getTop5TinLienQuan");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinLienQuanTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinLienQuan/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }

            return View("TinTuyenSinh", cls);
        }

        [Route("{tenlink}-{id}")]
        public async Task<ActionResult> ChiTiet(int id)
        {
            ThongBaoTuyenSinhViewModel cls = new ThongBaoTuyenSinhViewModel();
            var Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getTop10TinMoi");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinLienQuan/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getsinglebyid?ID=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.ChiTietTinTS = JsonConvert.DeserializeObject<TinTuyenSinhViewModel>(obj);
            }

            return View("ChiTiet", cls);

        }
    }
}