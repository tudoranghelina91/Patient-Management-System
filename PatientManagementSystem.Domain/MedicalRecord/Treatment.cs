using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    class Treatment : BaseEntity
    {
        public string Details { get; set; }
        public string Recommendations { get; set; }
    }
}
