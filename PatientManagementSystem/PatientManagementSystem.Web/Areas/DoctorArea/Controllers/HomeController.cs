using PatientManagementSystem.Web.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PatientManagementSystem.Repositories;
using PatientManagementSystem.Extensions;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: DoctorArea/Patient
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            IDoctorRepository doctorRepository = new DoctorRepository();
            DoctorViewModel currentUser = new DoctorViewModel();
            currentUser = doctorRepository.GetByIdentityId(User.Identity.GetUserId()).ToViewModel();

            return View(currentUser);
        }
    }
}