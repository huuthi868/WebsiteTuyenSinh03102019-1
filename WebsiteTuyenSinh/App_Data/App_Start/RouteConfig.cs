using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteTuyenSinh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "tuyensinh",
                "tin-tuyen-sinh/{tenlink}-{id}",
                new
                {
                    controller = "TinTuyenSinh",
                    action = "TinTuyenSinh",
                    tenlink="",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "tinsinhvien",
                "sinh-vien-tieu-bieu/{tenlink}-{id}",
                new
                {
                    controller = "TinSinhVien",
                    action = "TinSinhVien",
                    tenlink="",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "nganhdaotao",
                "danh-muc-nghe/{nghelink}-{id}",
                new
                {
                    controller = "NganhDaoTao",
                    action = "NganhDaoTao",
                    nghelink = "",
                    id = UrlParameter.Optional
                }
            );


            routes.MapRoute(
                           "tracuu",
                           "ket-qua",
                             new
                             {
                                 controller = "KetQua",
                                 action = "KetQua"
                             }
                       );
            

            routes.MapRoute(
                           "lienhe",
                           "lien-he",
                             new
                             {
                                 controller = "LienHe",
                                 action = "LienHe",
                             }
                       );

            routes.MapRoute(
                "tuvan",
                "hoi-dap",
                  new
                  {
                      controller = "TuVan",
                      action = "TuVan",
                  }
            );

            routes.MapRoute(
                "dangky",
                "dang-ky",
                  new
                  {
                      controller = "DangKy",
                      action = "DangKy",
                  }
            );

            routes.MapRoute(
                   "trangchu",
                   "trang-chu",
                   new
                   {
                       controller = "Home",
                       action = "TrangChu",
                   }
               );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "TrangChu", id = UrlParameter.Optional },
               namespaces: new[] { "WebsiteTuyenSinh.Controllers" }
           );

        }
    }
}
