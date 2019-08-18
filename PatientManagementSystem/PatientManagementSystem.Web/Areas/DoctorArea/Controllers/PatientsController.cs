using PatientManagementSystem.Extensions;
using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class PatientsController : Controller
    {
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

        // GET: DoctorArea/Patients
        IPatientRepository patientRepository = new PatientRepository();
        IMedicalRecordEntryRepository medicalRecordEntryRepository = new MedicalRecordEntryRepository();
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            // parse to patient entity to view model
            IList<PatientViewModel> patients = patientRepository.GetAll().ToViewModel();
            return View(patients);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int id)
        {
            AddPatientToTempData(id);
            PatientViewModel patientViewModel = patientRepository.GetById(id).ToViewModel();
            return View(patientViewModel);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int id)
        {
            AddPatientToTempData(id);
            PatientViewModel patientViewModel = patientRepository.GetById(id).ToViewModel();
            return View(patientViewModel);
        }
    }
}