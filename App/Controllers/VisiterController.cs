using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.AccountViewModels;
using Data;
using Data.MySqlRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class VisiterController : Controller
    {

        private readonly ILogger _logger;
        private readonly IPatientUserRepository _patientUserRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public VisiterController(
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
        public IActionResult lastVistDate()
        {
            return View();
        }
        public IActionResult currentPatientDiseases()
        {
            return View();
        }
        public IActionResult visiterTreatmentHistory()
        {
            return View();
        }
        public IActionResult FindPhysician()
        {
            return View();
        }
        public IActionResult BodyMassIndex()
        {
            return View();
        }
        public IActionResult BloodPressureLevel()
        {
            return View();
        }
        public IActionResult SugerLevel()
        {
            return View();
        }
        public IActionResult ColesterolLevel()
        {
            return View();
        }
        public IActionResult DietPlan()
        {
            return View();
        }
        public IActionResult HealthPrecaution()
        {
            return View();
        }

    }
}