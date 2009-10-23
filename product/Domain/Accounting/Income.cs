using System;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    public interface IIncome : Entity
    {
        Date date_of_issue { get; }
        Money amount_tendered { get; }
        ICompany company { get; }
    }

    [Serializable]
    internal class Income : GenericEntity<IIncome>, IIncome
    {
        public Income(Date date_of_issue, Money amount_tendered, ICompany company)
        {
            this.company = company;
            this.amount_tendered = amount_tendered;
            this.date_of_issue = date_of_issue;
        }

        public ICompany company { get; private set; }
        public Money amount_tendered { get; private set; }
        public Date date_of_issue { get; private set; }

        public bool Equals(Income obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.company, company) && Equals(obj.amount_tendered, amount_tendered) &&
                   Equals(obj.date_of_issue, date_of_issue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Income)) return false;
            return Equals((Income) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = (company != null ? company.GetHashCode() : 0);
                result = (result*397) ^ (amount_tendered != null ? amount_tendered.GetHashCode() : 0);
                result = (result*397) ^ (date_of_issue != null ? date_of_issue.GetHashCode() : 0);
                return result;
            }
        }
    }
}