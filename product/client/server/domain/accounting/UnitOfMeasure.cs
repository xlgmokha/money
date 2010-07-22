namespace presentation.windows.server.domain.accounting
{
    public interface UnitOfMeasure
    {
        double convert(double amount, UnitOfMeasure other);
        string pretty_print(double amount);
    }

}