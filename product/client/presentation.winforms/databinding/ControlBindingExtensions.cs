using System;
using System.Windows.Forms;

namespace MoMoney.Presentation.Winforms.Databinding
{
    static public class ControlBindingExtensions
    {
        static public IPropertyBinding<PropertyType> bound_to_control<TypeToBindTo, PropertyType>(
            this IPropertyBinder<TypeToBindTo, PropertyType> binder,
            Control control)
        {
            return new TextPropertyBinding<TypeToBindTo, PropertyType>(control, binder);
        }

        static public IPropertyBinding<PropertyType> bound_to_control<TypeToBindTo, PropertyType>(
            this IPropertyBinder<TypeToBindTo, PropertyType> binder,
            ComboBox control)
        {
            return new ComboBoxPropertyBinding<TypeToBindTo, PropertyType>(control, binder);
        }

        static public IPropertyBinding<DateTime> bound_to_control<TypeToBindTo>(
            this IPropertyBinder<TypeToBindTo, DateTime> binder,
            DateTimePicker control)
        {
            return new DateTimePickerPropertyBinding<TypeToBindTo>(control, binder);
        }
    }
}