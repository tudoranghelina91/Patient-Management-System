namespace PatientManagementSystem.Domain
{
    public class ExamFindings : BaseEntity
    {
        public string Positive { get; set; }
        public string RelevantNegative { get; set; }
        public string Abnormal { get; set; }
    }
}
