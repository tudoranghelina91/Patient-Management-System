using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class DoctorDashboardController : Controller
    {
        // GET: DoctorArea/DoctorDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}