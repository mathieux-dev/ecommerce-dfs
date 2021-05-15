using System.ComponentModel.DataAnnotations;

namespace games_ecommerce.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(140)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [MaxLength(300)]
        public string Observation { get; set; }

        [Required]
        public int PublisherId { get; set; }
    }
}
