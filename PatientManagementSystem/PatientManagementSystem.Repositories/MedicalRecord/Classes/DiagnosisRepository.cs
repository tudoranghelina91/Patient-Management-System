using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    class DiagnosisRepository : Context, IDiagnosisRepository
    {
        public void Add(Diagnosis diagnosis)
        {
            context.Diagnoses.Add(diagnosis);
            context.SaveChanges();
        }

        public IList<Diagnosis> GetAll()
        {
            return context.Diagnoses.ToList();
        }

        public Diagnosis GetById(int id)
        {
            return context.Diagnoses.FirstOrDefault(d => d.Id == id);
        }
    }
}
