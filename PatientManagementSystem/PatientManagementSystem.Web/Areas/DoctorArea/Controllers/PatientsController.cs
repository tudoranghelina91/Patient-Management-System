using PatientManagementSystem.Domain;
using PatientManagementSystem.Repositories;
using PatientManagementSystem.Web.Controllers;
using PatientManagementSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementSystem.Web.Areas.DoctorArea.Controllers
{
    public class PatientsController : Controller
    {
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
            PatientViewModel patientViewModel = patientRepository.GetById(id).ToViewModel();
            return View(patientViewModel);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int id)
        {
            PatientViewModel patientViewModel = patientRepository.GetById(id).ToViewModel();
            TempData.Add("patientId", patientViewModel.Id);
            return View(patientViewModel);
        }
    }
}