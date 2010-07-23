using System;
using Gorilla.Commons.Utility;
using Machine.Specifications;

namespace unit.server.domain.payroll
{
    public class DateSpecs
    {
        [Subject(typeof (Date))]
        public class when_two_dates_are_the_same
        {
            Establish c = () =>
            {
                sut = new DateTime(2009, 01, 01, 01, 00, 00);
            };

            It should_be_equal = () =>
            {
                sut.Equals(new DateTime(2009, 01, 01, 09, 00, 01)).should_be_true();
            };

            static Date sut;
        }
    }
}