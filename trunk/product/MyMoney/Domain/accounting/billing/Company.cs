using System;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Domain.Core;

namespace MyMoney.Domain.accounting.billing
{
    public interface ICompany : IEntity
    {
        void issue_bill_to(IAccountHolder customer, DateTime that_is_due_on, IMoney for_amount);
        string name { get; }
        void pay(IAccountHolder person, IMoney amount, IDate date_of_payment);
    }

    [Serializable]
    internal class Company : Entity<ICompany>, ICompany
    {
        public Company(string name_of_the_company)
        {
            name = name_of_the_company;
        }

        public string name { get; private set; }

        public void issue_bill_to(IAccountHolder customer, DateTime that_is_due_on, IMoney for_amount)
        {
            customer.recieve(new bill(this, for_amount, that_is_due_on));
        }

        public void pay(IAccountHolder person, IMoney amount, IDate date_of_payment)
        {
            person.recieve(new Income(date_of_payment, amount, this));
        }

        public override string ToString()
        {
            return name;
        }
    }
}