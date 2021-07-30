using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh.Controllers
{
    [RoutePrefix("danh-muc-nghe")]
    public class NganhDaoTaoController : Controller
    {
        [Route("")]
        public async Task<ActionResult> NganhDaoTao()
        {
            NgheDaoTaoViewModel cls = new NgheDaoTaoViewModel();

            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/PhongKhoa_Nghe/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.NgheDaoTao = JsonConvert.DeserializeObject<List<PhongKhoa_NgheViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinLienQuan/getall");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinLienQuan = JsonConvert.DeserializeObject<List<TinLienQuanViewModel>>(obj);
            }

            Res = await GlobalVariables.WebApiClient.GetAsync("api/TinTuyenSinh/getTop5");
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls.TinTuyenSinh = JsonConvert.DeserializeObject<List<TinTuyenSinhViewModel>>(obj);
            }

            return View("NganhDaoTao", cls);
        }

        [Route("{nghelink}-{id}")]
        public async Task<ActionResult> ChiTiet(int id)
        {
            PhongKhoa_NgheViewModel cls = new PhongKhoa_NgheViewModel();
            HttpResponseMessage Res = await GlobalVariables.WebApiTruong.GetAsync("api/PhongKhoa_Nghe/getsinglebyid?id=" + id);
            if (Res.IsSuccessStatusCode)
            {
                var obj = Res.Content.ReadAsStringAsync().Result;
                cls = JsonConvert.DeserializeObject<PhongKhoa_NgheViewModel>(obj);
            }

            return View("ChiTiet", cls);
        }
    }
}