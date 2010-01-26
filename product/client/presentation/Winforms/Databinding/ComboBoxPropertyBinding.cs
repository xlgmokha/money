using System.Windows.Forms;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Winforms.Databinding
{
    public class ComboBoxPropertyBinding<TypeToBindTo, PropertyType> : IPropertyBinding<PropertyType>
    {
        readonly IPropertyBinder<TypeToBindTo, PropertyType> binder;

        public ComboBoxPropertyBinding(ComboBox control, IPropertyBinder<TypeToBindTo, PropertyType> binder)
        {
            this.binder = binder;
            control.SelectedItem = binder.current_value();
            control.SelectedIndexChanged +=
                delegate
                {
                    binder.change_value_of_property_to(control.SelectedItem.converted_to<PropertyType>());
                };
        }

        public PropertyType current_value()
        {
            return binder.current_value();
        }
    }
}