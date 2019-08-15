using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Areas.AdminArea.Controllers;
using PatientManagementSystem.Web.Controllers;
using PatientManagementSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class MedicalRecordsController : Controller
    {
        IMedicalRecordEntryRepository medicalRecordEntryRepository = new MedicalRecordEntryRepository();
        IPatientRepository patientRepository = new PatientRepository();
        IExamFindingsRepository examFindingsRepository = new ExamFindingsRepository();
        IDiagnosisRepository diagnosisRepository = new DiagnosisRepository();
        IMedicationRepository medicationRepository = new MedicationRepository();
        ITreatmentRepository treatmentRepository = new TreatmentRepository();
        // GET: DoctorArea/MedicalRecords
        [Authorize(Roles = "Doctor")]
        public ActionResult Index(int patientId)
        {
            IList<MedicalRecordEntryViewModel> medicalRecord = new List<MedicalRecordEntryViewModel>();
            medicalRecord = medicalRecordEntryRepository.GetForPatient(patientId).ToViewModel();
            return View(medicalRecord);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int patientId)
        {
            TempData.Add("patientId", patientId);
            MedicalRecordEntryViewModel medicalRecordEntryViewModel = new MedicalRecordEntryViewModel { PatientViewModel = patientRepository.GetById(patientId).ToViewModel() };
            return View(medicalRecordEntryViewModel);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Create(MedicalRecordEntryViewModel medicalRecordEntryViewModel)
        {
            medicalRecordEntryViewModel.PatientViewModel = patientRepository.GetById((int)TempData["patientId"]).ToViewModel();
            if (ModelState.IsValid)
            {
                examFindingsRepository.Add(medicalRecordEntryViewModel.ExamFindings.ToDomainModel());
                diagnosisRepository.Add(medicalRecordEntryViewModel.Diagnosis.ToDomainModel());

                medicalRecordEntryRepository.Add(medicalRecordEntryViewModel.ToDomainModel());
                return RedirectToAction("Index", new { patientId = medicalRecordEntryViewModel.PatientViewModel.Id });
            }
            TempData.Clear();
            TempData.Add("patientId", medicalRecordEntryViewModel.PatientViewModel.Id);
            return View(medicalRecordEntryViewModel);
        }
    }
}