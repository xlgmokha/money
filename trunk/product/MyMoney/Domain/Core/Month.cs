using System;

namespace MoMoney.Domain.Core
{
    public interface IMonth
    {
        bool represents(DateTime date);
    }

    [Serializable]
    internal class Month : IMonth
    {
        readonly int the_underlying_month;
        readonly string name_of_the_month;

        internal Month(int month, string name_of_the_month)
        {
            the_underlying_month = month;
            this.name_of_the_month = name_of_the_month;
            Months.add(this);
        }

        public bool represents(DateTime date)
        {
            return date.Month.Equals(the_underlying_month);
        }

        public bool Equals(Month obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.the_underlying_month == the_underlying_month;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Month)) return false;
            return Equals((Month) obj);
        }

        public override int GetHashCode()
        {
            return the_underlying_month;
        }

        public override string ToString()
        {
            return name_of_the_month;
        }
    }
}