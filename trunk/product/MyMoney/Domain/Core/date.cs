using System;
using System.Globalization;
using MoMoney.Utility.Extensions;

namespace MoMoney.Domain.Core
{
    public interface IDate : IComparable<IDate>, IComparable, IEquatable<IDate>
    {
        bool is_in(IYear year);
        DateTime to_date_time();
    }

    [Serializable]
    public class Date : IDate, IEquatable<Date>
    {
        private readonly long ticks;

        public Date(int year, int month, int day)
        {
            ticks = new DateTime(year, month, day).Ticks;
        }

        public bool is_in(IYear the_year)
        {
            return the_year.represents(to_date_time());
        }

        public DateTime to_date_time()
        {
            return new DateTime(ticks);
        }

        public static implicit operator Date(DateTime date)
        {
            return new Date(date.Year, date.Month, date.Day);
        }

        public static implicit operator DateTime(Date date)
        {
            return date.to_date_time();
        }

        public int CompareTo(IDate other)
        {
            var the_other_date = other.downcast_to<Date>();
            if (ticks.Equals(the_other_date.ticks))
            {
                return 0;
            }
            return ticks > the_other_date.ticks ? 1 : -1;
        }

        public bool Equals(Date obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.ticks == ticks;
        }

        public bool Equals(IDate other)
        {
            return other.CompareTo(this) == 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Date)) return false;
            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            return ticks.GetHashCode();
        }

        public override string ToString()
        {
            return new DateTime(ticks, DateTimeKind.Local).ToString("MMM dd yyyy", CultureInfo.InvariantCulture);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj.is_an_implementation_of<IDate>())
                return CompareTo(obj.downcast_to<IDate>());
            throw new InvalidOperationException();
        }
    }
}