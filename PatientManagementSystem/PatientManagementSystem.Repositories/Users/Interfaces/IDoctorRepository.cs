using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Doctor GetByIdentityId(string identityId);
    }
}
