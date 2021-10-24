using System.ComponentModel.DataAnnotations;

namespace DigitalZooProject.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}