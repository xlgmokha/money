using System;
using System.Linq.Expressions;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Presentation.Databindings
{
    public class binding_selector_specs
    {}

    [Concern(typeof (binding_selector<IAnInterface>))]
    public class when_selecting_a_property_as_the_target_of_a_binding : old_context_specification<IBindingSelector<IAnInterface>>
    {
        [Observation]
        public void should_return_a_binder_bound_to_the_correct_property()
        {
            result.property.Name.should_be_equal_to("FirstName");
        }

        [Observation]
        public void should_inspect_the_expression_for_the_property_information()
        {
            inspector.was_told_to(i => i.inspect(expression_to_parse));
        }

        protected override IBindingSelector<IAnInterface> context()
        {
            thing_to_bind_to = an<IAnInterface>();
            factory = an<IPropertyInspectorFactory>();
            inspector = an<IPropertyInspector<IAnInterface, string>>();

            factory
                .is_told_to(f => f.create<IAnInterface, string>())
                .Return(inspector);

            inspector.is_told_to(i => i.inspect(null))
                .IgnoreArguments()
                .Return(typeof (IAnInterface).GetProperty("FirstName"));

            return new binding_selector<IAnInterface>(thing_to_bind_to, factory);
        }

        protected override void because()
        {
            expression_to_parse = (s => s.FirstName);
            result = sut.bind_to_property(expression_to_parse);
        }

        private IAnInterface thing_to_bind_to;
        private IPropertyBinder<IAnInterface, string> result;
        private IPropertyInspectorFactory factory;
        private IPropertyInspector<IAnInterface, string> inspector;
        private Expression<Func<IAnInterface, string>> expression_to_parse;
    }
}