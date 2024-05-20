using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nuevo.modules.foods
{
    public class foodDto
    {
        public int Id { get; set; }  // Genera un ID único por defecto

        [Required]
        public string Name { get; set; }

        [Required]
        public string CookTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool Favorite { get; set; } = false;

        [Required]
        public List<string> Origins { get; set; } = new List<string>();

        [Required]
        [Range(0, 5)]
        public double Stars { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
    }
}