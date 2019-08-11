using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Services
{
    interface IICDCodeService
    {
        string GetByICDCode(string ICDCode);
        string GetByName(string ICDName);
        Diagnosis Deserialize(string ICDCode);
    }
}
