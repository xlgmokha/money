using System.Reflection;

namespace MoMoney.Presentation.Databindings
{
    public interface IPropertyBinder<TypeToBindTo, PropertyType>
    {
        TypeToBindTo target { get; }
        PropertyInfo property { get; }
        PropertyType current_value();
        void change_value_of_property_to(PropertyType new_value);
    }

    public class property_binder<TypeToBindTo, PropertyType> : IPropertyBinder<TypeToBindTo, PropertyType>
    {
        public property_binder(PropertyInfo propery_information, TypeToBindTo target)
        {
            property = target.GetType().GetProperty(propery_information.Name);
            this.target = target;
        }

        public TypeToBindTo target { get; private set; }
        public PropertyInfo property { get; private set; }

        public PropertyType current_value()
        {
            return (PropertyType) property.GetValue(target, null);
        }

        public void change_value_of_property_to(PropertyType value)
        {
            property.SetValue(target, value, null);
        }
    }
}