using System;

namespace MyMoney.Domain.Core
{
    public interface IYear
    {
        bool represents(DateTime time);
    }

    internal class year : IYear
    {
        private readonly int the_underlying_year;

        public year(DateTime date)
        {
            the_underlying_year = date.Year;
        }

        public bool Equals(year obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.the_underlying_year == the_underlying_year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (year)) return false;
            return Equals((year) obj);
        }

        public override int GetHashCode()
        {
            return the_underlying_year;
        }

        public bool represents(DateTime time)
        {
            return time.Year.Equals(the_underlying_year);
        }

        public override string ToString()
        {
            return the_underlying_year.ToString();
        }
    }
}