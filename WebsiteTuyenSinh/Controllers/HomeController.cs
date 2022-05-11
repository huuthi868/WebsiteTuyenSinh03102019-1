using Newtonsoft.Json;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
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
                //send mail
                var dataEmail = new SendEmailViewModel();
                dataEmail.HoTen = entity.HoTen;
                dataEmail.Email = entity.Email;
                dataEmail.SoDienThoai = entity.SoDienThoai;
                dataEmail.NoiDung = entity.NgheTuVan;

                SendMailToOwner(dataEmail);
                //
                return Json(new { status = true });
            }
            return RedirectToAction("TrangChu");
        }


        [HttpPost]
        public JsonResult SendMailToOwner(SendEmailViewModel dataEmail)
        {
            var templateService = new TemplateService();

            string emailBodyPath = Server.MapPath("/Views/Shared/EmailBody.cshtml");

            string subject = $"[QCET_THÔNG_BÁO]Tư vấn học nghề - {DateTime.Now.ToShortDateString()}";

            string bodyHtml = templateService.Parse(System.IO.File.ReadAllText(emailBodyPath), dataEmail, null, null);

            var result = SendMail("nguyenngocvinh@cdktcnqn.edu.vn", subject, bodyHtml);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SendMail(string toMail, string subject, string emailBody)
        {
            try
            {
                var senderEmail = "dangkytuvan@cdktcnqn.edu.vn";
                var senderPassword = "uqdptkqyneavptcu";

                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                var mailMessage = new MailMessage(senderEmail, toMail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}