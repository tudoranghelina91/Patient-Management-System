using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    class Patient : User
    {
        public int[] InsuranceNumber { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
