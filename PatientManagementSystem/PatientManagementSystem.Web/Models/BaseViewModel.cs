using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientManagementSystem.Web.Models
{
    public abstract class BaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}