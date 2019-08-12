using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public class MedicalRecordEntryViewModel : BaseViewModel
    {
        public DateTime TimeEntry { get; set; }
        public string ReasonForVisit { get; set; }
        public string ExaminationScope { get; set; }
        public ExamFindingsViewModel ExamFindings { get; set; } = new ExamFindingsViewModel();
        public DiagnosisViewModel Diagnosis { get; set; } = new DiagnosisViewModel();
        public TreatmentViewModel Treatment { get; set; } = new TreatmentViewModel();
        public DateTime RecommendedVisitDate { get; set; }
    }
}