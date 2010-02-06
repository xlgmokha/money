using System;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.Core;

namespace tests.unit.client.domain.accounting
{
    [Concern(typeof (Bill))]
    public class when_checking_to_see_if_a_new_bill_has_been_paid_for : tests_for<Bill>
    {
        it should_return_false = () => result.should_be_equal_to(false);

        public override Bill create_sut()
        {
            return Bill.New(enmax, amount_owed, DateTime.Now);
        }

        context c = () =>
        {
            amount_owed = new Money(100);
            enmax = an<Company>();
        };

        because b = () =>
        {
            result = sut.is_paid_for();
        };

        static bool result;
        static Money amount_owed;
        static Company enmax;
    }

    [Concern(typeof (Bill))]
    public class when_checking_if_a_paid_bill_has_been_paid_for : tests_for<Bill>
    {
        it should_return_true = () => result.should_be_equal_to(true);


        context c = () =>
        {
            one_hundred_twenty_three_dollars_fourty_five_cents = new Money(123.45);
            direct_energy = an<Company>();
        };

        because b = () =>
        {
            sut.pay(one_hundred_twenty_three_dollars_fourty_five_cents);
            result = sut.is_paid_for();
        };

        public override Bill create_sut()
        {
            return Bill.New(direct_energy, one_hundred_twenty_three_dollars_fourty_five_cents, DateTime.Now);
        }

        static Money one_hundred_twenty_three_dollars_fourty_five_cents;
        static bool result;
        static Company direct_energy;
    }

    //[Concern(typeof (Bill))]
    //public class when_checking_if_two_bills_are_the_same_and_they_are : concerns_for<Bill>
    //{
    //    it should_return_true = () => result.should_be_true();

    //    context c = () =>
    //                    {
    //                        company = an<Company>();
    //                        due_date = new DateTime(2008, 01, 01);
    //                    };

    //    because b = () => { result = sut.Equals( Bill.New(company, new Money(0), due_date)); };

    //    public override Bill create_sut()
    //    {
    //        return  Bill.New(company, new Money(0), due_date);
    //    }

    //    static Company company;
    //    static DateTime due_date;
    //    static bool result;
    //}
}