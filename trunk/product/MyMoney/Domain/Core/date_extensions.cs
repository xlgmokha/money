using System;

namespace MoMoney.Domain.Core
{
    public static class date_extensions
    {
        public static IDate as_a_date(this DateTime date)
        {
            return (Date) date;
        }

        public static IYear as_a_year(this int year)
        {
            return new year(new DateTime(year, 01, 01));
        }
    }
}