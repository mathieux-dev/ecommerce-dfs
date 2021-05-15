using System.Collections.Generic;

namespace games_ecommerce.Domain.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string PublicName { get; set; }
        public string CorporativeName { get; set; }
        public string Cnpj { get; set; }
        public IList<Product> Products { get; set; }
    }
}
