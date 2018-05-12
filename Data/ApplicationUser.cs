using Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Physician> Physicians { get; set; }
        public virtual ICollection<PatientUser> PatientUsers { get; set; }
    }
}
