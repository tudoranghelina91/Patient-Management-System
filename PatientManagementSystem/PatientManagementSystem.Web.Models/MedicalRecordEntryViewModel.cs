using System;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public class MedicalRecordEntryViewModel : BaseViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeEntry { get; set; }
        [Required]
        public string ReasonForVisit { get; set; }
        [Required]
        public string ExaminationScope { get; set; }
        [Required]
        public ExamFindingsViewModel ExamFindings { get; set; } = new ExamFindingsViewModel();
        public string Diagnosis { get; set; }
        public TreatmentViewModel Treatment { get; set; } = new TreatmentViewModel();
        [DataType(DataType.DateTime)]
        public DateTime RecommendedVisitDate { get; set; }
        [Required]
        public PatientViewModel PatientViewModel { get; set; } = new PatientViewModel();
    }
}