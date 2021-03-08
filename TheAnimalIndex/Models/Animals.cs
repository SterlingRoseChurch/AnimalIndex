using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TheAnimalIndex.Models
{
    public class Animals
    {
        [Key]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Please enter a Species.")]
        public string Species { get; set; }

        [Required(ErrorMessage = "Please select a Type.")]
        public string TypeId { get; set; }
        public Type Type { get; set; }

        public string Slug =>
           Species?.Replace(' ', '-').ToLower() + '-' + AnimalId.ToString();

    }
}
