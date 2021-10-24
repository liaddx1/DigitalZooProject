using DigitalZooProject.Data;
using DigitalZooProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DigitalZooProject.Repositories
{
    public class MyRepository : IRepository
    {
        private readonly ZooContext _context;
        private readonly IEnumerable<Animal> _animals;
        private readonly IEnumerable<Comment> _comments;
        private readonly IEnumerable<Category> _categories;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MyRepository(ZooContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _comments = _context.Comments.ToList();
            _animals = _context.Animals.ToList();
            _categories = _context.Categories.ToList();
            foreach (var animal in _animals)
                if (animal.Comments is null) animal.Comments = new List<Comment>();
            _hostEnvironment = hostEnvironment;
            Debug.WriteLine("Repository loading!");
        }
        public IEnumerable<Comment> GetComments() => _comments;
        public IEnumerable<Animal> GetAnimals() => _animals;
        public IEnumerable<Category> GetCategories() => _categories;

        public void InsertComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(int id, Comment comment)
        {
            var commentInDb = _context.Comments.SingleOrDefault(c => c.CommentId == id);
            commentInDb.Content = comment.Content;
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.CommentId == id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals.SingleOrDefault(a => a.AnimalId == id);

            string rootFolderPath = _hostEnvironment.WebRootPath;

            var filePath = $"{rootFolderPath}\\Pictures\\{animal.PicUri}";

            _context.Animals.Remove(animal);

            File.Delete(filePath);

            _context.SaveChanges();
        }

        public void InsertAnimal(Animal animal)
        {
            string rootFolderPath = _hostEnvironment.WebRootPath;
            if (animal.Picture.Length > 0)
            {
                var filePath = Path.Combine(rootFolderPath, "Pictures", animal.Picture.FileName);

                using var stream = File.Create(filePath);
                animal.Picture.CopyTo(stream);
            }
            animal.PicUri = animal.Picture.FileName;
            _context.Animals.Add(animal);
            _animals.Append(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            if (id > 0 && animal != null)
            {
                var getAnimal = _context.Animals.SingleOrDefault(a => a.AnimalId == id);
                getAnimal.Age = animal.Age;
                getAnimal.Name = animal.Name;
                getAnimal.Description = animal.Description;
                getAnimal.CategoryId = animal.CategoryId;

                _context.SaveChanges();
            }
        }
    }
}
