using System;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public class MedicalRecordEntryViewModel : BaseViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time Entry")]
        public DateTime TimeEntry { get; set; }
        [Required]
        [Display(Name = "Reason For Visit")]
        public string ReasonForVisit { get; set; }
        [Required]
        [Display(Name = "Examination Scope")]
        public string ExaminationScope { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Recommended Visit Date")]
        public DateTime RecommendedVisitDate { get; set; }
        [Required]
        public PatientViewModel PatientViewModel { get; set; } = new PatientViewModel();
    }
}