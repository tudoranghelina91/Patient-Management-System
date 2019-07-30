using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PatientManagementSystem.Auth
{
    public class PatientManagementSystemIdentityDBContext : IdentityDbContext<PatientManagementSystemIdentityUser>
    {
        public PatientManagementSystemIdentityDBContext() : base("PatientManagementSystemDatabase")
        {
        }

        public static PatientManagementSystemIdentityDBContext Create()
        {
            return new PatientManagementSystemIdentityDBContext();
        }
    }

    public class PatientManagementSystemUserManager : UserM
}
