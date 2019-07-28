using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    class MedicalRecord : BaseEntity
    {
        public Patient Patient { get; set; }
        public IList<MedicalRecordEntry> MedicalRecordEntries { get; set; }
    }
}
