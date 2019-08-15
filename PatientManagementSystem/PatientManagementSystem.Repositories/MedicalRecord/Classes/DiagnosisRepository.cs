using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class DiagnosisRepository : Context, IDiagnosisRepository
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

        public void Update(Diagnosis diagnosis)
        {
            Diagnosis result = context.Diagnoses.FirstOrDefault(d => d.Id == diagnosis.Id);
            if (result != null)
            {
                result.Name = diagnosis.Name;
                result.Description = diagnosis.Description;
                result.Type = diagnosis.Type;
                result.Inclusions = diagnosis.Inclusions;
                result.ExcludesOne = diagnosis.ExcludesOne;
                result.ExcludesTwo = diagnosis.ExcludesTwo;
                context.SaveChanges();
            }
        }
    }
}
