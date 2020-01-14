using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GarageWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            //ENABLE CORS
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200/api", headers: "*", methods: "*")); //api
            //web config isto dodano u system.web server

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
