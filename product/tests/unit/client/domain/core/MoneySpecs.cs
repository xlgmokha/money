using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace MoMoney.Domain.Core
{
    [Concern(typeof (Money))]
    public class when_adding_two_monies_together : concerns_for<Money>
    {
        it should_return_the_correct_money = () => result.should_be_equal_to(new Money(2.98));

        because b = () =>
                    {
                        result = sut.add(new Money(1.99));
                    };

        public override Money create_sut()
        {
            return new Money(0.99);
        }

        static Money result;
    }

    [Concern(typeof (Money))]
    public class when_two_monies_of_the_same_value_are_compared_to_one_another : concerns_for<Money>
    {
        it they_should_be_equal = () => result.should_be_equal_to(true);


        because b = () =>
                    {
                        result = sut.Equals(new Money(1.99));
                    };

        public override Money create_sut()
        {
            return new Money(1.99);
        }

        static bool result;
    }
}