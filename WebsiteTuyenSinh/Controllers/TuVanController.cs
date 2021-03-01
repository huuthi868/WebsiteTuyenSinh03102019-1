using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh.Controllers
{
    [RoutePrefix("hoi-dap")]

    public class TuVanController : Controller
    {
        public async Task<ActionResult> TuVan()
        {
            TuVanTrucTuyenViewModel cls = new TuVanTrucTuyenViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/TinLienQuan/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.lstTinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/HoiDap/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.lstHoiDap = JsonConvert.DeserializeObject<List<HoiDapViewModel>>(obj);
            }

            return View("TuVan", cls);
        }

        [Route("tim-kiem")]
        public async Task<ActionResult> TimKiem(string tukhoa)
        {
            TuVanTrucTuyenViewModel cls = new TuVanTrucTuyenViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/TinLienQuan/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.lstTinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/hoidap/getbysearch?tukhoa=" + tukhoa);
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.lstHoiDap = JsonConvert.DeserializeObject<List<HoiDapViewModel>>(obj);
            }

            ViewBag.TuKhoa = tukhoa;
            return View("TuVan", cls);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHoiDap(string model)
        {
            JavaScriptSerializer cls = new JavaScriptSerializer();
            HoiDapViewModel entity = cls.Deserialize<HoiDapViewModel>(model);
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/HoiDap/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("TuVan");
        }
    }
}