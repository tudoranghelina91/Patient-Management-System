using PatientManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Repositories
{
    public abstract class BaseRepository : IBaseRepository<BaseEntity>
    {
        public abstract void Add(BaseEntity entity);
        public abstract IList<BaseEntity> GetAll();
        public abstract BaseEntity GetById(int id);
    }
}
