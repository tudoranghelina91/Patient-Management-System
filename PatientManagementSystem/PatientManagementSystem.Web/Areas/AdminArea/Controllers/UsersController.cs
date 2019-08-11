using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Web.Areas.AdminArea.Models;
using PatientManagementSystem.Web.Models;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using PatientManagementSystem.Domain;
using PatientManagementSystem.DataAccess;
using System.Collections.Generic;

namespace PatientManagementSystem.Web.Areas.AdminArea.Controllers
{
    public class UsersController : Controller
    {
        // GET: AdminArea/UserDetails
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private PatientManagementSystemDBContext _patientManagementSystemDBContext;

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UsersController()
        {

        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public PatientManagementSystemDBContext PatientManagementSystemDBContext
        {
            get
            {
                return _patientManagementSystemDBContext;
            }

            set
            {
                _patientManagementSystemDBContext = new PatientManagementSystemDBContext();
            }
        }
        

        [Authorize(Roles = "Admin")]
        private void GrabRolesFromDb(ref AddUserViewModel model)
        {
            var context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roles = roleManager.Roles.ToList();
            foreach (var r in roles)
            {
                model.Roles.Add(new SelectListItem { Value = r.Name, Text = r.Name });
            }
        }

        //
        // GET: /Account/Register
        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var model = new AddUserViewModel();
            GrabRolesFromDb(ref model);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                //user.Roles.Add(model.Role);
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.Role);

                    if (result.Succeeded)
                    {
                        if (model.Role == "Doctor")
                        {
                            Doctor doctor = new Doctor();

                            PatientManagementSystemDBContext.Doctors.Add(doctor);
                        }

                        if (model.Role == "Patient")
                        {
                            Patient patient = new Patient();
                            PatientManagementSystemDBContext.Patients.Add(patient);
                        }

                        if (model.Role == "Admin")
                        {
                            Admin admin = new Admin();
                            PatientManagementSystemDBContext.Admins.Add(admin);
                        }
                        return RedirectToAction("Index", "AdminDashboard");
                    }
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            GrabRolesFromDb(ref model);
            return View(model);
        }
    }
}