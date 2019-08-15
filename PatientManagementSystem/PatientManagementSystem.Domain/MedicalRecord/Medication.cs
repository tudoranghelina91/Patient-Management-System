using System.Collections.Generic;

namespace PatientManagementSystem.Domain
{
    public class Medication : BaseEntity
    {
        public IList<string> Administered { get; set; } = new List<string>();
        public IList<string> Prescribed { get; set; } = new List<string>();
        public IList<string> Renewed { get; set; } = new List<string>();
        public IList<string> Allergies { get; set; } = new List<string>();
    }
}
