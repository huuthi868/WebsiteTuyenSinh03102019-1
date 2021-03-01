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
    [RoutePrefix("sinh-vien-tieu-bieu")]
    public class TinSinhVienController : Controller
    {
        [Route("")]
        public async Task<ActionResult> TinSinhVien()
        {
            SinhVienTieuBieuViewModel cls = new SinhVienTieuBieuViewModel();
            var Res = await GlobalVariables.WebApiClient.GetAsync("api/HocSinhTieuBieu/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinSinhVien = JsonConvert.DeserializeObject<List<TinSinhVienViewModel>>(obj);
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

            return View("TinSinhVien", cls);
        }

        [Route("{tenlink}-{id}")]
        public async Task<ActionResult> ChiTietSinhVienNoiBat(int id)
        {
            SinhVienTieuBieuViewModel cls = new SinhVienTieuBieuViewModel();
            var Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getTop10TinMoi");
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

            Res = await GlobalVariables.WebApiClient.GetAsync("api/HocSinhTieuBieu/getsinglebyid?ID=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.ChiTietTinSV = JsonConvert.DeserializeObject<TinSinhVienViewModel>(obj);
            }

            return View("ChiTietSinhVienNoiBat", cls);
        }
    }
}