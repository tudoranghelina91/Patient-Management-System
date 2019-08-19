using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public class TreatmentViewModel : BaseViewModel
    {
        public MedicalRecordEntryViewModel MedicalRecordEntryViewModel { get; set; } = new MedicalRecordEntryViewModel();
        [Display(Name = "Treatment Details")]
        public string Details { get; set; }
        public string Recommendations { get; set; }
    }
}