using System;
using System.Linq.Expressions;

namespace MoMoney.Presentation.Databindings
{
    public interface IBindingSelector<TypeToBindTo>
    {
        IPropertyBinder<TypeToBindTo, TypeOfProperty> bind_to_property<TypeOfProperty>(
            Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to);
    }

    public class binding_selector<TypeToBindTo> : IBindingSelector<TypeToBindTo>
    {
        private readonly TypeToBindTo thing_to_bind_to;
        private readonly IPropertyInspectorFactory factory;

        public binding_selector(TypeToBindTo thing_to_bind_to, IPropertyInspectorFactory factory)
        {
            this.thing_to_bind_to = thing_to_bind_to;
            this.factory = factory;
        }

        public IPropertyBinder<TypeToBindTo, TypeOfProperty> bind_to_property<TypeOfProperty>(
            Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to)
        {
            var property_information = factory.create<TypeToBindTo, TypeOfProperty>().inspect(property_to_bind_to);
            return new property_binder<TypeToBindTo, TypeOfProperty>(property_information, thing_to_bind_to);
        }
    }
}