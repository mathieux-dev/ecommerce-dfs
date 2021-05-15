using games_ecommerce.Domain.Models;

namespace games_ecommerce.Domain.Services.Communication
{
    public class PurchaseResponse : BaseResponse
    {
        public Purchase Purchase { get; private set; }

        public PurchaseResponse(string message, bool success, Purchase purchase) : base(message, success)
        {
            Purchase = purchase;
        }
        public PurchaseResponse(Purchase purchase) : this(string.Empty, true, purchase)
        {

        }
        public PurchaseResponse(string message) : this(message, false, null)
        {

        }
    }
}
