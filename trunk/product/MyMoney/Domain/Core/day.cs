using System;

namespace MoMoney.Domain.Core
{
    public interface IDay
    {
    }

    [Serializable]
    internal class Day : IDay
    {
        readonly DateTime the_underlying_date;
        readonly int the_day;

        public Day(DateTime the_underlying_date)
        {
            this.the_underlying_date = the_underlying_date;
            the_day = the_underlying_date.Day;
        }

        public bool Equals(Day obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.the_day == the_day;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Day)) return false;
            return Equals((Day) obj);
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