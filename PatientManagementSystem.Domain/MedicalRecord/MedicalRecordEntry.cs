using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    class MedicalRecordEntry : BaseEntity
    {
        public DateTime TimeEntry { get; set; }
        public string ReasonForVisit { get; set; }  // Reason for visit
        public string ExaminationScope { get; set; }    // Scope of examination
        public ExamFindings ExamFindings { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public Treatment Treatment { get; set; }
        public DateTime RecommendedVisitDate { get; set; }
    }
}
