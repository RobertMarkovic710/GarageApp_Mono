using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GarageWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ////dodao
            //string[] allowedOrigin = new string[] { "http://localhost:4200", "http://localhost:44392" };
            //var origin = HttpContext.Current.Request.Headers["http://localhost:4200"];
            //if (origin != null && allowedOrigin.Contains(origin))
            //{
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");
            //}
            ////dodao_end
            ///

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
