namespace presentation.windows.server.domain.accounting
{
    public interface TransactionType
    {
        Quantity adjust(Quantity balance, Quantity adjustment);
    }
}