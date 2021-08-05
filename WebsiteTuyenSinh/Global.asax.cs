using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebsiteTuyenSinh.Models;

namespace WebsiteTuyenSinh
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
       
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
    }

 
}
