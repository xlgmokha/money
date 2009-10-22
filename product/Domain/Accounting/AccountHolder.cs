using System;
using System.Collections.Generic;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting
{
    public interface IAccountHolder : IEntity
    {
        void receive(IBill bill);
        void receive(IIncome income);
        IEnumerable<IBill> collect_all_the_unpaid_bills();
        Money calculate_income_for(Year year);
    }

    [Serializable]
    public class AccountHolder : Entity<IAccountHolder>, IAccountHolder
    {
        IList<IBill> all_bills { get; set; }
        IList<IIncome> income_collected { get; set; }

        public AccountHolder()
        {
            all_bills = new List<IBill>();
            income_collected = new List<IIncome>();
        }

        public void receive(IBill bill)
        {
            all_bills.Add(bill);
        }

        public IEnumerable<IBill> collect_all_the_unpaid_bills()
        {
            return all_bills.where(bill => bill.is_not_paid());
        }

        public Money calculate_income_for(Year year)
        {
            return income_collected.in_the(year);
        }

        public void receive(IIncome income)
        {
            income_collected.Add(income);
        }
    }
}