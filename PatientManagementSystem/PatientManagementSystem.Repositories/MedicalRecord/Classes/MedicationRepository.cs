using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    class MedicationRepository : Context, IMedicationRepository
    {
        public void Add(Medication medication)
        {
            context.Medications.Add(medication);
        }

        public IList<Medication> GetAll()
        {
            return context.Medications.ToList();
        }

        public Medication GetById(int id)
        {
            return context.Medications.FirstOrDefault(m => m.Id == id);
        }
    }
}
