using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.PatientArea.Controllers
{
    public class UserDashboardController : Controller
    {
        // GET: PatientArea/UserDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}