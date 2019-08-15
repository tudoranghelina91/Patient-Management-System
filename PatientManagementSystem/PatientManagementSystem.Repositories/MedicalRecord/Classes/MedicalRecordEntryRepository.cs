using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class MedicalRecordEntryRepository : Context, IMedicalRecordEntryRepository
    {
        public void Add(MedicalRecordEntry medicalRecordEntry)
        {
            context.Patients.Attach(medicalRecordEntry.Patient);
            context.MedicalRecordEntries.Add(medicalRecordEntry);
            context.SaveChanges();
        }

        public IList<MedicalRecordEntry> GetAll()
        {
            return context.MedicalRecordEntries.ToList();
        }

        public MedicalRecordEntry GetById(int id)
        {
            return context.MedicalRecordEntries.FirstOrDefault(m => m.Id == id);
        }

        public IList<MedicalRecordEntry> GetForPatient(int id)
        {
            return context.MedicalRecordEntries.Where(e => e.Patient.Id == id).ToList();
        }

        public void Update(MedicalRecordEntry medicalRecordEntry)
        {
            MedicalRecordEntry result = context.MedicalRecordEntries.FirstOrDefault(e => e.Id == medicalRecordEntry.Id);
            if (result != null)
            {
                result.TimeEntry = medicalRecordEntry.TimeEntry;
                result.ExamFindings = medicalRecordEntry.ExamFindings;
                result.Diagnosis = medicalRecordEntry.Diagnosis;
                result.ExaminationScope = medicalRecordEntry.ExaminationScope;
                result.Patient = medicalRecordEntry.Patient;
                result.ReasonForVisit = medicalRecordEntry.ReasonForVisit;
                result.RecommendedVisitDate = medicalRecordEntry.RecommendedVisitDate;
                result.Treatment = medicalRecordEntry.Treatment;
                context.SaveChanges();
            }
        }
    }
}
