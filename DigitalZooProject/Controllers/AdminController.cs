using DigitalZooProject.Models;
using DigitalZooProject.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalZooProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IRepository _repository;
        public AdminController(IRepository repository, IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(string category = "")
        {
            ViewBag.Categories = _repository.GetCategories();

            if (category != "")
            {
                if (category == "All")
                {
                    category = "";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    var specificCategory = _repository.GetAnimals()
                                                           .Where(a => a.Category.Name == category)
                                                           .ToList();
                    category = "";
                    return View(specificCategory);
                }
            }
            var allAnimals = _repository.GetAnimals();
            return View(allAnimals);
        }

        public IActionResult NewAnimal(int id = -1)
        {
            ViewBag.Categories = _repository.GetCategories();

            if (id > 0)
            {
                var animal = _repository.GetAnimals()
                                                .ElementAt(id - 1);
                return View("Edit", animal);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddNewAnimal(Animal animal)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid && animal.Picture != null)
            {
                _repository.InsertAnimal(animal);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _repository.GetCategories();
                ViewBag.Message = "The Following Areas Are Invalid:";
                return View("NewAnimal");
            }
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit(int id, Animal animal)
        {
            ViewBag.Categories = _repository.GetCategories();

            _repository.UpdateAnimal(id, animal);

            return RedirectToAction("Index", "Admin");
        }
    }
}
