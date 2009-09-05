using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.boot.container.registration.mapping
{
    public class PropertyResolver : IPropertyResolver
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                             BindingFlags.FlattenHierarchy;

        public PropertyInfo resolve_using<Input, PropertyType>(Expression<Func<Input, PropertyType>> expression)
        {
            var member_accessor = (MemberExpression) expression.Body;
            return resolve_using(typeof (Input), member_accessor.Member.Name);
        }

        public PropertyInfo resolve_using(Type type, string property_name)
        {
            var property = all_properties_belonging_to(type).Where(x => x.Name.Equals(property_name)).FirstOrDefault();

            if (property == null) throw new PropertyResolutionException(type, property_name);

            return property;
        }

        public IEnumerable<PropertyInfo> all_properties_belonging_to(Type type)
        {
            var stack = new Stack<Type>();
            stack.Push(type);

            while (stack.Count > 0)
            {
                var type_to_interrogate = stack.Pop();

                type_to_interrogate.GetInterfaces().each(stack.Push);
                foreach (var a_property in all_properties_for(type_to_interrogate))
                {
                    yield return a_property;
                }
            }
        }

        public IEnumerable<PropertyInfo> all_properties_belonging_to<T>()
        {
            return all_properties_belonging_to(typeof (T));
        }

        PropertyInfo[] all_properties_for(Type type)
        {
            return type.GetProperties(flags);
        }
    }
}