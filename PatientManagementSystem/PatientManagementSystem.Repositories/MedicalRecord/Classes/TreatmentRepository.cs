using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class TreatmentRepository : Context, ITreatmentRepository
    {
        public void Add(Treatment treatment)
        {
            context.MedicalRecordEntries.Attach(treatment.MedicalRecordEntry);
            context.Treatments.Add(treatment);
            context.SaveChanges();
        }

        public IList<Treatment> GetAll()
        {
            return context.Treatments.ToList();
        }

        public Treatment GetById(int id)
        {
            return context.Treatments.FirstOrDefault(t => t.Id == id);
        }

        public IList<Treatment> GetByMedicalRecordEntryId(int medicalRecordEntryId)
        {
            return context.Treatments.Where(t => t.MedicalRecordEntry.Id == medicalRecordEntryId).ToList();
        }

        public void Update(Treatment treatment)
        {
            Treatment result = context.Treatments.FirstOrDefault(t => t.Id == treatment.Id);
            if (result != null)
            {
                result.Details = treatment.Details;
                result.Recommendations = treatment.Recommendations;
                context.SaveChanges();
            }
        }
    }
}
