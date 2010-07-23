using Gorilla.Commons.Utility;

namespace presentation.windows.server.domain.payroll
{
    public interface Frequency
    {
        Date next(Date from_date);
    }
}