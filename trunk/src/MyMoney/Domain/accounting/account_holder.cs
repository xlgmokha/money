using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Domain.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Domain.accounting
{
    public interface IAccountHolder : IEntity
    {
        void recieve(IBill bill);
        void recieve(IIncome income);
        IEnumerable<IBill> collect_all_the_unpaid_bills();
        IMoney calculate_income_for(IYear year);
    }

    internal class account_holder : entity<IAccountHolder>, IAccountHolder
    {
        public account_holder()
        {
            all_bills = new List<IBill>();
            income_collected = new List<IIncome>();
        }

        private IList<IBill> all_bills { get; set; }
        private IList<IIncome> income_collected { get; set; }

        public void recieve(IBill bill)
        {
            all_bills.Add(bill);
        }

        public IEnumerable<IBill> collect_all_the_unpaid_bills()
        {
            return all_bills.where(bill => bill.is_not_paid());
        }

        public IMoney calculate_income_for(IYear year)
        {
            return income_collected.in_the(year);
        }

        public void recieve(IIncome income)
        {
            income_collected.Add(income);
        }
    }
}