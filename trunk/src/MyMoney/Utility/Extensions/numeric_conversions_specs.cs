using jpboodhoo.bdd.contexts;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Utility.Extensions
{
    public class when_converting_a_valid_string_to_a_long : concerns_for
    {
        it should_return_the_correct_result = () =>
        {
            result.should_be_equal_to(88L);
        };

        context c = () =>
                {
                    valid_numeric_string = "88";
                };

        because b = () =>
                {
                    result = valid_numeric_string.to_long();
                };

        private static long result;
        private static string valid_numeric_string;
    }

    public class when_converting_a_valid_string_to_an_int : context_specification
    {
        [Observation]
        public void it_should_return_the_correct_result()
        {
            result.should_be_equal_to(66);
        }

        protected override void context()
        {
            valid_numeric_string = "66";
        }

        protected override void because()
        {
            result = valid_numeric_string.to_int();
        }

        private int result;
        private string valid_numeric_string;
    }
}