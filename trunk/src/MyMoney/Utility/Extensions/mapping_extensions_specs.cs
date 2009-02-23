using jpboodhoo.bdd.contexts;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Utility.Core;

namespace MyMoney.Utility.Extensions
{
    [Concern(typeof (mapping_extensions))]
    public class when_transforming_type_A_to_type_B_then_C : concerns_for
    {
        it should_return_the_correct_result = () => result.should_be_equal_to(1);

        context c = () =>
                        {
                            first_mapper = an<IMapper<object, string>>();
                            second_mapper = an<IMapper<string, int>>();
                            a = 1;

                            when_the(first_mapper).is_told_to(x => x.map_from(a)).it_will_return("1");
                            when_the(second_mapper).is_told_to(x => x.map_from("1")).it_will_return(1);
                        };

        because b = () => { result = first_mapper.then(second_mapper).map_from(a); };


        static int result;
        static IMapper<object, string> first_mapper;
        static IMapper<string, int> second_mapper;
        static object a;
    }
}