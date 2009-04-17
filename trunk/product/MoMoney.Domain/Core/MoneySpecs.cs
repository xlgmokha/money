using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace MoMoney.Domain.Core
{
    [Concern(typeof (Money))]
    public class when_adding_two_monies_together : concerns_for<IMoney>
    {
        it should_return_the_correct_money = () => result.should_be_equal_to(new Money(2, 98));


        because b = () => { result = sut.add(new Money(1, 99)); };

        public override IMoney create_sut()
        {
            return new Money(0, 99);
        }

        static IMoney result;
    }

    [Concern(typeof (Money))]
    public class when_two_monies_of_the_same_value_are_compared_to_one_another : concerns_for<IMoney>
    {
        it they_should_be_equal = () => result.should_be_equal_to(true);


        because b = () => { result = sut.Equals(new Money(1, 99)); };

        public override IMoney create_sut()
        {
            return new Money(1, 99);
        }

        static bool result;
    }

    [Concern(typeof (Money))]
    public class when_creating_a_money_with_pennies_greater_than_a_dollar : concerns_for<IMoney>
    {
        it should_create_a_money_representing_the_correct_amount_of_dollars_and_pennies =
            () => sut.should_be_equal_to(new Money(3, 00));

        public override IMoney create_sut()
        {
            return new Money(1, 200);
        }
    }
}