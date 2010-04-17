using System;

namespace presentation.windows.server.domain.payroll
{
    public class Date
    {
        long ticks;

        Date(DateTime date)
        {
            ticks = date.Date.Ticks;
        }

        static public implicit operator Date(DateTime raw)
        {
            return new Date(raw);
        }

        public bool Equals(Date other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ticks == ticks;
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
    }
}