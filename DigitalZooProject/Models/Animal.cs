using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalZooProject.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "*Name Cannot Be Empty!")]
        [MinLength(3, ErrorMessage = "*Must Contain 3 Or More Chars!")]
        [RegularExpression("(^[a-z A-Z]*$)", ErrorMessage = "*Name Must Contain Letters Only!")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "*Age Cannot Be Empty!")]
        [Range(0, 250, ErrorMessage = "*Age Value Must Be Between 0-250!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "*Picture Cannot Be Empty!")]
        [NotMapped]
        public IFormFile Picture { get; set; }

        public string PicUri { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "*Description Cannot Be Empty!")]
        [MinLength(3, ErrorMessage = "*Description Must Contain 3 Or More Chars!")]
        [MaxLength(2999, ErrorMessage = "*Description Cannot Contain More Than 2999 Chars!")]
        [StringLength(2999)]
        public string Description { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Required(ErrorMessage = "*Category Cannot Be Empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
