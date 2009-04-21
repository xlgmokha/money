using System;

namespace Gorilla.Commons.Utility
{
    public interface IYear
    {
        bool represents(DateTime time);
    }

    public class Year : IYear
    {
        private readonly int the_underlying_year;

        public Year(DateTime date)
        {
            the_underlying_year = date.Year;
        }

        public bool Equals(Year obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.the_underlying_year == the_underlying_year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Year)) return false;
            return Equals((Year) obj);
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