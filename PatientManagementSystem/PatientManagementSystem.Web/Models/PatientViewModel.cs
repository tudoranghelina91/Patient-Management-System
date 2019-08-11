using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PatientManagementSystem.Web.Models
{
    public class PatientViewModel : UserViewModel
    {
        [Required]
        public int[] InsuranceNumber { get; set; }
        [Required]
        public MedicalRecordViewModel MedicalRecord { get; set; }
        [Required]
        public string EmergencyContactNumber { get; set; }
    }
}