using PatientManagementSystem.Domain;
using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    public interface IExamFindingsRepository : IBaseRepository<ExamFindings>
    {
        IList<ExamFindings> GetByMedicalRecordEntryId(int medicalRecordEntryId);
    }
}
