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
    [RoutePrefix("ket-qua")]
    public class KetQuaController : Controller
    {
        // GET: KetQua
        public ActionResult KetQua()
        {
            return View();
        }
        
        [Route("tim-kiem")]
        public async Task<ActionResult> GetKetQua(string hoten = null, string ngaysinh = null, string hedangky = null)
        {
            IList<KetQuaViewModel> cls = null;
            string strApi = "";
            switch (hedangky)
            {
                case "lien-thong-cao-dang":
                    strApi = "api/DangKyLienThongCaoDang/getketqua?HoTen=" + hoten + "&NgaySinh=" + ngaysinh; break;
                case "trung-cap-thcs":
                    strApi = "api/DangKyTrungCap2Nam/getketqua?HoTen=" + hoten + "&NgaySinh=" + ngaysinh; break;
                case "trung-cap-thpt":
                    strApi = "api/DangKyCaoDang/getketquathpt?HoTen=" + hoten + "&NgaySinh=" + ngaysinh; break;
                default:
                    strApi = "api/DangKyCaoDang/getketqua?HoTen=" + hoten + "&NgaySinh=" + ngaysinh; break;
            }
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync(strApi);
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<IList<KetQuaViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/ThongBaoKetQua/getsinglebyid?ID=1");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                ViewBag.ThongBaoKetQua = JsonConvert.DeserializeObject<ThongBaoKetQuaViewModel>(obj);
            }

            ViewBag.KetQua = cls;
            ViewBag.HoTen = hoten;
            ViewBag.NgaySinh = ngaysinh;

            return View("KetQua");
        }
    }
}