using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    class MedicalRecordRepository : Context, IMedicalRecordRepository
    {
        public void Add(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Add(medicalRecord);
        }

        public IList<MedicalRecord> GetAll()
        {
            return context.MedicalRecords.ToList();
        }

        public MedicalRecord GetById(int id)
        {
            return context.MedicalRecords.FirstOrDefault(m => m.Id == id);
        }
    }
}
