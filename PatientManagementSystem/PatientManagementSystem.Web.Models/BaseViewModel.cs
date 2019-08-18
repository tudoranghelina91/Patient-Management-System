using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Web.Models
{
    public abstract class BaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}