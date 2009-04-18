using System;
using System.Linq.Expressions;
using System.Reflection;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Databindings
{
    public interface IPropertyInspector<TypeToBindTo, TypeOfProperty>
    {
        PropertyInfo inspect(Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to);
    }

    public class property_inspector<TypeToBindTo, TypeOfProperty> : IPropertyInspector<TypeToBindTo, TypeOfProperty>
    {
        public PropertyInfo inspect(Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to)
        {
            var expression = property_to_bind_to.Body.downcast_to<MemberExpression>();
            return expression.Member.downcast_to<PropertyInfo>();
        }
    }
}