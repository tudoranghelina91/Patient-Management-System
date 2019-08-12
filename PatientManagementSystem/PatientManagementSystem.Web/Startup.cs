using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PatientManagementSystem.DataAccess;
using PatientManagementSystem.Domain;
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

        public static bool setupComplete = true;

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext identityDbContext = new ApplicationDbContext();
            PatientManagementSystemDBContext patientManagementDbContext = new PatientManagementSystemDBContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(identityDbContext));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(identityDbContext));

            // creating a default admin role and user
            if (!roleManager.RoleExists("Admin"))
            {
                setupComplete = false;
                // create admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Create admin super user
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@patientmanagementsystem.com";

                string password = "Admin@69!";
                var chkUser = userManager.Create(user, password);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    // Seed admin data
                    RunSetup(user, patientManagementDbContext);
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

        private void RunSetup(ApplicationUser user, PatientManagementSystemDBContext patientManagementDbContext)
        {
            Admin admin = new Admin();
            admin.IdentityId = user.Id;
            admin.UserName = user.UserName;
            admin.Email = user.Email;
            admin.FirstName = user.UserName;
            admin.LastName = user.UserName;
            admin.Address1 = "none";
            admin.Address2 = "none";
            admin.SSN = "123456";
            admin.State = "none";
            admin.City = "None";
            admin.Country = "None";
            patientManagementDbContext.Admins.Add(admin);
            patientManagementDbContext.SaveChanges();
        }
    }
}
