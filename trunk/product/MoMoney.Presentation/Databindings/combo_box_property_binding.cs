using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Databindings
{
    public class combo_box_property_binding<TypeToBindTo, PropertyType> : IPropertyBinding<PropertyType>
    {
        private readonly IPropertyBinder<TypeToBindTo, PropertyType> binder;

        public combo_box_property_binding(ComboBox control, IPropertyBinder<TypeToBindTo, PropertyType> binder)
        {
            this.binder = binder;
            control.SelectedItem = binder.current_value();
            control.SelectedIndexChanged +=
                delegate { binder.change_value_of_property_to(control.SelectedItem.converted_to<PropertyType>()); };
        }

        public PropertyType current_value()
        {
            return binder.current_value();
        }
    }
}