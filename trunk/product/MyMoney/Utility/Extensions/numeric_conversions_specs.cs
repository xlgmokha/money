using jpboodhoo.bdd.contexts;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Utility.Extensions
{
    public class when_converting_a_valid_string_to_a_long : concerns_for
    {
        it should_return_the_correct_result = () => result.should_be_equal_to(88L);

        context c = () => { valid_numeric_string = "88"; };

        because b = () => { result = valid_numeric_string.to_long(); };

        static long result;
        static string valid_numeric_string;
    }

    public class when_converting_a_valid_string_to_an_int : concerns_for
    {
        it should_return_the_correct_result = () => result.should_be_equal_to(66);

        context c = () => { valid_numeric_string = "66"; };

        because b = () => { result = valid_numeric_string.to_int(); };

        static int result;
        static string valid_numeric_string;
    }
}