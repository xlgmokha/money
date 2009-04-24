using System;
using Gorilla.Commons.Utility;

namespace MoMoney.Domain.Core
{
    public static class DateExtensions
    {
        public static IYear as_a_year(this int year)
        {
            return new Year(new DateTime(year, 01, 01));
        }
    }
}