using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public class DoctorViewModel : UserViewModel
    {
        public enum Specialty
        {
            [Display(Name = "Accident and Emergency Medicine")]
            AccidentAndEmergencyMedicine,
            Allergology,
            Anaesthetics,
            Cardiology,
            [Display(Name = "Child Psychiatry")]
            ChildPsychiatry,
            [Display(Name = "Clinical Biology")]
            ClinicalBiology,
            [Display(Name = "Clinical Chemistry")]
            ClinicalChemistry,
            [Display(Name = "Clinical Neurophysiology,")]
            ClinicalNeurophysiology,
            [Display(Name = "Craniofacial Surgery")]
            CraniofacialSurgery,
            Dermatology,
            Endocrinology,
            [Display(Name = "Family & General Medicine")]
            FamilyAndGeneralMedicine,
            [Display(Name = "Gastroenterologic Surgery")]
            GastroenterologicSurgery,
            Gastroenterology,
            [Display(Name = "General Practice")]
            GeneralPractice,
            [Display(Name = "General Surgery")]
            GeneralSurgery,
            Geriatrics,
            Hematology,
            Immunology,
            [Display(Name = "Infectious Diseases")]
            InfectiousDiseases,
            [Display(Name = "Internal Medicine")]
            InternalMedicine,
            [Display(Name = "Laboratory Medicine")]
            LaboratoryMedicine,
            Microbiology,
            Nephrology,
            Neuropsychiatry,
            Neurology,
            Neurosurgery,
            NuclearMedicine,
            [Display(Name = "Obstretics & Gynaecology")]
            ObstetricsAndGynaecology,
            [Display(Name = "Occupational Medicine")]
            OccupationalMedicine,
            Ophthalmology,
            [Display(Name = "Oral & Maxillofacial Surgery")]
            OralAndMaxillofacialSurgery,
            Orthopaedics,
            Otorhinolaryngology,
            PaediatricSurgery,
            Paediatrics,
            Pathology,
            Pharmacology,
            [Display(Name = "Physical Medicine & Rehabilitation")]
            PhysicalMedicineAndRehabilitation,
            [Display(Name = "Plastic Surgery")]
            PlasticSurgery,
            [Display(Name = "Podiatrics Surgery")]
            PodiatricSurgery,
            [Display(Name = "Preventive Medicine")]
            PreventiveMedicine,
            Psychiatry,
            [Display(Name = "Public Health")]
            PublicHealth,
            [Display(Name = "Radiation Oncology")]
            RadiationOncology,
            Radiology,
            [Display(Name = "Respiratory Medicine")]
            RespiratoryMedicine,
            Rheumatology,
            Stomatology,
            [Display(Name = "Thoracic Surgery")]
            ThoracicSurgery,
            [Display(Name = "Tropical Medicine")]
            TropicalMedicine,
            Urology,
            [Display(Name = "Vascular Surgery")]
            VascularSurgery,
            Venereology,
        }
        [Required]
        public string University { get; set; }
        [Required]
        public Specialty Specialization { get; set; }
        [Required]
        public string LicenseNo { get; set; }
    }
}