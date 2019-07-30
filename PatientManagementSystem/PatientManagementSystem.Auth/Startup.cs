using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartup(typeof(PatientManagementSystem.Auth.Startup))]
namespace PatientManagementSystem.Auth
{
    public class Startup
    {
        public static Func<UserManager<PatientManagementSystemIdentityUser>> UserManagerFactory { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureUserManager();
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }

        public void ConfigureUserManager()
        {
            UserManagerFactory = () =>
            {
                var userManager = new UserManager<PatientManagementSystemIdentityUser>
                (
                    new UserStore<PatientManagementSystemIdentityUser>
                    (
                        new PatientManagementSystemIdentityDBContext()
                    )
                );

                userManager.UserValidator = new UserValidator<PatientManagementSystemIdentityUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return userManager;
            };
        }
    }
}