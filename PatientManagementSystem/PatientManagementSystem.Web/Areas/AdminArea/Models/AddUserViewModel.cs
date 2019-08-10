using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PatientManagementSystem.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
//using PatientManagementSystem.Web.Models;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace PatientManagementSystem.Web.Areas.AdminArea.Models
{
    public class AddUserViewModel
    {   
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "User Role")]
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Selected Role")]
        public string Role { get; set; }
    }
}