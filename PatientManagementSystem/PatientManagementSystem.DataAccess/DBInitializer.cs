using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.DataAccess
{
    public class DBInitializer : CreateDatabaseIfNotExists<PatientManagementSystemDBContext>
    {
    }
}
