using System.ComponentModel.DataAnnotations;

namespace project.utils.catalogues.dto
{
    public class catalogueCreationDto
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(255)]
        public string description { get; set; }
    }
}
