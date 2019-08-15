using System.Web.Mvc;

namespace PatientManagementSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToActionPermanent("Index", "Home", new { area = "AdminArea" });
            }

            if (User.IsInRole("Doctor"))
            {
                return RedirectToActionPermanent("Index", "Home", new { area = "DoctorArea" });
            }
            if (User.IsInRole("Patient"))
            {
                return RedirectToActionPermanent("Index", "Home", new { area = "PatientArea" });
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}