namespace PatientManagementSystem.Web.Models
{
    public class MedicationViewModel : BaseViewModel
    {
        public MedicalRecordEntryViewModel MedicalRecordEntryViewModel { get; set; } = new MedicalRecordEntryViewModel();
        public string Administered { get; set; }
        public string Prescribed { get; set; }
        public string Renewed { get; set; }
        public string Allergies { get; set; }
    }
}
