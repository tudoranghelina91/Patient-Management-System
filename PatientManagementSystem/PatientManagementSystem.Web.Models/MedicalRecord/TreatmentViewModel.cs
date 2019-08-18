namespace PatientManagementSystem.Web.Models
{
    public class TreatmentViewModel : BaseViewModel
    {
        public MedicalRecordEntryViewModel MedicalRecordEntryViewModel { get; set; } = new MedicalRecordEntryViewModel();
        public string Details { get; set; }
        public string Recommendations { get; set; }
    }
}