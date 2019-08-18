namespace PatientManagementSystem.Domain
{
    public class Treatment : BaseEntity
    {
        public MedicalRecordEntry MedicalRecordEntry { get; set; } = new MedicalRecordEntry();
        public string Details { get; set; }
        public string Recommendations { get; set; }
    }
}
