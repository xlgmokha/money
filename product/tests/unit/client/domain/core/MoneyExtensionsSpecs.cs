using developwithpassion.bdd.contexts;
using MoMoney.Domain.Core;

namespace tests.unit.client.domain.core
{
    public class when_converting_a_valid_amount_to_a_money : concerns
    {
        it should_return_the_correct_money = () => result.should_be_equal_to(new Money(1.99));

        because b = () => { result = 1.99; };

        static Money result;
    }
}