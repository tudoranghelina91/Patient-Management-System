using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: DoctorArea/Patient
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            return View();
        }
    }
}