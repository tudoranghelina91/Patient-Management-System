using System.Collections.Generic;

namespace PatientManagementSystem.Domain
{
    public class MedicalRecord : BaseEntity
    {
        public IList<MedicalRecordEntry> MedicalRecordEntries { get; set; }
    }
}
