using System;
using System.Windows.Forms;

namespace MoMoney.Presentation.Databindings
{
    public static class control_binding_extensions
    {
        public static IPropertyBinding<PropertyType> bound_to_control<TypeToBindTo, PropertyType>(
            this IPropertyBinder<TypeToBindTo, PropertyType> binder,
            Control control)
        {
            return new text_property_binding<TypeToBindTo, PropertyType>(control, binder);
        }

        public static IPropertyBinding<PropertyType> bound_to_control<TypeToBindTo, PropertyType>(
            this IPropertyBinder<TypeToBindTo, PropertyType> binder,
            ComboBox control)
        {
            return new combo_box_property_binding<TypeToBindTo, PropertyType>(control, binder);
        }

        public static IPropertyBinding<DateTime> bound_to_control<TypeToBindTo>(
            this IPropertyBinder<TypeToBindTo, DateTime> binder,
            DateTimePicker control)
        {
            return new date_time_picker_property_binding<TypeToBindTo>(control, binder);
        }
    }
}