using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class MedicationRepository : Context, IMedicationRepository
    {
        public void Add(Medication medication)
        {
            context.MedicalRecordEntries.Attach(medication.MedicalRecordEntry);
            context.Medications.Add(medication);
            context.SaveChanges();
        }

        public IList<Medication> GetAll()
        {
            return context.Medications.ToList();
        }

        public Medication GetById(int id)
        {
            return context.Medications.FirstOrDefault(m => m.Id == id);
        }

        public IList<Medication> GetByMedicalRecordEntryId(int medicalRecordEntryId)
        {
            return context.Medications.Where(m => m.MedicalRecordEntry.Id == medicalRecordEntryId).ToList();
        }

        public void Update(Medication medication)
        {
            Medication result = context.Medications.FirstOrDefault(m => m.Id == medication.Id);
            if (result != null)
            {
                context.MedicalRecordEntries.Attach(medication.MedicalRecordEntry);
                context.MedicalRecordEntries.Attach(result.MedicalRecordEntry);
                context.Entry(result.MedicalRecordEntry.Patient).State = System.Data.Entity.EntityState.Detached;
                result.Administered = medication.Administered;
                result.Allergies = medication.Allergies;
                result.Prescribed = medication.Prescribed;
                result.Renewed = medication.Renewed;
                result.MedicalRecordEntry = medication.MedicalRecordEntry;
                result.MedicalRecordEntry.Patient = medication.MedicalRecordEntry.Patient;
                context.SaveChanges();
            }
        }

        public void Delete(Medication medication)
        {
            Medication result = context.Medications.FirstOrDefault(m => m.Id == medication.Id);
            if (result != null)
            {
                context.MedicalRecordEntries.Attach(medication.MedicalRecordEntry);
                context.MedicalRecordEntries.Attach(result.MedicalRecordEntry);
                context.Entry(result.MedicalRecordEntry.Patient).State = System.Data.Entity.EntityState.Detached;
                context.Medications.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
