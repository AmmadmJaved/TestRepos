using System;
using System.Threading.Tasks;
using App.Models.AccountViewModels;
using Data;
using Data.Model;
using Data.MySqlRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace App.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ILogger _logger;
        private readonly IPatientUserRepository _patientUserRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public ProfileController(
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
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PatientVisiterProfile(string returnUrl = null)
        {
            var currentUser = _userManager.GetUserAsync(HttpContext.User).Result;
            var patientUserDetail = _patientUserRepository.GetByEmail(currentUser.Email);
            PatientUserViewModel patientUser = new PatientUserViewModel { Name = patientUserDetail.Name, Age = patientUserDetail.Age, Gender = patientUserDetail.Gender, City = patientUserDetail.City, CNIC = patientUserDetail.CNIC, Country = patientUserDetail.Country, Email = patientUserDetail.Email, Phone = patientUserDetail.Phone };
            ViewData["ReturnUrl"] = returnUrl;
            return View(patientUser);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientVisiterProfile(PatientUserViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                PatientUser patientUser = new PatientUser { Name = model.Name, Age = model.Age,Gender=model.Gender, City = model.City, CNIC = model.CNIC, Country = model.Country, Email = model.Email, Phone = model.Phone };

                var currentUser = _userManager.GetUserAsync(HttpContext.User).Result;
                var patientUserDetail = _patientUserRepository.GetByEmail(currentUser.Email);
                patientUserDetail.Age = model.Age;
                patientUserDetail.City = model.City;
                patientUserDetail.CNIC = model.CNIC;
                patientUserDetail.Country = model.Country;
                patientUserDetail.Email = model.Email;
                patientUserDetail.Gender = model.Gender;
                patientUserDetail.Name = model.Name;
                patientUserDetail.Phone = model.Phone;
                var add = _patientUserRepository.UpdateAsync(patientUserDetail);
                    _logger.LogInformation("your profile created with a new information .");
                return RedirectToAction(nameof(VisiterProfile));

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult VisiterProfile( )
        {
            string currentUserId = User.Identity.Name;
            var curUser = _userManager.GetUserAsync(HttpContext.User).Result;
            var patientUses = _patientUserRepository.GetAll();
            var patientUserDetail = _patientUserRepository.GetByEmail(curUser.Email);
            PatientUserViewModel patientUser = new PatientUserViewModel { Name = patientUserDetail.Name, Age = patientUserDetail.Age, Gender = patientUserDetail.Gender, City = patientUserDetail.City, CNIC = patientUserDetail.CNIC, Country = patientUserDetail.Country, Email = patientUserDetail.Email, Phone = patientUserDetail.Phone };
            return View(patientUser);
        }
    }
}