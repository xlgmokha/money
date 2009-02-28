namespace MyMoney.Domain.accounting.billing
{
    public static class billing_extensions
    {
        public static bool is_not_paid(this IBill bill)
        {
            return !bill.is_paid_for();
        }
    }
}