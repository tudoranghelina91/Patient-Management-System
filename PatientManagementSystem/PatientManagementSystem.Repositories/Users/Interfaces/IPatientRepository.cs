using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Patient GetByIdentityId(string identityId);
    }
}
