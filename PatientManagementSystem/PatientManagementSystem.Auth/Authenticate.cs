using System.Security.Claims;
using System.Web;

namespace PatientManagementSystem.Auth
{
    public static class Authenticate
    {
        public static void Login()
        {
            var identity = new ClaimsIdentity(new[]
{
                    new Claim(ClaimTypes.Name, "Ben"),
                    new Claim(ClaimTypes.Email, "a@b.com"),
                    new Claim(ClaimTypes.Country, "England")
                }, "ApplicationCookie");

            var ctx = HttpContext.Current.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(identity);
        }

        public static void Logout()
        {
            var ctx = HttpContext.Current.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
        }
    }
}
