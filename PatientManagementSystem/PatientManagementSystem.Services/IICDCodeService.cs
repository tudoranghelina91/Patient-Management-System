using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Services
{
    interface IICDCodeService
    {
        string GetICDCode(string ICDCode);
        Diagnosis Deserialize(string ICDCode);
    }
}
