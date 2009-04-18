using System;
using System.Windows.Forms;

namespace MoMoney.Presentation.Databindings
{
    public class date_time_picker_property_binding<TypeToBindTo> : IPropertyBinding<DateTime>
    {
        private readonly IPropertyBinder<TypeToBindTo, DateTime> binder;

        public date_time_picker_property_binding(DateTimePicker control, IPropertyBinder<TypeToBindTo, DateTime> binder)
        {
            this.binder = binder;
            control.ValueChanged += delegate { binder.change_value_of_property_to(control.Value); };
        }

        public DateTime current_value()
        {
            return binder.current_value();
        }
    }
}