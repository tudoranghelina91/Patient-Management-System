using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public class MedicalRecordViewModel
    {
        public IList<MedicalRecordEntryViewModel> MedicalRecordEntries { get; set; }
    }
}