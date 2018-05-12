using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public class Physician
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string Specialist { get; set; }
        public int RegistrationNo { get; set; }
        public string Experience { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
