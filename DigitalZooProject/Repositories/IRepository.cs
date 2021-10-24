using DigitalZooProject.Models;
using System.Collections.Generic;

namespace DigitalZooProject.Repositories
{
    public interface IRepository
    {
        IEnumerable<Comment> GetComments();
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Category> GetCategories();
        void InsertComment(Comment comment);
        void UpdateComment(int id, Comment comment);
        void DeleteComment(int id);
        void InsertAnimal(Animal animal);
        void DeleteAnimal(int id);
        void UpdateAnimal(int id, Animal animal);
    }
}
