namespace PatientManagementSystem.Domain
{
    public class Medication : BaseEntity
    {
        public MedicalRecordEntry MedicalRecordEntry { get; set; } = new MedicalRecordEntry();
        public string Administered { get; set; }
        public string Prescribed { get; set; }
        public string Renewed { get; set; }
        public string Allergies { get; set; }
    }
}
