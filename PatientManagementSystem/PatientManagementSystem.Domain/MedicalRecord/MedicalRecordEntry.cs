using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementSystem.Domain
{
    public class MedicalRecordEntry : BaseEntity
    {
        [Column(TypeName = "datetime2")]
        public DateTime TimeEntry { get; set; }
        public string ReasonForVisit { get; set; }
        public string ExaminationScope { get; set; }
        public string Diagnosis { get; set; }
        public Patient Patient { get; set; } = new Patient();
        [Column(TypeName = "datetime2")]
        public DateTime RecommendedVisitDate { get; set; }
    }
}
