using PatientManagementSystem.Extensions;
using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Models;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class MedicationController : Controller
    {
        IMedicationRepository medicationRepository = new MedicationRepository();
        IMedicalRecordEntryRepository medicalRecordEntryRepository = new MedicalRecordEntryRepository();
        [Authorize(Roles = "Doctor")]
        private void AddMedicalRecordToTempData(int medicalRecordId)
        {
            if (!TempData.Keys.Contains("medicalRecordId"))
            {
                TempData.Add("medicalRecordId", medicalRecordEntryRepository.GetById(medicalRecordId).Id);
            }
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int medicalRecordId)
        {
            AddMedicalRecordToTempData(medicalRecordId);
            MedicationViewModel medicationViewModel = new MedicationViewModel { MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel() };
            return View(medicationViewModel);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Create(MedicationViewModel medicationViewModel)
        {
            medicationViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById((int)TempData["medicalRecordId"]).ToViewModel();
            AddMedicalRecordToTempData(medicationViewModel.MedicalRecordEntryViewModel.Id);

            if (ModelState.IsValid)
            {
                AddMedicalRecordToTempData(medicationViewModel.MedicalRecordEntryViewModel.Id);
                medicationRepository.Add(medicationViewModel.ToDomainModel());
                return RedirectToAction("Index", new { medicalRecordId = medicationViewModel.MedicalRecordEntryViewModel.Id });
            }
            AddMedicalRecordToTempData(medicationViewModel.MedicalRecordEntryViewModel.Id);
            return View(medicationViewModel);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int id, int medicalRecordId)
        {
            MedicationViewModel medicationViewModel = medicationRepository.GetById(id).ToViewModel();
            medicationViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicalRecordId);
            return View(medicationViewModel);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int id, int medicalRecordId)
        {
            MedicationViewModel medicationViewModel = medicationRepository.GetById(id).ToViewModel();
            medicationViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicalRecordId);
            return View(medicationViewModel);
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Edit(MedicationViewModel medicationViewModel, int medicalRecordId)
        {
            medicationViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicationViewModel.MedicalRecordEntryViewModel.Id);

            if (ModelState.IsValid)
            {
                AddMedicalRecordToTempData(medicationViewModel.MedicalRecordEntryViewModel.Id);
                medicationRepository.Update(medicationViewModel.ToDomainModel());
                return RedirectToAction("Index", new { medicalRecordId = medicationViewModel.MedicalRecordEntryViewModel.Id });
            }
            AddMedicalRecordToTempData(medicationViewModel.MedicalRecordEntryViewModel.Id);
            return View(medicationViewModel);
        }
    }
}