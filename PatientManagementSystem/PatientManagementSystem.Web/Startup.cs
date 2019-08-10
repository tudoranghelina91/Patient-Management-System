using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PatientManagementSystem.Web.Models;

[assembly: OwinStartupAttribute(typeof(PatientManagementSystem.Web.Startup))]
namespace PatientManagementSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // creating a default admin role and user
            if (!roleManager.RoleExists("Admin"))
            {
                // create admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Create admin super user
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@patientmanagementsystem.com";

                string password = "A@Z200711";
                var chkUser = userManager.Create(user, password);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            // Create doctor role
            if (!roleManager.RoleExists("Doctor"))
            {
                var role = new IdentityRole();
                role.Name = "Doctor";
                roleManager.Create(role);
            }

            // Create patient role
            if (!roleManager.RoleExists("Patient"))
            {
                var role = new IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);
            }
        }
    }
}
