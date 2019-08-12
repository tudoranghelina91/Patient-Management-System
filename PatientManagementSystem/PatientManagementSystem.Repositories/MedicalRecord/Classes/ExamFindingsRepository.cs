using System;
using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class ExamFindingsRepository : Context, IExamFindingsRepository
    {
        public void Add(ExamFindings examFindings)
        {
            context.ExamFindings.Add(examFindings);
            context.SaveChanges();
        }

        public IList<ExamFindings> GetAll()
        {
            return context.ExamFindings.ToList();
        }

        public ExamFindings GetById(int id)
        {
            return context.ExamFindings.FirstOrDefault(e => e.Id == id);
        }
    }
}
