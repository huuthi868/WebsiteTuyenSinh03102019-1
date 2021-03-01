using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh.Controllers
{
    [RoutePrefix("gioi-thieu")]
    public class GioiThieuController : Controller
    {

        [Route("tong-quan")]
        public async Task<ActionResult> GioiThieuTruong()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=1");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }
            return View(cls);
        }

        [Route("lich-su-phat-trien")]
        public async Task<ActionResult> LichSuPhatTrien()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=2");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }

        [Route("so-do-to-chuc")]
        public async Task<ActionResult> SoDoToChuc()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=3");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }


        [Route("co-so-vat-chat")]
        public async Task<ActionResult> CoSoVatChat()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=4");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }


        [Route("nang-luc-dao-tao")]
        public async Task<ActionResult> NangLucDaoTao()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=5");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }


        [Route("thanh-tich-dat-duoc")]
        public async Task<ActionResult> ThanhTichDatDuoc()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=6");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }


        [Route("dinh-huong-phat-trien")]
        public async Task<ActionResult> DinhHuongPhatTrien()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=7");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }

        [Route("muc-tieu-chat-luong")]
        public async Task<ActionResult> MucTieuChatLuong()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=13");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }

        [Route("ky-yeu-nha-truong")]
        public async Task<ActionResult> KyYeuNhaTruong()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=8");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }


        [Route("ban-giam-hieu")]
        public async Task<ActionResult> BanGiamHieu()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=9");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }

        [Route("dang-bo")]
        public async Task<ActionResult> DangBo()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=10");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }

        [Route("cong-doan")]
        public async Task<ActionResult> CongDoan()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=11");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }


        [Route("doan-thanh-nien")]
        public async Task<ActionResult> DoanThanhNien()
        {
            var cls = new GioiThieuTruongViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/GioiThieuTruong/getsinglebyid?ID=12");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<GioiThieuTruongViewModel>(obj);
            }

            return View(cls);
        }
    }
}