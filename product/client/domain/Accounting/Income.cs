using System;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    [Serializable]
    public class Income : GenericEntity<Income>
    {
        static public Income New(Date date, Money amount, Company company)
        {
            return new Income
                   {
                       company = company,
                       amount_tendered = amount,
                       date_of_issue = date
                   };
        }

        public virtual Company company { get; private set; }
        public virtual Money amount_tendered { get; private set; }
        public virtual Date date_of_issue { get; private set; }
    }
}