using System;

namespace presentation.windows.server.domain.payroll
{
    public interface Fraction
    {
        void each(Action<int> action);
        int of(int number);
    }
}