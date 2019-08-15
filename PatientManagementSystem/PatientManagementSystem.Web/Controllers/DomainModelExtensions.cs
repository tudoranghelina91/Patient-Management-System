﻿using PatientManagementSystem.Domain;
using PatientManagementSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Controllers
{
    public static class DomainModelExtensions
    {
        public static IList<PatientViewModel> ToViewModel(this IList<Patient> patients)
        {
            IList<PatientViewModel> patientViewModels = new List<PatientViewModel>();
            foreach (var p in patients)
            {
                patientViewModels.Add(p.ToViewModel());
            }

            return patientViewModels;
        }

        public static IList<MedicalRecordEntryViewModel> ToViewModel(this IList<MedicalRecordEntry> medicalRecordEntries)
        {
            IList<MedicalRecordEntryViewModel> medicalRecordEntryViewModels = new List<MedicalRecordEntryViewModel>();
            foreach (var e in medicalRecordEntries)
            {
                medicalRecordEntryViewModels.Add(e.ToViewModel());
            }

            return medicalRecordEntryViewModels;
        }

        public static AdminViewModel ToViewModel(this Admin admin)
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.Id = admin.Id;
            adminViewModel.IdentityId = admin.IdentityId;
            adminViewModel.UserName = admin.UserName;
            adminViewModel.Email = admin.Email;
            adminViewModel.FirstName = admin.FirstName;
            adminViewModel.LastName = admin.LastName;
            adminViewModel.SSN = admin.SSN;
            adminViewModel.Country = admin.Country;
            adminViewModel.State = admin.State;
            adminViewModel.City = admin.City;
            adminViewModel.Address1 = admin.Address1;
            adminViewModel.Address2 = admin.Address2;
            return adminViewModel;
        }

        public static DoctorViewModel ToViewModel(this Doctor doctor)
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.Id = doctor.Id;
            doctorViewModel.IdentityId = doctor.IdentityId;
            doctorViewModel.UserName = doctor.UserName;
            doctorViewModel.FirstName = doctor.FirstName;
            doctorViewModel.LastName = doctor.LastName;
            doctorViewModel.SSN = doctor.SSN;
            doctorViewModel.Country = doctor.Country;
            doctorViewModel.State = doctor.State;
            doctorViewModel.City = doctor.City;
            doctorViewModel.Address1 = doctor.Address1;
            doctorViewModel.Address2 = doctor.Address2;
            doctorViewModel.Email = doctor.Email;
            doctorViewModel.Specialization = (DoctorViewModel.Specialty)doctor.Specialization;
            doctorViewModel.LicenseNo = doctor.LicenseNo;
            doctorViewModel.University = doctor.University;
            return doctorViewModel;
        }

        public static PatientViewModel ToViewModel(this Patient patient)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Id = patient.Id;
            patientViewModel.IdentityId = patient.IdentityId;
            patientViewModel.UserName = patient.UserName;
            patientViewModel.FirstName = patient.FirstName;
            patientViewModel.LastName = patient.LastName;
            patientViewModel.SSN = patient.SSN;
            patientViewModel.Country = patient.Country;
            patientViewModel.State = patient.State;
            patientViewModel.City = patient.City;
            patientViewModel.Address1 = patient.Address1;
            patientViewModel.Address2 = patient.Address2;
            patientViewModel.Email = patient.Email;
            patientViewModel.EmergencyContactNumber = patient.EmergencyContactNumber;
            patientViewModel.MedicalRecord = patient.MedicalRecord.ToViewModel();
            return patientViewModel;
        }

        public static MedicalRecordEntryViewModel ToViewModel(this MedicalRecordEntry medicalRecordEntry)
        {
            MedicalRecordEntryViewModel medicalRecordEntryViewModel = new MedicalRecordEntryViewModel();
            medicalRecordEntryViewModel.Id = medicalRecordEntry.Id;
            medicalRecordEntryViewModel.ExaminationScope = medicalRecordEntry.ExaminationScope;
            medicalRecordEntryViewModel.ReasonForVisit = medicalRecordEntry.ReasonForVisit;
            medicalRecordEntryViewModel.RecommendedVisitDate = medicalRecordEntry.RecommendedVisitDate;
            medicalRecordEntryViewModel.TimeEntry = medicalRecordEntry.TimeEntry;
            medicalRecordEntryViewModel.ExamFindings = medicalRecordEntry.ExamFindings.ToViewModel();
            medicalRecordEntryViewModel.Diagnosis = medicalRecordEntry.Diagnosis.ToViewModel();
            medicalRecordEntryViewModel.Treatment = medicalRecordEntry.Treatment.ToViewModel();

            return medicalRecordEntryViewModel;
        }

        public static DiagnosisViewModel ToViewModel(this Diagnosis diagnosis)
        {
            DiagnosisViewModel diagnosisViewModel = new DiagnosisViewModel();
            diagnosisViewModel.Id = diagnosis.Id;
            diagnosisViewModel.Name = diagnosis.Name;
            diagnosisViewModel.Type = diagnosis.Type;
            diagnosisViewModel.Description = diagnosis.Description;
            diagnosisViewModel.Inclusions = diagnosis.Inclusions;
            diagnosisViewModel.ExcludesOne = diagnosis.ExcludesOne;
            diagnosisViewModel.ExcludesTwo = diagnosis.ExcludesTwo;

            return diagnosisViewModel;
        }

        public static ExamFindingsViewModel ToViewModel(this ExamFindings examFindings)
        {
            ExamFindingsViewModel examFindingsViewModel = new ExamFindingsViewModel();
            examFindingsViewModel.Id = examFindings.Id;
            examFindingsViewModel.Positive = examFindings.Positive;
            examFindingsViewModel.RelevantNegative = examFindings.RelevantNegative;
            examFindingsViewModel.Abnormal = examFindings.Abnormal;

            return examFindingsViewModel;
        }

        public static TreatmentViewModel ToViewModel(this Treatment treatment)
        {
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Id = treatment.Id;
            treatmentViewModel.Details = treatment.Details;
            treatmentViewModel.Recommendations = treatment.Recommendations;

            return treatmentViewModel;
        }
    }
}