using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMoney.Domain.Core
{
    public class Months
    {
        private static readonly IList<IMonth> all_months = new List<IMonth>();

        public static readonly IMonth January = new month(01, "January");
        public static readonly IMonth February = new month(02, "February");
        public static readonly IMonth March = new month(03, "March");
        public static readonly IMonth April = new month(04, "April");
        public static readonly IMonth May = new month(05, "May");
        public static readonly IMonth June = new month(06, "June");
        public static readonly IMonth July = new month(07, "July");
        public static readonly IMonth August = new month(08, "August");
        public static readonly IMonth September = new month(09, "September");
        public static readonly IMonth October = new month(10, "October");
        public static readonly IMonth November = new month(11, "November");
        public static readonly IMonth December = new month(12, "December");

        public static IMonth that_represents(DateTime the_underlying_date)
        {
            return all_months.Single(x => x.represents(the_underlying_date));
        }

        public static void add(IMonth month)
        {
            all_months.Add(month);
        }

        private class month : IMonth
        {
            private readonly int the_underlying_month;
            private readonly string name_of_the_month;

            internal month(int month, string name_of_the_month)
            {
                the_underlying_month = month;
                this.name_of_the_month = name_of_the_month;
                add(this);
            }

            public bool represents(DateTime date)
            {
                return date.Month.Equals(the_underlying_month);
            }

            public bool Equals(month obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.the_underlying_month == the_underlying_month;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (month)) return false;
                return Equals((month) obj);
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
}