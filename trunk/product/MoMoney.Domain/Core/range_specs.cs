using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace MoMoney.Domain.Core
{
    [Concern(typeof (range<int>))]
    public abstract class behaves_like_a_range_from_1_to_10 : concerns_for<IRange<int>>
    {
        public override IRange<int> create_sut()
        {
            return new range<int>(1, 10);
        }
    }

    [Concern(typeof (range<int>))]
    public abstract class behaves_like_a_range_from_10_to_1 : concerns_for<IRange<int>>
    {
        public override IRange<int> create_sut()
        {
            return new range<int>(10, 1);
        }
    }

    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_1 : behaves_like_a_range_from_1_to_10
    {
        it should_return_true = () => result.should_be_equal_to(true);

        because b = () => { result = sut.contains(1); };

        static bool result;
    }

    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_10 : behaves_like_a_range_from_1_to_10
    {
        it should_return_true = () => result.should_be_equal_to(true);

        because b = () => { result = sut.contains(10); };

        static bool result;
    }

    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_0 : behaves_like_a_range_from_1_to_10
    {
        it should_return_false = () => result.should_be_equal_to(false);

        because b = () => { result = sut.contains(0); };

        static bool result;
    }

    public class when_a_range_from_1_to_10_is_asked_if_it_contains_the_number_11 : behaves_like_a_range_from_1_to_10
    {
        it should_return_false = () => result.should_be_equal_to(false);

        because b = () => { result = sut.contains(0); };

        static bool result;
    }

    public class when_a_range_is_created_where_the_start_of_the_range_is_greater_than_the_end :
        behaves_like_a_range_from_10_to_1
    {
        it should_flip_the_start_and_end_of_the_range = () =>
                                                            {
                                                                sut.start_of_range.should_be_equal_to(1);
                                                                sut.end_of_range.should_be_equal_to(10);
                                                            };
    }
}