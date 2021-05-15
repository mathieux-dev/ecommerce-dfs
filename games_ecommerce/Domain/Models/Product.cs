using System.Text.Json.Serialization;

namespace games_ecommerce.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Observation { get; set; }
        public int PublisherId { get; set; }

        [JsonIgnore]
        public Publisher Publisher { get; set; }
        public int PurchaseId { get; set; }

        [JsonIgnore]
        public Purchase Purchase { get; set; }
    }
}
