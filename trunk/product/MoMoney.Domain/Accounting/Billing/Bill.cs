using System;
using System.Collections.Generic;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting.billing
{
    public interface IBill : IEntity
    {
        bool is_paid_for();
        void pay(IMoney amount_to_pay);
        ICompany company_to_pay { get; }
        IMoney the_amount_owed { get; }
        IDate due_date { get; }
    }

    [Serializable]
    public class Bill : Entity<IBill>, IBill
    {
        public Bill(ICompany company_to_pay, IMoney the_amount_owed, DateTime due_date)
        {
            this.company_to_pay = company_to_pay;
            this.the_amount_owed = the_amount_owed;
            this.due_date = due_date.as_a_date();
            payments = new List<IPayment>();
        }

        public ICompany company_to_pay { get; private set; }
        public IMoney the_amount_owed { get; private set; }
        public IDate due_date { get; private set; }
        public IList<IPayment> payments { get; private set; }

        public bool is_paid_for()
        {
            return the_amount_paid().Equals(the_amount_owed);
        }

        public void pay(IMoney amount_to_pay)
        {
            payments.Add(new Payment(amount_to_pay));
        }

        private IMoney the_amount_paid()
        {
            return payments.return_value_from_visiting_all_items_with(new total_payments_calculator());
        }

        public bool Equals(Bill obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.company_to_pay, company_to_pay) && Equals(obj.the_amount_owed, the_amount_owed) &&
                   obj.due_date.Equals(due_date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Bill)) return false;
            return Equals((Bill) obj);
        }

        public override int GetHashCode()
        {
            unchecked {
                var result = (company_to_pay != null ? company_to_pay.GetHashCode() : 0);
                result = (result*397) ^ (the_amount_owed != null ? the_amount_owed.GetHashCode() : 0);
                result = (result*397) ^ due_date.GetHashCode();
                return result;
            }
        }
    }
}