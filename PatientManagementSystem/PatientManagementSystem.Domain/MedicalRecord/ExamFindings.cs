namespace PatientManagementSystem.Domain
{
    public class ExamFindings : BaseEntity
    {
        public MedicalRecordEntry MedicalRecordEntry { get; set; } = new MedicalRecordEntry();
        public string Positive { get; set; }
        public string RelevantNegative { get; set; }
        public string Abnormal { get; set; }
    }
}
