using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Domain.Core
{
    public class date_specs
    {}

    [Concern(typeof (date))]
    public class when_two_dates_that_represent_the_same_day_are_asked_if_they_are_equal : old_context_specification<IDate>
    {
        [Observation]
        public void it_should_return_true()
        {
            result.should_be_equal_to(true);
        }

        protected override IDate context()
        {
            return new date(2008, 09, 25);
        }

        protected override void because()
        {
            result = sut.Equals(new date(2008, 09, 25));
        }

        private bool result;
    }

    [Concern(typeof (date))]
    public class when_an_older_date_is_compared_to_a_younger_date : old_context_specification<IDate>
    {
        [Observation]
        public void it_should_return_a_positive_number()
        {
            result.should_be_greater_than(0);
        }

        protected override IDate context()
        {
            return new date(2008, 09, 25);
        }

        protected override void because()
        {
            result = sut.CompareTo(new date(2007, 01, 01));
        }

        private int result;
    }
}