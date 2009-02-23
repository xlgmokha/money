using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MyMoney.Presentation.Databindings
{
    public static class Create
    {
        public static IBindingSelector<TypeToBindTo> binding_for<TypeToBindTo>(TypeToBindTo thing_to_bind_to)
        {
            return new binding_selector<TypeToBindTo>(thing_to_bind_to, new property_inspector_factory());
        }

        public static IPropertyBinding<TypeOfProperty> bind_to<TypeToBindTo, TypeOfProperty>(
            this Control control,
            TypeToBindTo dto,
            Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to)
        {
            return binding_for(dto)
                .bind_to_property(property_to_bind_to)
                .bound_to_control(control);
        }
    }
}