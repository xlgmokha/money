using System;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Databindings
{
    public class text_property_binding<TypeToBindTo, PropertyType> : IPropertyBinding<PropertyType>
    {
        private readonly IPropertyBinder<TypeToBindTo, PropertyType> binder;

        public text_property_binding(Control control, IPropertyBinder<TypeToBindTo, PropertyType> binder)
        {
            this.binder = binder;
            control.Text = "{0}".formatted_using(binder.current_value());
            control.TextChanged +=
                ((sender, e) => binder.change_value_of_property_to(control.Text.converted_to<PropertyType>()));
        }

        public PropertyType current_value()
        {
            return binder.current_value();
        }
    }
}