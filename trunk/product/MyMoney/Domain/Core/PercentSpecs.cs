using developwithpassion.bdd.contexts;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Domain.Core
{
    public class when_comparing_fifty_divided_by_one_hundred_to_fifty_percent : concerns
    {
        it they_should_be_equal = () => new Percent(50, 100).should_be_equal_to<Percent>(50);
    }

    public class when_calculating_a_fractional_percentage : concerns
    {
        it should_return_the_correct_percentage = () => new Percent(30, 90).should_be_equal_to<Percent>(33.3);
    }
}