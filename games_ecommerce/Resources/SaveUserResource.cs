using System.ComponentModel.DataAnnotations;

namespace games_ecommerce.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(8)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Documento inválido!.")]
        public string Cpf { get; set; }
    }
}
