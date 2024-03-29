﻿using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Domain
{
    public class Doctor : User
    {
        public enum Specialty
        {
            AccidentAndEmergencyMedicine,
            Allergology,
            Anaesthetics,
            Cardiology,
            ChildPsychiatry,
            ClinicalBiology,
            ClinicalChemistry,
            ClinicalNeurophysiology,
            CraniofacialSurgery,
            Dermatology,
            Endocrinology,
            FamilyAndGeneralMedicine,
            GastroenterologicSurgery,
            Gastroenterology,
            GeneralPractice,
            GeneralSurgery,
            Geriatrics,
            Hematology,
            Immunology,
            InfectiousDiseases,
            InternalMedicine,
            LaboratoryMedicine,
            Microbiology,
            Nephrology,
            Neuropsychiatry,
            Neurology,
            Neurosurgery,
            NuclearMedicine,
            ObstetricsAndGynaecology,
            OccupationalMedicine,
            Ophthalmology,
            OralAndMaxillofacialSurgery,
            Orthopaedics,
            Otorhinolaryngology,
            PaediatricSurgery,
            Paediatrics,
            Pathology,
            Pharmacology,
            PhysicalMedicineAndRehabilitation,
            PlasticSurgery,
            PodiatricSurgery,
            PreventiveMedicine,
            Psychiatry,
            PublicHealth,
            RadiationOncology,
            Radiology,
            RespiratoryMedicine,
            Rheumatology,
            Stomatology,
            ThoracicSurgery,
            TropicalMedicine,
            Urology,
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
