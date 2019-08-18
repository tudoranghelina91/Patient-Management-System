using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class ExamFindingsRepository : Context, IExamFindingsRepository
    {
        public void Add(ExamFindings examFindings)
        {
            context.MedicalRecordEntries.Attach(examFindings.MedicalRecordEntry);
            context.ExamFindings.Add(examFindings);
            context.SaveChanges();
        }

        public IList<ExamFindings> GetAll()
        {
            return context.ExamFindings.ToList();
        }

        public ExamFindings GetById(int id)
        {
            return context.ExamFindings.FirstOrDefault(e => e.Id == id);
        }

        public IList<ExamFindings> GetByMedicalRecordEntryId(int medicalRecordEntryId)
        {
            return context.ExamFindings.Where(e => e.MedicalRecordEntry.Id == medicalRecordEntryId).ToList();
        }

        public void Update(ExamFindings examFindings)
        {
            ExamFindings result = context.ExamFindings.FirstOrDefault(e => e.Id == examFindings.Id);
            if (result != null)
            {
                result.Positive = examFindings.Positive;
                result.RelevantNegative = examFindings.RelevantNegative;
                result.Abnormal = examFindings.Abnormal;
                context.SaveChanges();
            }
        }
    }
}
