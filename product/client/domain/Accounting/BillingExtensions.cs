namespace MoMoney.Domain.Accounting
{
    public static class BillingExtensions
    {
        public static bool is_not_paid(this Bill bill)
        {
            return !bill.is_paid_for();
        }
    }
}