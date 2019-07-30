using System.Security.Claims;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            ViewBag.Country = claimsIdentity.FindFirst(ClaimTypes.Country).Value;   // Move this line into authentication

            return View();
        }
    }
}