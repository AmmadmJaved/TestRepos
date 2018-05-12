using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.AccountViewModels
{
    public class PhysicianViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }
        [Required]
        [Display(Name = "Specialist")]
        public string Specialist { get; set; }
        [Required]
        [Display(Name = "RegistrationNo")]
        public int RegistrationNo { get; set; }
        [Required]
        [Display(Name = "Experience")]
        public string Experience { get; set; }
        [Required]
        [Display(Name = "CNIC")]
        public string CNIC { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}
