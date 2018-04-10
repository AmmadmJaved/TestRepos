using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.MySqlRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            var result = new { apple = 1, banan = 2 };
            Category category = new Category();
            category.CategoryName = "Fruit/Vegitable";
            category.Description = "juice in all weather's";
            category.Fruits = new List<Fruit>();

            category.Fruits.Add(new Fruit { FruitName = "Apple", Description = "juice in all weather's", Price = 55.00 });
            category.Vegetables = new List<Vegetable>();
            category.Vegetables.Add(new Vegetable{ vegetableName = "onion", Description = "dry in all weather's" , Price = 30.00 });

            _categoryRepository.AddAsync(category);
           var res = _categoryRepository.Get();
            return new ObjectResult(res);
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
