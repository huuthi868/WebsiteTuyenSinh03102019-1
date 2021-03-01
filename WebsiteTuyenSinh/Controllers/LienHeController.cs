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
    [RoutePrefix("lien-he")]
    public class LienHeController : Controller
    {
        public ActionResult LienHe()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateLienHe(string model)
        {
            JavaScriptSerializer cls = new JavaScriptSerializer();
            LienHeViewModel entity = cls.Deserialize<LienHeViewModel>(model);
            HttpResponseMessage Res = await GlobalVariables.WebApiClient.PostAsJsonAsync("api/LienHe/create", entity);
            if (Res.IsSuccessStatusCode)
            {
                return Json(new { status = true });
            }
            return RedirectToAction("LienHe");
        }
    }
}