using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.PatientArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: PatientArea/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}