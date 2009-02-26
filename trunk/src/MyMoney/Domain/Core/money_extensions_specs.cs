using jpboodhoo.bdd.contexts;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Domain.Core
{
    public class when_converting_a_valid_amount_to_a_money : concerns_for
    {
        it should_return_the_correct_money = () => result.should_be_equal_to(new money(1, 99));

        because b = () => { result = 1.99.as_money(); };

        static IMoney result;
    }
}