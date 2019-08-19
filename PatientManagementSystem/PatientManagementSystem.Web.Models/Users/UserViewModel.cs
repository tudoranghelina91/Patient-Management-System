using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public abstract class UserViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Identity ID")]
        public string IdentityId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        public string SSN { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [Required]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
    }
}