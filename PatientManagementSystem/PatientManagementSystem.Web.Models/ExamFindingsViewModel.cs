namespace PatientManagementSystem.Web.Models
{
    public class ExamFindingsViewModel : BaseViewModel
    {
        public string Positive { get; set; }
        public string RelevantNegative { get; set; }
        public string Abnormal { get; set; }
    }
}