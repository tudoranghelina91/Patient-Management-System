using System.Collections.Generic;
using System.Linq;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.Repositories
{
    public class DoctorRepository : Context, IDoctorRepository
    {
        public void Add(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

        public IList<Doctor> GetAll()
        {
            return context.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return context.Doctors.FirstOrDefault(d => d.Id == id);
        }
    }
}
