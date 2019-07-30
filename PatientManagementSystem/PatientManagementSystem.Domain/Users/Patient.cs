namespace PatientManagementSystem.Domain
{
    public class Patient : User
    {
        public int[] InsuranceNumber { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
