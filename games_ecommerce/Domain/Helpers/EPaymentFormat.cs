using System.ComponentModel;

namespace games_ecommerce.Domain.Helpers
{
    public enum EPaymentFormat : long
    {
        [Description("CC")]
        CreditCard = 1,

        [Description("DC")]
        DebitCard = 2,

        [Description("PP")]
        PayPal = 3,

        [Description("PS")]
        PaymentSlip = 4
    }
}
