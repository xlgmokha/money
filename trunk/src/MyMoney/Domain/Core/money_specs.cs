using jpboodhoo.bdd.contexts;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Domain.Core
{
    [Concern(typeof (money))]
    public class when_adding_two_monies_together : concerns_for<IMoney>
    {
        it should_return_the_correct_money = () => result.should_be_equal_to(new money(2, 98));


        because b = () => { result = sut.add(new money(1, 99)); };

        public override IMoney create_sut()
        {
            return new money(0, 99);
        }

        static IMoney result;
    }

    [Concern(typeof (money))]
    public class when_two_monies_of_the_same_value_are_compared_to_one_another : concerns_for<IMoney>
    {
        it they_should_be_equal = () => result.should_be_equal_to(true);


        because b = () => { result = sut.Equals(new money(1, 99)); };

        public override IMoney create_sut()
        {
            return new money(1, 99);
        }

        static bool result;
    }

    [Concern(typeof (money))]
    public class when_creating_a_money_with_pennies_greater_than_a_dollar : concerns_for<IMoney>
    {
        it should_create_a_money_representing_the_correct_amount_of_dollars_and_pennies =
            () => sut.should_be_equal_to(new money(3, 00));

        public override IMoney create_sut()
        {
            return new money(1, 200);
        }
    }
}