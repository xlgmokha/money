using System;
using System.Collections.Generic;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting
{
    [Serializable]
    public class AccountHolder : GenericEntity<AccountHolder>
    {
        IList<Bill> all_bills = new List<Bill>();
        IList<Income> income_collected = new List<Income>();

        public void receive(Bill bill)
        {
            all_bills.Add(bill);
        }

        public IEnumerable<Bill> collect_all_the_unpaid_bills()
        {
            return all_bills.where(bill => bill.is_not_paid());
        }

        public Money calculate_income_for(Year year)
        {
            return income_collected.in_the(year);
        }

        public void receive(Income income)
        {
            income_collected.Add(income);
        }
    }
}