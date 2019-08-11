using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    class TreatmentRepository : Context, ITreatmentRepository
    {
        public void Add(Treatment treatment)
        {
            context.Treatments.Add(treatment);
        }

        public IList<Treatment> GetAll()
        {
            return context.Treatments.ToList();
        }

        public Treatment GetById(int id)
        {
            return context.Treatments.FirstOrDefault(t => t.Id == id);
        }
    }
}
