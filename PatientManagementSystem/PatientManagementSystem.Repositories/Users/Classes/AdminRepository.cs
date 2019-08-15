using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class AdminRepository : Context, IAdminRepository
    {
        public void Add(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        public IList<Admin> GetAll()
        {
            return context.Admins.ToList();
        }

        public Admin GetById(int id)
        {
            return context.Admins.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Admin entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
