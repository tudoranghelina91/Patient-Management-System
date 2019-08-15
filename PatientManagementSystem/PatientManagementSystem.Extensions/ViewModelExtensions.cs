using PatientManagementSystem.Domain;
using PatientManagementSystem.Web.Models;
using System.Collections.Generic;

namespace PatientManagementSystem.Extensions
{
    public static class ViewModelExtensions
    {
        public static IList<MedicalRecordEntry> ToDomainModel(this IList<MedicalRecordEntryViewModel> medicalRecordEntryViewModels)
        {
            IList<MedicalRecordEntry> medicalRecordEntries = new List<MedicalRecordEntry>();

            foreach (var e in medicalRecordEntryViewModels)
            {
                medicalRecordEntries.Add(e.ToDomainModel());
            }
            return medicalRecordEntries;
        }

        public static Admin ToDomainModel(this AdminViewModel adminViewModel)
        {
            Admin admin = new Admin();
            admin.Id = adminViewModel.Id;
            admin.IdentityId = adminViewModel.IdentityId;
            admin.UserName = adminViewModel.UserName;
            admin.Email = adminViewModel.Email;
            admin.FirstName = adminViewModel.FirstName;
            admin.LastName = adminViewModel.LastName;
            admin.SSN = adminViewModel.SSN;
            admin.Country = adminViewModel.Country;
            admin.State = adminViewModel.State;
            admin.City = adminViewModel.City;
            admin.Address1 = adminViewModel.Address1;
            admin.Address2 = adminViewModel.Address2;
            return admin;
        }

        public static Doctor ToDomainModel(this DoctorViewModel doctorViewModel)
        {
            Doctor doctor = new Doctor();
            doctor.Id = doctorViewModel.Id;
            doctor.IdentityId = doctorViewModel.IdentityId;
            doctor.UserName = doctorViewModel.UserName;
            doctor.FirstName = doctorViewModel.FirstName;
            doctor.LastName = doctorViewModel.LastName;
            doctor.SSN = doctorViewModel.SSN;
            doctor.Country = doctorViewModel.Country;
            doctor.State = doctorViewModel.State;
            doctor.City = doctorViewModel.City;
            doctor.Address1 = doctorViewModel.Address1;
            doctor.Address2 = doctorViewModel.Address2;
            doctor.Email = doctorViewModel.Email;
            doctor.Specialization = (Doctor.Specialty)doctorViewModel.Specialization;
            doctor.LicenseNo = doctorViewModel.LicenseNo;
            doctor.University = doctorViewModel.University;
            return doctor;
        }

        public static Patient ToDomainModel(this PatientViewModel patientViewModel)
        {
            Patient patient = new Patient();
            patient.Id = patientViewModel.Id;
            patient.IdentityId = patientViewModel.IdentityId;
            patient.UserName = patientViewModel.UserName;
            patient.FirstName = patientViewModel.FirstName;
            patient.LastName = patientViewModel.LastName;
            patient.SSN = patientViewModel.SSN;
            patient.Country = patientViewModel.Country;
            patient.State = patientViewModel.State;
            patient.City = patientViewModel.City;
            patient.Address1 = patientViewModel.Address1;
            patient.Address2 = patientViewModel.Address2;
            patient.Email = patientViewModel.Email;
            patient.EmergencyContactNumber = patientViewModel.EmergencyContactNumber;
            patient.MedicalRecord = patientViewModel.MedicalRecord.ToDomainModel();
            return patient;
        }

        public static MedicalRecordEntry ToDomainModel(this MedicalRecordEntryViewModel medicalRecordEntryViewModel)
        {
            MedicalRecordEntry medicalRecordEntry = new MedicalRecordEntry();
            medicalRecordEntry.Id = medicalRecordEntryViewModel.Id;
            medicalRecordEntry.ExaminationScope = medicalRecordEntryViewModel.ExaminationScope;
            medicalRecordEntry.ReasonForVisit = medicalRecordEntryViewModel.ReasonForVisit;
            medicalRecordEntry.RecommendedVisitDate = medicalRecordEntryViewModel.RecommendedVisitDate;
            medicalRecordEntry.Diagnosis = medicalRecordEntryViewModel.Diagnosis;
            medicalRecordEntry.ExamFindings = medicalRecordEntryViewModel.ExamFindings.ToDomainModel();
            medicalRecordEntry.Patient = medicalRecordEntryViewModel.PatientViewModel.ToDomainModel();
            medicalRecordEntry.TimeEntry = medicalRecordEntryViewModel.TimeEntry;
            medicalRecordEntry.RecommendedVisitDate = medicalRecordEntryViewModel.RecommendedVisitDate;

            return medicalRecordEntry;
        }

        public static Diagnosis ToDomainModel(this DiagnosisViewModel diagnosisViewModel)
        {
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.Id = diagnosisViewModel.Id;
            diagnosis.Name = diagnosisViewModel.Name;
            diagnosis.Description = diagnosisViewModel.Description;
            diagnosis.Type = diagnosisViewModel.Type;
            diagnosis.ExcludesOne = diagnosisViewModel.ExcludesOne;
            diagnosis.ExcludesTwo = diagnosisViewModel.ExcludesTwo;
            diagnosis.Inclusions = diagnosisViewModel.Inclusions;

            return diagnosis;
        }

        public static ExamFindings ToDomainModel(this ExamFindingsViewModel examFindingsViewModel)
        {
            ExamFindings examFindings = new ExamFindings();
            examFindings.Id = examFindingsViewModel.Id;
            examFindings.Abnormal = examFindingsViewModel.Abnormal;
            examFindings.Positive = examFindingsViewModel.Positive;
            examFindings.RelevantNegative = examFindingsViewModel.RelevantNegative;
            return examFindings;
        }
        
        public static Treatment ToDomainModel(this TreatmentViewModel treatmentViewModel)
        {
            Treatment treatment = new Treatment();
            treatment.Id = treatmentViewModel.Id;
            treatment.Details = treatmentViewModel.Details;
            treatment.Recommendations = treatmentViewModel.Recommendations;

            return treatment;
        }

    }
}