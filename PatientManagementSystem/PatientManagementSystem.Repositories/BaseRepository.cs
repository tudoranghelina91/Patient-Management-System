using PatientManagementSystem.Domain;
using System.Collections.Generic;

namespace PatientManagementSystem.Repositories
{
    public abstract class BaseRepository : IBaseRepository<BaseEntity>
    {
        public abstract void Add(BaseEntity entity);
        public abstract IList<BaseEntity> GetAll();
        public abstract BaseEntity GetById(int id);
        public abstract void Update(BaseEntity entity);
        public abstract void Delete(BaseEntity entity);
    }
}
