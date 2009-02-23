using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Domain.Core
{
    public class money_specs
    {}

    [Concern(typeof (money))]
    public class when_adding_two_monies_together : old_context_specification<IMoney>
    {
        [Observation]
        public void it_should_return_the_correct_money()
        {
            result.should_be_equal_to(new money(2, 98));
        }

        protected override IMoney context()
        {
            return new money(0, 99);
        }

        protected override void because()
        {
            result = sut.add(new money(1, 99));
        }

        private IMoney result;
    }

    [Concern(typeof (money))]
    public class when_two_monies_of_the_same_value_are_compared_to_one_another : old_context_specification<IMoney>
    {
        [Observation]
        public void they_should_be_equal()
        {
            result.should_be_equal_to(true);
        }

        protected override IMoney context()
        {
            return new money(1, 99);
        }

        protected override void because()
        {
            result = sut.Equals(new money(1, 99));
        }

        private bool result;
    }

    [Concern(typeof (money))]
    public class when_creating_a_money_with_pennies_greater_than_a_dollar : old_context_specification<IMoney>
    {
        [Observation]
        public void it_should_create_a_money_representing_the_correct_amount_of_dollars_and_pennies()
        {
            sut.should_be_equal_to(new money(3, 00));
        }

        protected override IMoney context()
        {
            return new money(1, 200);
        }

        protected override void because()
        {}
    }
}