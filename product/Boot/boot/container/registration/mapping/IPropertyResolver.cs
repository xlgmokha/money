using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace MoMoney.boot.container.registration.mapping
{
    public interface IPropertyResolver
    {
        PropertyInfo resolve_using<Input, PropertyType>(Expression<Func<Input, PropertyType>> expression);
        PropertyInfo resolve_using(Type type, string property_name);
        IEnumerable<PropertyInfo> all_properties_belonging_to(Type type);
        IEnumerable<PropertyInfo> all_properties_belonging_to<T>();
    }
}