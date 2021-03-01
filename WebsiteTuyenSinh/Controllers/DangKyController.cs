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
    [RoutePrefix("dang-ky")]
    public class DangKyController : Controller
    {
        public async Task<ActionResult> DangKy()
        {
            IList<TinTuyenSinhViewModel> lstTinLienQuan = null;
            var Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getTop5TinLienQuan");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                lstTinLienQuan = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            }

            return View("DangKy", lstTinLienQuan);
        }

        [Route("cao-dang")]
        public async Task<ActionResult> CaoDang()
        {
            IList<PhongKhoa_NgheViewModel> lstNghe = null;
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/PhongKhoa_Nghe/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                lstNghe = JsonConvert.DeserializeObject<IList<PhongKhoa_NgheViewModel>>(obj);
            }

            return View("CaoDang", lstNghe.Where(x => x.isCaoDang == true));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCaoDang(string model)
        {
            JavaScriptSerializer cls = new JavaScriptSerializer();
            DangKyCaoDangViewModel entity = cls.Deserialize<DangKyCaoDangViewModel>(model);

            HttpResponseMessage Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/DangKyCaoDang/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("KetQua", "KetQua");
        }

        [Route("trung-cap-thpt")]
        [HttpGet]
        public async Task<ActionResult> TrungCapTHPT()
        {
            IList<PhongKhoa_NgheViewModel> lstNghe = null;
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/PhongKhoa_Nghe/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                lstNghe = JsonConvert.DeserializeObject<IList<PhongKhoa_NgheViewModel>>(obj);
            }

            return View("TrungCapTHPT", lstNghe.Where(x => x.isTrungCap == true));
        }


        [HttpPost]
        public async Task<ActionResult> TrungCapTHPT(string model)
        {
            JavaScriptSerializer cls = new JavaScriptSerializer();
            DangKyCaoDangViewModel entity = cls.Deserialize<DangKyCaoDangViewModel>(model);
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/DangKyCaoDang/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("KetQua", "KetQua");
        }

        [Route("trung-cap-thcs")]
        [HttpGet]
        public async Task<ActionResult> TrungCapTHCS()
        {
            IList<PhongKhoa_NgheViewModel> lstNghe = null;
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/PhongKhoa_Nghe/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                lstNghe = JsonConvert.DeserializeObject<IList<PhongKhoa_NgheViewModel>>(obj);
            }

            return View("TrungCapTHCS", lstNghe.Where(x => x.isTrungCap == true));
        }

        [HttpPost]
        public async Task<ActionResult> TrungCapTHCS(string model)
        {
            JavaScriptSerializer cls = new JavaScriptSerializer();
            DangKyTrungCap2NamViewModel entity = cls.Deserialize<DangKyTrungCap2NamViewModel>(model);

            HttpResponseMessage Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/DangKyTrungCap2Nam/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("KetQua", "KetQua");
        }

        [Route("lien-thong-cao-dang")]
        [HttpGet]
        public async Task<ActionResult> LienThong()
        {
            IList<PhongKhoa_NgheViewModel> lstNghe = null;
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.GetAsync("api/PhongKhoa_Nghe/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                lstNghe = JsonConvert.DeserializeObject<IList<PhongKhoa_NgheViewModel>>(obj);
            }

            return View("LienThong", lstNghe.Where(x => x.isCaoDang == true));
        }


        [HttpPost]
        public async Task<ActionResult> LienThong(string model)
        {
            JavaScriptSerializer cls = new JavaScriptSerializer();
            DangKyLienThongCaoDangViewModel entity = cls.Deserialize<DangKyLienThongCaoDangViewModel>(model);

            HttpResponseMessage Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/DangKyLienThongCaoDang/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("KetQua", "KetQua");

        }

        [HttpGet]
        public ActionResult CheckRegisterCaoDangTHPT(string HoTen, string NgaySinh, string DienThoai)
        {
            HttpResponseMessage Res = GlobalVariables.WebApiClient.GetAsync($"api/DangKyCaoDang/checkregister?hoten={HoTen}&ngaysinh={NgaySinh}&sdt={DienThoai}").Result;
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<bool>(obj);
                return Json(new { status = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            return View("CaoDang");
        }

    }
}