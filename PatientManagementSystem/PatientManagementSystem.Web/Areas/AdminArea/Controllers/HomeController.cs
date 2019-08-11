using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.AdminArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: AdminArea/AdminDashboard
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}