using System;
using Gorilla.Commons.Utility;
using Machine.Specifications;
using presentation.windows.server.domain;
using presentation.windows.server.domain.payroll;

namespace unit.server.domain.payroll
{
    public class GrantSpecs
    {
        public abstract class concern 
        {
            Establish c = () =>
            {
                Calendar.stop(() => new DateTime(2010, 01, 01));
                sut = Grant.New(120, 10, new One<Twelfth>(), new Monthly());
            };

            static protected Grant sut;
        }

        [Subject(typeof (Grant))]
        public class when_checking_what_the_outstanding_balance_of_a_grant_is : concern
        {
            It should_return_the_full_balance_before_the_first_vesting_date = () =>
            {
                Calendar.stop(() => new DateTime(2010, 01, 31));
                sut.balance().should_be_equal_to(120);
            };

            It should_return_the_unvested_portion_after_the_first_vesting_date = () =>
            {
                Calendar.stop(() => new DateTime(2010, 02, 01));
                sut.balance().should_be_equal_to(110);
            };
        }

        [Subject(typeof (Grant))]
        public class when_checking_what_the_value_of_a_grant_was_in_the_past : concern
        {
            Because b = () =>
            {
                Calendar.stop(() => january_15);
                sut.change_unit_price_to(20);

                Calendar.reset();
                sut.change_unit_price_to(40);
                result = sut.balance(january_15);
            };

            It should_return_the_correct_amount = () =>
            {
                result.should_be_equal_to(240);
            };

            static Money result;
            static Date january_15 = new DateTime(2010, 01, 15);
        }
    }
}