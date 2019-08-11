using PatientManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Repositories
{
    interface IBaseRepository<T>
    {
        T GetById(int id);
        IList<T> GetAll();
        void Add(T entity);
    }
}
