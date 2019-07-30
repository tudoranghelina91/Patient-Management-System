﻿using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea
{
    public class DoctorAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DoctorArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DoctorArea_default",
                "DoctorArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}