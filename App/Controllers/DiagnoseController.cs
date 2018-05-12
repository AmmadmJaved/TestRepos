using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class DiagnoseController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Your visiter patient here's.";
            return View();
        }

        public IActionResult Laboratorytests()
        {
            ViewData["Message"] = "Many infectious diseases have similar signs and symptoms. Samples of your body fluids can sometimes reveal evidence of the particular microbe that's causing your illness. This helps your doctor tailor your treatment.";
            return View();
        }
        public IActionResult Bloodtests()
        {
            ViewData["Message"] = "A technician obtains a sample of your blood by inserting a needle into a vein, usually in your arm.";
            return View();
        }
        public IActionResult Urinetests()
        {
            ViewData["Message"] = "This painless test requires you to urinate into a container. To avoid potential contamination of the sample, you may be instructed to cleanse your genital area with an antiseptic pad and to collect the urine midstream.";
            return View();
        }
        public IActionResult Throatswabs()
        {
            ViewData["Message"] = "Samples from your throat, or other moist areas of your body, may be obtained with a sterile swab.";
            return View();

        }
        public IActionResult Stoolsample()
        {
            ViewData["Message"] = "You may be instructed to collect a stool sample so a lab can check the sample for parasites and other organisms.";
            return View();
        }
        public IActionResult Spinaltap_lumbarPuncture()
        {
            ViewData["Message"] = "This procedure obtains a sample of your cerebrospinal fluid through a needle carefully inserted between the bones of your lower spine. You'll usually be asked to lie on your side with your knees pulled up toward your chest.";
            return View();
        }   
        public IActionResult ImagingScans()
        {
            ViewData["Message"] = "Imaging procedures — such as X-rays, computerized tomography and magnetic resonance imaging — can help pinpoint diagnoses and rule out other conditions that may be causing your symptoms.";
            return View();
        }
        public IActionResult Biopsies()
        {
            ViewData["Message"] = "During a biopsy, a tiny sample of tissue is taken from an internal organ for testing. For example, a biopsy of lung tissue can be checked for a variety of fungi that can cause a type of pneumonia.";
            return View();
        }
        
    }
}