using System.ComponentModel.DataAnnotations;

namespace games_ecommerce.Resources
{
    public class SavePublisherResource
    {
        [Required]
        [MaxLength(50)]
        public string PublicName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CorporativeName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "Documento inválido")]
        public string Cnpj { get; set; }
    }
}
