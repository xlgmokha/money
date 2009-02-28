using System;

namespace MyMoney.Domain.Core
{
    public interface IDay
    {}

    internal class day : IDay
    {
        private readonly DateTime the_underlying_date;
        private readonly int the_day;

        public day(DateTime the_underlying_date)
        {
            this.the_underlying_date = the_underlying_date;
            the_day = the_underlying_date.Day;
        }

        public bool Equals(day obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.the_day == the_day;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (day)) return false;
            return Equals((day) obj);
        }

        public override int GetHashCode()
        {
            return the_day;
        }

        public override string ToString()
        {
            return the_underlying_date.DayOfWeek.ToString();
        }
    }
}