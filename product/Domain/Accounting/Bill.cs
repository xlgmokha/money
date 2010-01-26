using System;
using System.Collections.Generic;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.Accounting
{
    [Serializable]
    public class Bill : GenericEntity<Bill>
    {
        IList<Payment> payments = new List<Payment>();

        static public Bill New(Company company, Money for_amount, DateTime that_is_due_on)
        {
            return new Bill
                   {
                       company_to_pay = company,
                       the_amount_owed = for_amount,
                       due_date = that_is_due_on
                   };
        }

        public virtual Company company_to_pay { get; private set; }
        public virtual Money the_amount_owed { get; private set; }
        public virtual Date due_date { get; private set; }

        public virtual bool is_paid_for()
        {
            return the_amount_paid().Equals(the_amount_owed);
        }

        public virtual void pay(Money amount_to_pay)
        {
            payments.Add(Payment.New(amount_to_pay));
        }

        Money the_amount_paid()
        {
            return payments.return_value_from_visiting_all_with(new TotalPaymentsCalculator());
        }
    }
}