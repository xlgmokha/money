using System;
using System.Collections.Generic;
using gorilla.commons.utility;

namespace presentation.windows.server.domain.payroll
{
    public class BaseDenominator : Denominator
    {
        readonly int denominator;

        protected BaseDenominator(int denominator)
        {
            this.denominator = denominator;
        }

        public IEnumerable<int> each_possible_value()
        {
            for (var i = 0; i < denominator; i++) yield return i;
        }

        public void each(Action<int> action)
        {
            each_possible_value().each(x => action(x));
        }
    }
}