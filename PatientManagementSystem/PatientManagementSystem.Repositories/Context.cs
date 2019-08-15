using PatientManagementSystem.DataAccess;

namespace PatientManagementSystem.Repositories
{
    public abstract class Context
    {
        protected PatientManagementSystemDBContext context = new PatientManagementSystemDBContext();
    }
}
