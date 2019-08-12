using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public class TreatmentViewModel : BaseViewModel
    {
        public string Details { get; set; }
        public string Recommendations { get; set; }
    }
}