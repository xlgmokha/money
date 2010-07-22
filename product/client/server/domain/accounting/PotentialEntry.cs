namespace presentation.windows.server.domain.accounting
{
    public interface PotentialEntry
    {
        Quantity combined_with(Quantity other);
        void commit();
    }
}