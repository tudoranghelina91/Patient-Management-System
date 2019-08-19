using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PatientManagementSystem.Extensions;

namespace PatientManagementSystem.Web.Areas.AdminArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: AdminArea/AdminDashboard
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            AdminRepository adminRepository = new AdminRepository();
            AdminViewModel currentUser = adminRepository.GetByIdentityId(User.Identity.GetUserId()).ToViewModel();
            return View(currentUser);
        }
    }
}