using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Web.Models;
using PatientManagementSystem.Auth;

namespace PatientManagementSystem.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            if (User.IsInRole("Admin"))
            {
                // Redirect to admin dashboard
            }

            if (User.IsInRole("Doctor"))
            {
                // Redirect to doctor dashboard
            }

            if (User.IsInRole("Patient"))
            {
                // Redirect to patient dashboard
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Authenticate.Logout();
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Email == "admin@admin.com" && model.Password == "password")
            {
                Authenticate.Login();
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "home");
            }

            return returnUrl;
        }
    }
}