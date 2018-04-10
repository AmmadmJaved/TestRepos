using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; }
    }
}
