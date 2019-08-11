using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Domain
{
    public class Patient : User
    {
        [Required]
        public int[] InsuranceNumber { get; set; }
        [Required]
        public MedicalRecord MedicalRecord { get; set; }
        [Required]
        public string EmergencyContactNumber { get; set; }
    }
}
