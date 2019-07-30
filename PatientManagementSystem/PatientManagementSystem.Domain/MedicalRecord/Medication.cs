using System.Collections.Generic;

namespace PatientManagementSystem.Domain
{
    public class Medication : BaseEntity
    {
        public IList<string> Administered { get; set; }
        public IList<string> Prescribed { get; set; }
        public IList<string> Renewed { get; set; }
        public IList<string> Allergies { get; set; }
    }
}
