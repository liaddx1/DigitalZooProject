using DigitalZooProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalZooProject.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new { CategoryId = 1, Name = "Bird" },
                    new { CategoryId = 2, Name = "Reptiles" },
                    new { CategoryId = 3, Name = "Mammals" }
                );
            modelBuilder.Entity<Animal>().HasData(
                 new { AnimalId = 1, Name = "Canary", Age = 3, PicUri = "Canary.jpg", Description = "Canaries are known for their vibrant colors as well as vocal talent. They are found in colors such as yellow, brown, green, and bright orange. Moreover, male canaries can also sing! Isn’t that amazing? This is one of the best birds for beginners as they are usually not sure if they are ready for a conversation. The canary would indeed be very happy by simply hanging out in a cage and singing for you, making them perfect pets. They do not like to be handled much. So, if you are looking for a pet for your child then canaries are a good option. You can simply observe these wonderful pets close up and listen to them sing.", CategoryId = 1 },

                 new { AnimalId = 2, Name = "Finch", PicUri = "Finch.jpg", Age = 6, Description = "If you want a pet that you do not have to tend to too much, then finches are a great option. They are fast moving and lively as well as fun to watch. They do not prefer climbing so make sure that their cage is big enough for them to fly around in. You should always buy them in pairs or in multiple numbers as finches are very social in nature. If the cage is too small for these finches then it can get really crowded which fights between the birds can erupt. They make for amazing pets for a child’s room as they do not like to be handled. You can easily have them around as perfect companions.", CategoryId = 1 },

                 new { AnimalId = 3, Name = "Anole", PicUri = "Anole.jpg", Age = 5, Description = "This cool lizard boasts a colorful neck pouch and is a great choice for novice reptile pet parents. Anoles can live more than five years and grow up to 8 inches long. They like to chillax in a tropical habitat and love to eat crickets and worms.", CategoryId = 2 },

                 new { AnimalId = 4, Name = "Rabbit", PicUri = "Rabbit.jpg", Age = 2, Description = "There are nearly 50 breeds of rabbits that people like to keep as a pet. Most are social animals that want to keep you company. Rabbits are a suitable option for apartment living since they can be litter-box trained, groom themselves, and are relatively quiet. Many people allow their rabbits to roam free in their homes, which is a good way for them to get exercise. One drawback to keeping rabbits is that they like to chew and dig. You will need to bunny-proof your home by making sure there are no exposed cords and only allowing the rabbit to roam in carpet or rug-free rooms.", CategoryId = 3 },

                 new { AnimalId = 5, Name = "Ferrets", PicUri = "Ferrets.jpg", Age = 4, Description = "Ferrets love to play with humans and each other. To accommodate their playful nature, provide them with a large cage. They make excellent apartment dwellers because they sleep most of the day while the owner is away for the day. They are quiet creatures but also like to hide and get into mischief. You will need to make sure your home is ferret-proofed to prevent escapes or unsafe hiding spots (like in the oven).", CategoryId = 3 },

                 new { AnimalId = 6, Name = "Dog", PicUri = "Dog.jpg", Age = 10, Description = "Let’s be honest, us Brits are dog crazy. And with good reason: dogs are the best! If your kids are constantly waking you up in middle of the night with requests to get a pet dog, a) that’s a bit creepy, and b) we’re not surprised. Now obviously dogs are the highest maintenance pet on the list, but once you know what you’re getting yourself in for, having a pet dog is incredible. Things to consider that will help you minimise how much maintenance a dog is are things like breed and temperament, how much exercise and space they will need and whether it’s the right time for one to join your family. It’s a big commitment, but it’s one that is most definitely worth it.", CategoryId = 3 },

                 new { AnimalId = 7, Name = "Cat", PicUri = "Cat.jpg", Age = 8, Description = "The other top dog when it comes to the nation’s favourite pet has to be the cat! These fluffy little critters are amazing house pets. They’re a fairly big commitment too, but do take less work than dogs. Depending on where you live you can opt to keep your cat indoors, or you can install a cat flap and let them roam to their heart’s content. Ensure your cat is fully vaccinated, microchipped and knows where you live – so if you recently moved or your cat is still young, you should probably keep an eye on them. If not, then a litter tray placed in a safe and quiet place is all you need. Plus food and lots of affection, that is.", CategoryId = 3 }
                );
            modelBuilder.Entity<Comment>().HasData(
                    new { CommentId = 1, AnimalId = 1, Content = "Beutiful bird! Easy to grow indoor and to handle. Would recomment anyone!" },
                    new { CommentId = 2, AnimalId = 1, Content = "Easy and cheap to maintain, good with kids." },
                    new { CommentId = 3, AnimalId = 3, Content = "Why are you so fucking cute?!" },
                    new { CommentId = 4, AnimalId = 2, Content = "Magestice bird! my parents bought her for me for my birthday, I love her!" },
                    new { CommentId = 5, AnimalId = 1, Content = "I would recommend to actually get a second one so the first one wont be bored..." },
                    new { CommentId = 6, AnimalId = 3, Content = "Good for people who want a peacful and quiet creature in the house!" },
                    new { CommentId = 7, AnimalId = 4, Content = "He took a bite of my fingers, so I coocked him off... would not recommend to grow, but to eat! (not raw though)" }
                );
        }
    }
}
