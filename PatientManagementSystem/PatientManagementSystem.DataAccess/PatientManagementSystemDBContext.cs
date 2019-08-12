using System.Data.Entity;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.DataAccess
{
    public class PatientManagementSystemDBContext : DbContext
    {
        public PatientManagementSystemDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<ExamFindings> ExamFindings { get; set; }
        public DbSet<MedicalRecordEntry> MedicalRecordEntries { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
    }
}
