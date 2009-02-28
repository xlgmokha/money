using System;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.Core;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Domain.accounting.billing
{
    [Concern(typeof (Bill))]
    public class when_checking_to_see_if_a_new_bill_has_been_paid_for : concerns_for<IBill>
    {
        it should_return_false = () => result.should_be_equal_to(false);

        public override IBill create_sut()
        {
            return new Bill(enmax, amount_owed, DateTime.Now);
        }

        context c = () =>
                        {
                            amount_owed = new Money(100);
                            enmax = an<ICompany>();
                        };

        because b = () => { result = sut.is_paid_for(); };

        static bool result;
        static IMoney amount_owed;
        static ICompany enmax;
    }

    [Concern(typeof (Bill))]
    public class when_checking_if_a_paid_bill_has_been_paid_for : concerns_for<IBill>
    {
        it should_return_true = () => result.should_be_equal_to(true);


        context c = () =>
                        {
                            one_hundred_twenty_three_dollars_fourty_five_cents = new Money(123, 45);
                            direct_energy = an<ICompany>();
                        };

        because b = () =>
                        {
                            sut.pay(one_hundred_twenty_three_dollars_fourty_five_cents);
                            result = sut.is_paid_for();
                        };

        public override IBill create_sut()
        {
            return new Bill(direct_energy, one_hundred_twenty_three_dollars_fourty_five_cents, DateTime.Now);
        }

        static IMoney one_hundred_twenty_three_dollars_fourty_five_cents;
        static bool result;
        static ICompany direct_energy;
    }

    [Concern(typeof (Bill))]
    public class when_checking_if_two_bills_are_the_same_and_they_are : concerns_for<IBill>
    {
        it should_return_true = () => result.should_be_equal_to(true);


        context c = () =>
                        {
                            company = an<ICompany>();
                            due_date = new DateTime(2008, 01, 01);
                        };

        because b = () => { result = sut.Equals(new Bill(company, new Money(0), due_date)); };

        public override IBill create_sut()
        {
            return new Bill(company, new Money(0), due_date);
        }

        static ICompany company;
        static DateTime due_date;
        static bool result;
    }
}