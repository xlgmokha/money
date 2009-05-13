using System;
using Gorilla.Commons.Utility;
using MoMoney.Domain.accounting;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    public interface ICompany : IEntity
    {
        string name { get; }
        void change_name_to(string company_name);
        void issue_bill_to(IAccountHolder customer, DateTime that_is_due_on, Money for_amount);
        void pay(IAccountHolder person, Money amount, Date date_of_payment);
    }

    [Serializable]
    public class Company : Entity<ICompany>, ICompany
    {
        public string name { get; private set; }

        public void change_name_to(string company_name)
        {
            name = company_name;
        }

        public void issue_bill_to(IAccountHolder customer, DateTime that_is_due_on, Money for_amount)
        {
            customer.receive(new Bill(this, for_amount, that_is_due_on));
        }

        public void pay(IAccountHolder person, Money amount, Date date_of_payment)
        {
            person.receive(new Income(date_of_payment, amount, this));
        }

        public override string ToString()
        {
            return name;
        }
    }
}