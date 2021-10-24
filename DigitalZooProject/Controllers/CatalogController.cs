using DigitalZooProject.Models;
using DigitalZooProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalZooProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository _repository;
        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string category = "")
        {
            ViewBag.Categories = _repository.GetCategories();

            if (category != "")
            {
                if (category == "All")
                {
                    category = "";
                    return RedirectToAction("Index", "Catalog");
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

        public IActionResult AnimalPage(int id, string message = "")
        {
            var specificAnimal = _repository.GetAnimals()
                                                        .ElementAt(id - 1);

            ViewBag.Message = message;
            return View(specificAnimal);
        }

        [HttpPost]
        public IActionResult AddComment(string content, int animalId)
        {
            var message = "";

            if (!(string.IsNullOrWhiteSpace(content) || string.IsNullOrEmpty(content) || (content.Length < 2)))
            {
                var newComment = content;
                _repository.InsertComment(new Comment { Content = newComment, AnimalId = animalId });
            }
            else
            {
                message = "* Must Be 2 Or More Characters!";
            }

            return RedirectToAction($"AnimalPage", new { id = animalId, message });
        }
    }
}