namespace presentation.windows.server.domain.accounting
{
    public class Deposit : TransactionType
    {
        public Quantity adjust(Quantity balance, Quantity adjustment)
        {
            return balance.plus(adjustment);
        }
    }
}