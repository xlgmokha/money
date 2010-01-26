using System;
using System.Collections.Generic;
using System.Linq;

namespace MoMoney.Domain.Core
{
    public static class Months
    {
        static readonly IList<IMonth> all_months = new List<IMonth>();

        public static readonly IMonth January = new Month(01, "January");
        public static readonly IMonth February = new Month(02, "February");
        public static readonly IMonth March = new Month(03, "March");
        public static readonly IMonth April = new Month(04, "April");
        public static readonly IMonth May = new Month(05, "May");
        public static readonly IMonth June = new Month(06, "June");
        public static readonly IMonth July = new Month(07, "July");
        public static readonly IMonth August = new Month(08, "August");
        public static readonly IMonth September = new Month(09, "September");
        public static readonly IMonth October = new Month(10, "October");
        public static readonly IMonth November = new Month(11, "November");
        public static readonly IMonth December = new Month(12, "December");

        public static IMonth that_represents(DateTime the_underlying_date)
        {
            return all_months.Single(x => x.represents(the_underlying_date));
        }

        public static void add(IMonth month)
        {
            all_months.Add(month);
        }
    }
}