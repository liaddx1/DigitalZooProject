using DigitalZooProject.Models;
using DigitalZooProject.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DigitalZooProject.Tests
{
    [TestClass]
    public class FakeRepository : IRepository
    {
        private IEnumerable<Category> _categories;
        private IEnumerable<Animal> _animals;
        private IEnumerable<Comment> _comments;

        public FakeRepository()
        {
            _categories = new List<Category>() { new Category(), new Category(), new Category() };
            _animals = new List<Animal>() { new Animal(), new Animal(), new Animal() };
            _comments = new List<Comment>() { new Comment(), new Comment(), new Comment() };
            foreach (var animal in _animals)
                if (animal.Comments is null) animal.Comments = new List<Comment>();
        }
        public IEnumerable<Category> GetCategories() => _categories;
        public IEnumerable<Animal> GetAnimals() => _animals;
        public IEnumerable<Comment> GetComments() => _comments;

        public void DeleteAnimal(int id)
        {
            var comment = _comments.SingleOrDefault(c => c.CommentId == id);
            comment = null;
        }

        public void DeleteComment(int id)
        {
            var comment = _comments.SingleOrDefault(c => c.CommentId == id);
            comment = null;
        }

        public void InsertAnimal(Animal animal)
        {
            _animals.Append(animal);
        }

        public void InsertComment(Comment comment)
        {
            _comments.Append(comment);
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            if (id > 0 && animal != null)
            {
                var getAnimal = _animals.SingleOrDefault(a => a.AnimalId == id);
                getAnimal.Age = animal.Age;
                getAnimal.Name = animal.Name;
                getAnimal.Description = animal.Description;
                getAnimal.CategoryId = animal.CategoryId;
            }
        }

        public void UpdateComment(int id, Comment comment)
        {
            var commentInDb = _comments.SingleOrDefault(c => c.CommentId == id);
            commentInDb.Content = comment.Content;
        }
    }
}
