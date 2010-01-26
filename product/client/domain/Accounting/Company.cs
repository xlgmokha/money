using System;
using Gorilla.Commons.Utility;
using MoMoney.Domain.accounting;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    [Serializable]
    public class Company : GenericEntity<Company>
    {
        public string name { get; private set; }

        public void change_name_to(string company_name)
        {
            name = company_name;
        }

        public void issue_bill_to(AccountHolder customer, DateTime that_is_due_on, Money for_amount)
        {
            customer.receive( Bill.New(this, for_amount, that_is_due_on));
        }

        public void pay(AccountHolder person, Money amount, Date date_of_payment)
        {
            person.receive( Income.New(date_of_payment, amount, this));
        }

        public override string ToString()
        {
            return name;
        }
    }
}