using games_ecommerce.Domain.Helpers;
using games_ecommerce.Domain.Models;
using System;
using System.Collections.Generic;

namespace games_ecommerce.Resources
{
    public class PurchaseResource
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public EPaymentFormat PaymentFormat { get; set; }
        public EPurchaseStatus PurchaseStatus { get; set; }
        public string Observation { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public IList<Product> Products { get; set; }
    }
}
