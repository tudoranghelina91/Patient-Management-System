using System.Web.Mvc;
using PatientManagementSystem.Web.Models;

namespace PatientManagementSystem.Web.Areas.AdminArea.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminArea/Home
        public ActionResult Index(AdminDashboardViewModel model)
        {
            return View("AdminDashboard", model);
        }
    }
}