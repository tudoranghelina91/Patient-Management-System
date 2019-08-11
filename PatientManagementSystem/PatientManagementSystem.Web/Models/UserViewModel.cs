using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public abstract class UserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string IdentityId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int[] SSN { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
        [Required]
        public int ApartmentNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}