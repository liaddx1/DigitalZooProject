using DigitalZooProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalZooProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var twoMostComments = _repository.GetAnimals()
                                                        .OrderByDescending(a => a.Comments.Count)
                                                        .Take(2)
                                                        .ToList();
            return View(twoMostComments);
        }
    }
}
