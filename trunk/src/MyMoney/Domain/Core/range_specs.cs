using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Domain.Core
{
    public class range_specs
    {}

    [Concern(typeof (range<int>))]
    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_1 :
        old_context_specification<IRange<int>>
    {
        [Observation]
        public void it_should_return_true()
        {
            result.should_be_equal_to(true);
        }

        protected override IRange<int> context()
        {
            return new range<int>(1, 10);
        }

        protected override void because()
        {
            result = sut.contains(1);
        }

        private bool result;
    }

    [Concern(typeof (range<int>))]
    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_10 :
        old_context_specification<IRange<int>>
    {
        [Observation]
        public void it_should_return_true()
        {
            result.should_be_equal_to(true);
        }

        protected override IRange<int> context()
        {
            return new range<int>(1, 10);
        }

        protected override void because()
        {
            result = sut.contains(10);
        }

        private bool result;
    }

    [Concern(typeof (range<int>))]
    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_0 :
        old_context_specification<IRange<int>>
    {
        [Observation]
        public void it_should_return_false()
        {
            result.should_be_equal_to(false);
        }

        protected override IRange<int> context()
        {
            return new range<int>(1, 10);
        }

        protected override void because()
        {
            result = sut.contains(0);
        }

        private bool result;
    }

    [Concern(typeof (range<int>))]
    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_11 :
        old_context_specification<IRange<int>>
    {
        [Observation]
        public void it_should_return_false()
        {
            result.should_be_equal_to(false);
        }

        protected override IRange<int> context()
        {
            return new range<int>(1, 10);
        }

        protected override void because()
        {
            result = sut.contains(0);
        }

        private bool result;
    }

    [Concern(typeof (range<int>))]
    public class when_a_range_is_created_where_the_start_of_the_range_is_greater_than_the_end :
        old_context_specification<IRange<int>>
    {
        [Observation]
        public void it_should_flip_the_start_and_end_of_the_range()
        {
            sut.start_of_range.should_be_equal_to(1);
            sut.end_of_range.should_be_equal_to(10);
        }

        protected override IRange<int> context()
        {
            return new range<int>(10, 1);
        }

        protected override void because()
        {}
    }
}