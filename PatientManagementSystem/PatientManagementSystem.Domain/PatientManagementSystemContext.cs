using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    public class PatientManagementSystemContext : DbContext
    {
        public PatientManagementSystemContext() : base()
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
