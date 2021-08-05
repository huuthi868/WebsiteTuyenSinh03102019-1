using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh.Controllers
{
    [RoutePrefix("trang-chu")]
    public class HomeController : Controller
    {
        public async Task<ActionResult> TrangChu()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateDangKyTuVan(string model)
        {
            var cls = new JavaScriptSerializer();
            var entity = cls.Deserialize<DangKyTuVanViewModel>(model);

            var strCauHoi = entity.NgheTuVan.Split(',', '\"').Where(x => x.Length > 3);
            var cauhoi = "";
            foreach (var item in strCauHoi)
            {
                cauhoi += item + ",";
            }

            cauhoi = cauhoi.Substring(0, cauhoi.Length - 1);
            entity.NgheTuVan = cauhoi;

            var Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/DangKyTuVan/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("TrangChu");
        }
    }
}