using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public abstract class UserViewModel : BaseViewModel
    {
        [Required]
        public string IdentityId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
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
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
    }
}