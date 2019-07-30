using System.Collections.Generic;

namespace PatientManagementSystem.Domain
{
    class MedicalRecord : BaseEntity
    {
        public IList<MedicalRecordEntry> MedicalRecordEntries { get; set; }
    }
}
