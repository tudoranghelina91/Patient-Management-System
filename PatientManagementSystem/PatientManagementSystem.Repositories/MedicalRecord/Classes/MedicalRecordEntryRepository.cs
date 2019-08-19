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
                context.Patients.Attach(medicalRecordEntry.Patient);
                context.Patients.Attach(result.Patient);
                result.TimeEntry = medicalRecordEntry.TimeEntry;
                result.Diagnosis = medicalRecordEntry.Diagnosis;
                result.ExaminationScope = medicalRecordEntry.ExaminationScope;
                result.Patient = medicalRecordEntry.Patient;
                result.ReasonForVisit = medicalRecordEntry.ReasonForVisit;
                result.RecommendedVisitDate = medicalRecordEntry.RecommendedVisitDate;
                result.Patient = medicalRecordEntry.Patient;
                context.SaveChanges();
            }
        }

        private ITreatmentRepository treatmentRepository = new TreatmentRepository();
        private IExamFindingsRepository examFindingsRepository = new ExamFindingsRepository();
        private IMedicationRepository medicationRepository = new MedicationRepository();

        public void Delete(MedicalRecordEntry medicalRecordEntry)
        {
            MedicalRecordEntry result = context.MedicalRecordEntries.FirstOrDefault(e => e.Id == medicalRecordEntry.Id);
            if (result != null)
            {
                foreach (var m in context.Medications.Where(m => m.MedicalRecordEntry.Id == medicalRecordEntry.Id))
                {
                    if (m != null)
                    medicationRepository.Delete(m);
                }

                foreach (var t in context.Treatments.Where(t => t.MedicalRecordEntry.Id == medicalRecordEntry.Id))
                {
                    if (t != null)
                    treatmentRepository.Delete(t);
                }

                foreach (var e in context.ExamFindings.Where(e => e.MedicalRecordEntry.Id == medicalRecordEntry.Id))
                {
                    if (e != null)
                    examFindingsRepository.Delete(e);
                }

                context.Patients.Attach(medicalRecordEntry.Patient);
                context.Patients.Attach(result.Patient);
                context.Entry(result.Patient).State = System.Data.Entity.EntityState.Detached;
                context.MedicalRecordEntries.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
