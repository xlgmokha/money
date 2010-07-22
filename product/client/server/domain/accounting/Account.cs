using Gorilla.Commons.Utility;

namespace presentation.windows.server.domain.accounting
{
    public interface Account
    {
        Quantity balance();
        Quantity balance(Date date);
        Quantity balance(Range<Date> period);
    }
}