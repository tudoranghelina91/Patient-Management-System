using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PatientManagementSystem.Web.Models
{
    public class PatientViewModel : UserViewModel
    {
        public IList<MedicalRecordEntryViewModel> MedicalRecord { get; set; } = new List<MedicalRecordEntryViewModel>();
        [Required]
        public string EmergencyContactNumber { get; set; }
    }
}