using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.PatientArea
{
    public class PatientAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PatientArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PatientArea_default",
                "PatientArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}