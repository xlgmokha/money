namespace MoMoney.Domain.accounting.billing
{
    public static class BillingExtensions
    {
        public static bool is_not_paid(this IBill bill)
        {
            return !bill.is_paid_for();
        }
    }
}