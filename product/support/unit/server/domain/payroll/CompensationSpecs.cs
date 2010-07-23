using System;
using Machine.Specifications;
using presentation.windows.server.domain;
using presentation.windows.server.domain.payroll;

namespace unit.server.domain.payroll
{
    public class CompensationSpecs
    {
        public abstract class concern 
        {
            Establish c = () =>
            {
                sut = new Compensation();
            };

            static protected Compensation sut;
        }

        [Subject(typeof (Compensation))]
        public class when_calculating_the_amount_unvested : concern
        {
            Because b = () =>
            {
                //Calendar.stop(() => new DateTime(2009, 06, 07));
                //sut.increase_salary_to(65500);
                Calendar.stop(() => new DateTime(2009, 09, 15));
                sut.issue_grant(4500.00, 10.00, new One<Third>(), new Annually());

                Calendar.start();
                sut.grant_for(new DateTime(2009, 09, 15)).change_unit_price_to(20.00);
            };

            It should_indicate_that_nothing_has_vested_before_the_first_anniversary = () =>
            {
                sut.unvested_balance(new DateTime(2010, 09, 14)).should_be_equal_to(9000);
            };

            It should_indicate_that_one_third_has_vested_after_the_first_anniversary = () =>
            {
                sut.unvested_balance(new DateTime(2010, 09, 15)).should_be_equal_to(6000);
            };

            It should_indicate_that_two_thirds_has_vested_after_the_second_anniversary = () =>
            {
                sut.unvested_balance(new DateTime(2011, 09, 15)).should_be_equal_to(3000);
            };

            It should_indicate_that_the_complete_grant_has_vested_after_the_third_anniversary = () =>
            {
                sut.unvested_balance(new DateTime(2012, 09, 15)).should_be_equal_to(0);
            };
        }
    }
}