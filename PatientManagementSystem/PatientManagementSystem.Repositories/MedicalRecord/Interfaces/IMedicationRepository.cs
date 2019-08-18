using PatientManagementSystem.Domain;
using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    public interface IMedicationRepository : IBaseRepository<Medication>
    {
        IList<Medication> GetByMedicalRecordEntryId(int medicalRecordEntryId);
    }
}
