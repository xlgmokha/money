namespace presentation.windows.server.domain.accounting
{
    public class Withdrawal : TransactionType
    {
        public Quantity adjust(Quantity balance, Quantity adjustment)
        {
            return balance.subtract(adjustment);
        }
    }
}