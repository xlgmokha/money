using jpboodhoo.bdd.contexts;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Domain.Core
{
    public class when_converting_a_valid_amount_to_a_money : concerns_for
    {
        it should_return_the_correct_money = () => result.should_be_equal_to(new Money(1, 99));

        because b = () => { result = 1.99.as_money(); };

        static IMoney result;
    }
}