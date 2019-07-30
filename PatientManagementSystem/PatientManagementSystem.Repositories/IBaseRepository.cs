using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    interface IBaseRepository<T>
    {
        T GetById(int id);
        IList<T> GetAll();
        void Create();
        void Delete();
        void Update(int id);
    }
}
