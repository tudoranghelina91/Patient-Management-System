using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PatientManagementSystem.Extensions;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class MedicalRecordsController : Controller
    {
        IMedicalRecordEntryRepository medicalRecordEntryRepository = new MedicalRecordEntryRepository();
        IPatientRepository patientRepository = new PatientRepository();
        IExamFindingsRepository examFindingsRepository = new ExamFindingsRepository();
        // GET: DoctorArea/MedicalRecords
        [Authorize(Roles = "Doctor")]
        public ActionResult Index(int patientId)
        {
            //TempData.Clear();


            IList<MedicalRecordEntryViewModel> medicalRecord = new List<MedicalRecordEntryViewModel>();
            medicalRecord = medicalRecordEntryRepository.GetForPatient(patientId).ToViewModel();
            return View(medicalRecord);
        }

        private void AddPatientToTempData(int patientId)
        {
            if (!TempData.Keys.Contains("patientFirstName"))
            {
                TempData.Add("patientFirstName", patientRepository.GetById(patientId).FirstName);
            }
            if (!TempData.Keys.Contains("patientLastName"))
            {
                TempData.Add("patientLastName", patientRepository.GetById(patientId).LastName);
            }
            if (!TempData.Keys.Contains("patientId"))
            {
                TempData.Add("patientId", patientId);
            }
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int patientId)
        {
            AddPatientToTempData(patientId);
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

                medicalRecordEntryRepository.Add(medicalRecordEntryViewModel.ToDomainModel());
                return RedirectToAction("Index", new { patientId = medicalRecordEntryViewModel.PatientViewModel.Id });
            }
            TempData.Clear();
            AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);
            return View(medicalRecordEntryViewModel);
        }
    }
}