﻿using System.Web.Mvc;
using System.Web.Routing;

namespace PatientManagementSystem.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PatientManagementSystem.Web.Controllers" }
            );

            routes.MapRoute(
                name: "AdminArea",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PatientManagementSystem.Web.Areas.AdminArea.Controllers" }
            );

            routes.MapRoute(
                name: "DoctorArea",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PatientManagementSystem.Web.Areas.DoctorArea.Controllers" }
            );

            routes.MapRoute(
                name: "PatientArea",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PatientManagementSystem.Web.Areas.PatientArea.Controllers" }
            );
        }
    }
}
