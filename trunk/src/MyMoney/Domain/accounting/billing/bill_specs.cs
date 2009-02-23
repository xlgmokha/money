using System;
using MyMoney.Domain.Core;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Domain.accounting.billing
{
    public class bill_specs
    {}

    [Concern(typeof (bill))]
    public class when_checking_to_see_if_a_new_bill_has_been_paid_for : old_context_specification<IBill>
    {
        [Observation]
        public void it_should_return_false()
        {
            result.should_be_equal_to(false);
        }

        protected override IBill context()
        {
            var amount_owed = new money(100);
            var enmax = an<ICompany>();

            return new bill(enmax, amount_owed, DateTime.Now);
        }

        protected override void because()
        {
            result = sut.is_paid_for();
        }

        private bool result;
    }

    [Concern(typeof (bill))]
    public class when_checking_if_a_paid_bill_has_been_paid_for : old_context_specification<IBill>
    {
        [Observation]
        public void it_should_return_true()
        {
            result.should_be_equal_to(true);
        }

        protected override IBill context()
        {
            one_hundred_twenty_three_dollars_fourty_five_cents = new money(123, 45);
            var direct_energy = an<ICompany>();
            return new bill(direct_energy, one_hundred_twenty_three_dollars_fourty_five_cents, DateTime.Now);
        }

        protected override void because()
        {
            sut.pay(one_hundred_twenty_three_dollars_fourty_five_cents);
            result = sut.is_paid_for();
        }

        private IMoney one_hundred_twenty_three_dollars_fourty_five_cents;
        private bool result;
    }

    [Concern(typeof (bill))]
    public class when_checking_if_two_bills_are_the_same_and_they_are : old_context_specification<IBill>
    {
        [Observation]
        public void it_should_return_true()
        {
            result.should_be_equal_to(true);
        }

        protected override IBill context()
        {
            company = an<ICompany>();
            due_date = new DateTime(2008, 01, 01);
            return new bill(company, new money(0), due_date);
        }

        protected override void because()
        {
            result = sut.Equals(new bill(company, new money(0), due_date));
        }

        private ICompany company;
        private DateTime due_date;
        private bool result;
    }
}