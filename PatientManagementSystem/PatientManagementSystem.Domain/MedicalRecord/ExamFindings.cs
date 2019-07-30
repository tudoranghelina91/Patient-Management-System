namespace PatientManagementSystem.Domain
{
    class ExamFindings : BaseEntity
    {
        public string Positive { get; set; }
        public string RelevantNegative { get; set; }
        public string Abnormal { get; set; }
    }
}
