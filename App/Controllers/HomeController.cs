using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.Extensions.Logging;
using Data.MySqlRepositories;
using Microsoft.AspNetCore.Identity;
using Data;
using App.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPatientUserRepository _patientUserRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger,
            IPatientUserRepository patientUserRepository,
            IPhysicianRepository physicianRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _physicianRepository = physicianRepository;
            _patientUserRepository = patientUserRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisiterDashboard()
        {
 
            var patientUserDetail = _patientUserRepository.GetAll();
            List<PatientUserViewModel> PatientUserList = new List<PatientUserViewModel>();
            PatientUserViewModel patientUser;
            foreach (var visiter in patientUserDetail)
            {
                patientUser = new PatientUserViewModel { Name = visiter.Name, Age = visiter.Age, Gender = visiter.Gender, City = visiter.City, CNIC = visiter.CNIC, Country = visiter.Country, Email = visiter.Email, Phone = visiter.Phone };
                PatientUserList.Add(patientUser);
            }

            ViewData["Message"] = "Your visiter patient here's.";
            return View(PatientUserList);
            
        }
        public IActionResult PhysicianDashboard()
        {
            
            var physicianUserDetail = _physicianRepository.GetAll();
            List<PhysicianViewModel> physicianList = new List<PhysicianViewModel>();
            PhysicianViewModel physicianUser;
            foreach (var physician in physicianUserDetail)
            {
                physicianUser = new PhysicianViewModel { Name = physician.Name, Qualification = physician.Qualification,Specialist= physician.Specialist, RegistrationNo= physician.RegistrationNo, Experience = physician.Experience, City = physician.City, CNIC = physician.CNIC, Country = physician.Country, Email = physician.Email, Phone = physician.Phone };
                physicianList.Add(physicianUser);
            }

            ViewData["Message"] = "Your Physician Here's.";
            return View(physicianList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
