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
                    SeedAdmin(user, patientManagementDbContext);
                }

            }

            // Create doctor role
            if (!roleManager.RoleExists("Doctor"))
            {
                var role = new IdentityRole();
                role.Name = "Doctor";
                roleManager.Create(role);

                // Create doctor
                var user = new ApplicationUser();
                user.UserName = "doctor";
                user.Email = "doctor@doctor.com";

                string password = "Doctor@69!";

                var chkUser = userManager.Create(user, password);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Doctor");
                    // seed doctor data
                    SeedDoctor(user, patientManagementDbContext);
                }
            }

            // Create patient role
            if (!roleManager.RoleExists("Patient"))
            {
                var role = new IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);

                // Create patient
                var user = new ApplicationUser();
                user.UserName = "patient";
                user.Email = "patient@patient.com";

                string password = "Patient@69!";

                var chkUser = userManager.Create(user, password);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Patient");
                    // seed doctor data
                    SeedPatient(user, patientManagementDbContext);
                }
            }
        }

        private void SeedAdmin(ApplicationUser user, PatientManagementSystemDBContext patientManagementDbContext)
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

        private void SeedDoctor(ApplicationUser user, PatientManagementSystemDBContext patientManagementDbContext)
        {
            Doctor doctor = new Doctor();
            doctor.IdentityId = user.Id;
            doctor.UserName = user.UserName;
            doctor.Email = user.Email;
            doctor.FirstName = user.UserName;
            doctor.LastName = user.UserName;
            doctor.Address1 = "none";
            doctor.Address2 = "none";
            doctor.SSN = "123456";
            doctor.State = "none";
            doctor.City = "None";
            doctor.Country = "None";
            doctor.University = "None";
            doctor.Specialization = Doctor.Specialty.Allergology;
            doctor.LicenseNo = "213412";

            patientManagementDbContext.Doctors.Add(doctor);
            patientManagementDbContext.SaveChanges();
        }

        private void SeedPatient(ApplicationUser user, PatientManagementSystemDBContext patientManagementDbContext)
        {
            Patient patient = new Patient();
            patient.IdentityId = user.Id;
            patient.UserName = user.UserName;
            patient.Email = user.Email;
            patient.FirstName = user.UserName;
            patient.LastName = user.UserName;
            patient.Address1 = "none";
            patient.Address2 = "none";
            patient.SSN = "123456";
            patient.State = "none";
            patient.City = "None";
            patient.Country = "None";
            patient.EmergencyContactNumber = "21312451";
            patientManagementDbContext.Patients.Add(patient);
            patientManagementDbContext.SaveChanges();
        }
    }
}
