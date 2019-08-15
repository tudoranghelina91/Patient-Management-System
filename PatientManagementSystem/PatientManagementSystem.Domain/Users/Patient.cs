using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Domain
{
    public class Patient : User
    {
        public IList<MedicalRecordEntry> MedicalRecord { get; set; } = new List<MedicalRecordEntry>();
        [Required]
        public string EmergencyContactNumber { get; set; }
    }
}
