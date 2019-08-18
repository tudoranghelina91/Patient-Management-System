using PatientManagementSystem.Domain;
using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    public interface ITreatmentRepository : IBaseRepository<Treatment>
    {
        IList<Treatment> GetByMedicalRecordEntryId(int medicalRecordEntryId);
    }
}
