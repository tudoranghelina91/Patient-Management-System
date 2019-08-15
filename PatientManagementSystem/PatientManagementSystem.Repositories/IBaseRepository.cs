using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        IList<T> GetAll();
        void Add(T entity);
        void Update(T entity);
    }
}
