using PatientManagementSystem.Extensions;
using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class ExamFindingsController : Controller
    {
        IExamFindingsRepository examFindingsRepository = new ExamFindingsRepository();
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
            TempData.Keep();
            IList<ExamFindingsViewModel> examFindingsViewModels = new List<ExamFindingsViewModel>();
            examFindingsViewModels = examFindingsRepository.GetByMedicalRecordEntryId(medicalRecordId).ToViewModel();
            return View(examFindingsViewModels);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int medicalRecordId)
        {
            AddMedicalRecordToTempData(medicalRecordId);
            TempData.Keep();
            ExamFindingsViewModel examFindingsViewModel = new ExamFindingsViewModel { MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel() };
            return View(examFindingsViewModel);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Create(ExamFindingsViewModel examFindingsViewModel)
        {
            examFindingsViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById((int)TempData["medicalRecordId"]).ToViewModel();
            AddMedicalRecordToTempData(examFindingsViewModel.MedicalRecordEntryViewModel.Id);

            if (ModelState.IsValid)
            {
                AddMedicalRecordToTempData(examFindingsViewModel.MedicalRecordEntryViewModel.Id);
                examFindingsRepository.Add(examFindingsViewModel.ToDomainModel());
                return RedirectToAction("Index", new { medicalRecordId = examFindingsViewModel.MedicalRecordEntryViewModel.Id });
            }
            AddMedicalRecordToTempData(examFindingsViewModel.MedicalRecordEntryViewModel.Id);
            return View(examFindingsViewModel);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int id, int medicalRecordId)
        {
            ExamFindingsViewModel examFindingsViewModel = examFindingsRepository.GetById(id).ToViewModel();
            examFindingsViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicalRecordId);
            TempData.Keep();
            return View(examFindingsViewModel);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int id, int medicalRecordId)
        {
            ExamFindingsViewModel examFindingsViewModel = examFindingsRepository.GetById(id).ToViewModel();
            examFindingsViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(medicalRecordId);
            return View(examFindingsViewModel);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult Edit(ExamFindingsViewModel examFindingsViewModel, int medicalRecordId)
        {
            examFindingsViewModel.MedicalRecordEntryViewModel = medicalRecordEntryRepository.GetById(medicalRecordId).ToViewModel();
            AddMedicalRecordToTempData(examFindingsViewModel.MedicalRecordEntryViewModel.Id);

            if (ModelState.IsValid)
            {
                AddMedicalRecordToTempData(examFindingsViewModel.MedicalRecordEntryViewModel.Id);
                examFindingsRepository.Update(examFindingsViewModel.ToDomainModel());
                return RedirectToAction("Index", new { medicalRecordId = examFindingsViewModel.MedicalRecordEntryViewModel.Id });
            }
            AddMedicalRecordToTempData(examFindingsViewModel.MedicalRecordEntryViewModel.Id);
            return View(examFindingsViewModel);
        }
    }
}