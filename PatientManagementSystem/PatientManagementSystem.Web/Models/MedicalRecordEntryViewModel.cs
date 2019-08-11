using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public class MedicalRecordEntryViewModel
    {
        public DateTime TimeEntry { get; set; }
        public string ReasonForVisit { get; set; }
        public string ExaminationScope { get; set; }
        public ExamFindingsViewModel ExamFindings { get; set; }
        public DiagnosisViewModel Diagnosis { get; set; }
        public TreatmentViewModel Treatment { get; set; }
        public DateTime RecommendedVisitDate { get; set; }
    }
}