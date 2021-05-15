using System.ComponentModel;

namespace games_ecommerce.Domain.Helpers
{
    public enum EPurchaseStatus : long
    {
        [Description("PAID")]
        Paid = 1,

        [Description("OPEN")]
        Open = 2
    }
}
