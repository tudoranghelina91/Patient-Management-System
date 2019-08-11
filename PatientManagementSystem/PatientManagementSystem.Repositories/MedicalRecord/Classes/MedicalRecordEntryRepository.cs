using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    class MedicalRecordEntryRepository : Context, IMedicalRecordEntryRepository
    {
        public void Add(MedicalRecordEntry medicalRecordEntry)
        {
            context.MedicalRecordEntries.Add(medicalRecordEntry);
        }

        public IList<MedicalRecordEntry> GetAll()
        {
            return context.MedicalRecordEntries.ToList();
        }

        public MedicalRecordEntry GetById(int id)
        {
            return context.MedicalRecordEntries.FirstOrDefault(m => m.Id == id);
        }
    }
}
