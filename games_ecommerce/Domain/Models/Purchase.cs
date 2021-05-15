using games_ecommerce.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace games_ecommerce.Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public EPaymentFormat PaymentFormat { get; set; }
        public EPurchaseStatus PurchaseStatus { get; set; }
        public string Observation { get; set; }
        public string PostalCode { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public IList<Product> Products { get; set; }
    }
}
