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
    [RoutePrefix("phong-khoa")]
    public class PhongKhoaController : Controller
    {
        [Route("{PhongKhoaLink}/{id}")]
        public async Task<ActionResult> ChiTietPhongKhoa(int id)
        {
            var cls = new PhongKhoaViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync($"api/PhongKhoa/getsinglebyid?ID={id}");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<PhongKhoaViewModel>(obj);
            }

            return View(cls);
        }

        [Route("danh-sach-phong")]
        public async Task<ActionResult> Phong()
        {
            var cls = new List<PhongKhoaViewModel>();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/PhongKhoa/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<List<PhongKhoaViewModel>>(obj);
            }

            return View(cls);
        }

        [Route("danh-sach-khoa")]
        public async Task<ActionResult> Khoa()
        {
            var cls = new List<PhongKhoaViewModel>();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/PhongKhoa/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<List<PhongKhoaViewModel>>(obj);
            }

            return View(cls);
        }
    }
}