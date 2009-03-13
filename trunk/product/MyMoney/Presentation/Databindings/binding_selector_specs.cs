using System;
using System.Linq.Expressions;
using developwithpassion.bdd.contexts;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;
using mocking_extensions=MoMoney.Testing.spechelpers.core.mocking_extensions;

namespace MoMoney.Presentation.Databindings
{
    [Concern(typeof (binding_selector<IAnInterface>))]
    public class when_selecting_a_property_as_the_target_of_a_binding : concerns_for<IBindingSelector<IAnInterface>>
    {
        it should_return_a_binder_bound_to_the_correct_property =
            () => result.property.Name.should_be_equal_to("FirstName");

        it should_inspect_the_expression_for_the_property_information =
            () => mocking_extensions.was_told_to(inspector, i => i.inspect(expression_to_parse));

        context c = () =>
                        {
                            thing_to_bind_to = an<IAnInterface>();
                            factory = an<IPropertyInspectorFactory>();
                            inspector = an<IPropertyInspector<IAnInterface, string>>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(factory, f => f.create<IAnInterface, string>()), inspector);

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(inspector, i => i.inspect(null))
                                                    .IgnoreArguments(), typeof (IAnInterface).GetProperty("FirstName"));
                        };

        because b = () =>
                        {
                            expression_to_parse = (s => s.FirstName);
                            result = sut.bind_to_property(expression_to_parse);
                        };

        public override IBindingSelector<IAnInterface> create_sut()
        {
            return new binding_selector<IAnInterface>(thing_to_bind_to, factory);
        }

        static IAnInterface thing_to_bind_to;
        static IPropertyBinder<IAnInterface, string> result;
        static IPropertyInspectorFactory factory;
        static IPropertyInspector<IAnInterface, string> inspector;
        static Expression<Func<IAnInterface, string>> expression_to_parse;
    }
}