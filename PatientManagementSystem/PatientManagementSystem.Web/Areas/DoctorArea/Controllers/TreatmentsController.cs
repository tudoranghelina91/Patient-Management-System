using PatientManagementSystem.Extensions;
using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class TreatmentsController : Controller
    {
        ITreatmentRepository treatmentRepository = new TreatmentRepository();
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
        public ActionResult Index(int medicalRecordId)
        {
            AddMedicalRecordToTempData(medicalRecordId);
            IList<TreatmentViewModel> treatmentViewModels = new List<TreatmentViewModel>();
            treatmentViewModels = treatmentRepository.GetByMedicalRecordEntryId(medicalRecordId).ToViewModel();
            return View(treatmentViewModels);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int medicalRecordId)
        {
            AddMedicalRecordToTempData(medicalRecordId);
            TempData.Keep();
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel { MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel() };
            return View(treatmentViewModel);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Create(TreatmentViewModel treatmentViewModel)
        {
            treatmentViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById((int)TempData["medicalRecordId"]).ToViewModel();
            AddMedicalRecordToTempData(treatmentViewModel.MedicalRecordEntryViewModel.Id);

            if (ModelState.IsValid)
            {
                AddMedicalRecordToTempData(treatmentViewModel.MedicalRecordEntryViewModel.Id);
                treatmentRepository.Add(treatmentViewModel.ToDomainModel());
                return RedirectToAction("Index", new { medicalRecordId = treatmentViewModel.MedicalRecordEntryViewModel.Id });
            }
            AddMedicalRecordToTempData(treatmentViewModel.MedicalRecordEntryViewModel.Id);
            return View(treatmentViewModel);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int id, int medicalRecordId)
        {
            TreatmentViewModel treatmentViewModel = treatmentRepository.GetById(id).ToViewModel();
            treatmentViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicalRecordId);
            return View(treatmentViewModel);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int id, int medicalRecordId)
        {
            TreatmentViewModel treatmentViewModel = treatmentRepository.GetById(id).ToViewModel();
            treatmentViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicalRecordId);
            return View(treatmentViewModel);
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Edit(TreatmentViewModel treatmentViewModel, int medicalRecordId)
        {
            treatmentViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(treatmentViewModel.MedicalRecordEntryViewModel.Id);

            if (ModelState.IsValid)
            {
                AddMedicalRecordToTempData(treatmentViewModel.MedicalRecordEntryViewModel.Id);
                treatmentRepository.Update(treatmentViewModel.ToDomainModel());
                return RedirectToAction("Index", new { medicalRecordId = treatmentViewModel.MedicalRecordEntryViewModel.Id });
            }
            AddMedicalRecordToTempData(treatmentViewModel.MedicalRecordEntryViewModel.Id);
            return View(treatmentViewModel);
        }
    }
}