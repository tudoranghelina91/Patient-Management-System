using PatientManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Repositories
{
    public abstract class Context
    {
        protected PatientManagementSystemDBContext context = new PatientManagementSystemDBContext();
    }
}
