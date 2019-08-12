using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Web.Areas.AdminArea.Models;
using PatientManagementSystem.Web.Models;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using PatientManagementSystem.Repositories;
using System;

namespace PatientManagementSystem.Web.Areas.AdminArea.Controllers
{

    public class UsersController : Controller
    {
        IAdminRepository adminRepository = new AdminRepository();
        IPatientRepository patientRepository = new PatientRepository();
        IDoctorRepository doctorRepository = new DoctorRepository();
        IMedicalRecordEntryRepository medicalRecordEntryRepository = new MedicalRecordEntryRepository();

        // GET: AdminArea/UserDetails
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        { 
            IEnumerable<ApplicationUser> users = UserManager.Users.ToList();
            return View(users);
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

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

        private string getRoleId(AddUserViewModel model)
        {
            var context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            return roleManager.Roles.FirstOrDefault(r => r.Name == model.Role).Id;
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

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.IdentityId = TempData["IdentityId"] as string;
            adminViewModel.UserName = TempData["Username"] as string;
            adminViewModel.Email = TempData["Email"] as string;
            return View(adminViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateDoctor()
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.IdentityId = TempData["IdentityId"] as string;
            doctorViewModel.UserName = TempData["Username"] as string;
            doctorViewModel.Email = TempData["Email"] as string;
            return View(doctorViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreatePatient()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.IdentityId = TempData["IdentityId"] as string;
            patientViewModel.UserName = TempData["Username"] as string;
            patientViewModel.Email = TempData["Email"] as string;
            return View(patientViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin(AdminViewModel adminViewModel)
        {
            if (ModelState.IsValid)
            {
                adminRepository.Add(adminViewModel.ToDomainModel());
                return RedirectToAction("Index");
            }

            return View(adminViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateDoctor(DoctorViewModel doctorViewModel)
        {
            if (ModelState.IsValid)
            {
                doctorRepository.Add(doctorViewModel.ToDomainModel());
                return RedirectToAction("Index");
            }

            return View(doctorViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePatient(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                patientRepository.Add(patientViewModel.ToDomainModel());
                return RedirectToAction("Index");
            }

            return View(patientViewModel);
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
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.Role);

                    if (result.Succeeded)
                    {
                        TempData["IdentityId"] = getRoleId(model);
                        TempData["Email"] = model.Email;
                        TempData["Username"] = model.UserName;
                        if (model.Role == "Admin")
                        {
                            return RedirectToAction("CreateAdmin", "Users");
                        }

                        if (model.Role == "Doctor")
                        {
                            return RedirectToAction("CreateDoctor", "Users");
                        }

                        if (model.Role == "Patient")
                        {
                            return RedirectToAction("CreatePatient", "Users");
                        }
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