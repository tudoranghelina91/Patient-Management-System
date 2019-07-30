using System;

namespace PatientManagementSystem.Domain
{
    class MedicalRecordEntry : BaseEntity
    {
        public DateTime TimeEntry { get; set; }
        public string ReasonForVisit { get; set; }
        public string ExaminationScope { get; set; }
        public ExamFindings ExamFindings { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public Treatment Treatment { get; set; }
        public DateTime RecommendedVisitDate { get; set; }
    }
}
