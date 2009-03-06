using System.Reflection;
using jpboodhoo.bdd.contexts;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Databindings
{
    [Concern(typeof (property_inspector<IAnInterface, string>))]
    public class when_parsing_a_valie_expression_for_the_information_on_the_property :
        concerns_for<IPropertyInspector<IAnInterface, string>, property_inspector<IAnInterface, string>>
    {
        it should_return_the_correct_property_information = () => result.Name.should_be_equal_to("FirstName");

        because b = () => { result = sut.inspect(s => s.FirstName); };

        public override IPropertyInspector<IAnInterface, string> create_sut()
        {
            return new property_inspector<IAnInterface, string>();
        }

        static PropertyInfo result;
    }
}