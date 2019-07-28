using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    class Medication : BaseEntity
    {
        public IList<string> Administered { get; set; }
        public IList<string> Prescribed { get; set; }
        public IList<string> Renewed { get; set; }
        public IList<string> Allergies { get; set; }
    }
}
