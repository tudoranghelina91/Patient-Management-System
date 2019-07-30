using System.Data.Entity;
using PatientManagementSystem.Domain;

namespace PatientManagementSystem.DataAccess
{
    public class PatientManagementSystemDBContext : DbContext
    {
        public PatientManagementSystemDBContext() : base("PatientManagementSystemDatabase")
        {

        }

        DbSet<Admin> Admins { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<Diagnosis> Diagnoses { get; set; }
        DbSet<ExamFindings> ExamFindings { get; set; }
        DbSet<MedicalRecord> MedicalRecords { get; set; }
        DbSet<MedicalRecordEntry> MedicalRecordEntries { get; set; }
        DbSet<Medication> Medications { get; set; }
        DbSet<Treatment> Treatments { get; set; }
    }
}
