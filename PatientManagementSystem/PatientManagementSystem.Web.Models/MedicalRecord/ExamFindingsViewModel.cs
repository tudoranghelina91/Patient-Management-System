using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public class ExamFindingsViewModel : BaseViewModel
    {
        public MedicalRecordEntryViewModel MedicalRecordEntryViewModel { get; set; } = new MedicalRecordEntryViewModel();
        [Display(Name = "Positive Findings")]
        public string Positive { get; set; }
        [Display(Name = "Relevant Negative Findings")]
        public string RelevantNegative { get; set; }
        [Display(Name = "Abnormal Findings")]
        public string Abnormal { get; set; }
    }
}