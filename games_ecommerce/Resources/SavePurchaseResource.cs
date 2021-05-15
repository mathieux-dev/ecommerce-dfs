using games_ecommerce.Domain.Helpers;
using games_ecommerce.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace games_ecommerce.Resources
{
    public class SavePurchaseResource
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public EPaymentFormat PaymentFormat { get; set; }

        [Required]
        public EPurchaseStatus PurchaseStatus { get; set; }

        [MaxLength(300)]
        public string Observation { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "CEP inválido!")]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }

        public int UserId { get; set; }

        public IList<Product> Products { get; set; }
    }
}
