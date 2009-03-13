using developwithpassion.bdd.contexts;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Utility.Extensions
{
    public class when_getting_the_last_interface_for_a_type : concerns_for
    {
        it should_return_the_correct_one = () => typeof (TestType).last_interface().should_be_equal_to(typeof (ITestType));
    }

    public interface IBase
    {
    }

    public class BaseType : IBase
    {
    }

    public interface ITestType
    {
    }

    public class TestType : BaseType, ITestType
    {
    }
}