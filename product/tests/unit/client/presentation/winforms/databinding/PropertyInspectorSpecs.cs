using System.Reflection;
using MoMoney.Presentation.Winforms.Databinding;

namespace tests.unit.client.presentation.winforms.databinding
{
    [Concern(typeof (PropertyInspector<,>))]
    public class when_parsing_a_valie_expression_for_the_information_on_the_property :
        TestsFor<IPropertyInspector<IAnInterface, string>>
    {
        it should_return_the_correct_property_information = () => result.Name.should_be_equal_to("FirstName");

        because b = () =>
        {
            result = sut.inspect(s => s.FirstName);
        };

        public override IPropertyInspector<IAnInterface, string> create_sut()
        {
            return new PropertyInspector<IAnInterface, string>();
        }

        static PropertyInfo result;
    }

    public class PropertyInspectorSpecs {}
}