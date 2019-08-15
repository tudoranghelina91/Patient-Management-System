using PatientManagementSystem.Domain;
using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    public interface IMedicalRecordEntryRepository : IBaseRepository<MedicalRecordEntry>
    {
        IList<MedicalRecordEntry> GetForPatient(int id);
    }
}
