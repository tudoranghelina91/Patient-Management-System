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
        // GET: DoctorArea/MedicalRecords
        [Authorize(Roles = "Doctor")]
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
        public ActionResult Index(int patientId)
        {
            AddPatientToTempData(patientId);
            IList<MedicalRecordEntryViewModel> medicalRecord = new List<MedicalRecordEntryViewModel>();
            medicalRecord = medicalRecordEntryRepository.GetForPatient(patientId).ToViewModel();
            return View(medicalRecord);
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
            AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);

            if (ModelState.IsValid)
            {
                AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);
                medicalRecordEntryRepository.Add(medicalRecordEntryViewModel.ToDomainModel());
                return RedirectToAction("Index", new { patientId = medicalRecordEntryViewModel.PatientViewModel.Id });
            }
            AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);
            return View(medicalRecordEntryViewModel);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int id, int patientId)
        {
            MedicalRecordEntryViewModel medicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(id).ToViewModel();
            medicalRecordEntryViewModel.PatientViewModel = patientRepository.GetById(patientId).ToViewModel();
            AddPatientToTempData(patientId);
            return View(medicalRecordEntryViewModel);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int id, int patientId)
        {
            MedicalRecordEntryViewModel medicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(id).ToViewModel();
            medicalRecordEntryViewModel.PatientViewModel = patientRepository.GetById(patientId).ToViewModel();
            AddPatientToTempData(patientId);
            return View(medicalRecordEntryViewModel);
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Edit(MedicalRecordEntryViewModel medicalRecordEntryViewModel, int patientId)
        {
            medicalRecordEntryViewModel.PatientViewModel = patientRepository.GetById(patientId).ToViewModel();
            AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);

            if (ModelState.IsValid)
            {
                AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);
                medicalRecordEntryRepository.Update(medicalRecordEntryViewModel.ToDomainModel());
                return RedirectToAction("Index", new { patientId = medicalRecordEntryViewModel.PatientViewModel.Id });
            }
            AddPatientToTempData(medicalRecordEntryViewModel.PatientViewModel.Id);
            return View(medicalRecordEntryViewModel);
        }
    }
}