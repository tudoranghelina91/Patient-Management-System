using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Admin GetByIdentityId(string identityId);
    }
}
