namespace PatientManagementSystem.Web.Models
{
    public class ExamFindingsViewModel : BaseViewModel
    {
        public MedicalRecordEntryViewModel MedicalRecordEntryViewModel { get; set; } = new MedicalRecordEntryViewModel();
        public string Positive { get; set; }
        public string RelevantNegative { get; set; }
        public string Abnormal { get; set; }
    }
}