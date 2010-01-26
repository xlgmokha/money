using System;
using System.Reflection;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.mapping
{
    public class ImmutablePropertyException : Exception
    {
        public const string exception_message_format = "The property [{0}] on the target type [{1}] is immutable";

        public ImmutablePropertyException(Type target, PropertyInfo property)
            : base(exception_message_format.formatted_using(property.Name, target.Name)) {}
    }
}