using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Services
{
    interface IICDCodeService
    {
        string GetICDCode(string ICDCode);
        Diagnosis Deserialize(string ICDCode);
    }
}
