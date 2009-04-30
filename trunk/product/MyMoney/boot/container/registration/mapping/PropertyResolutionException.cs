using System;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.boot.container.registration.mapping
{
    public class PropertyResolutionException : Exception
    {
        public const string exception_message_format = "Failed to find the property named {0} on type {1}";

        public PropertyResolutionException(Type type_that_did_not_have_the_property,
                                           string property_that_could_not_be_found)
            : base(
                exception_message_format.formatted_using(property_that_could_not_be_found,
                                                         type_that_did_not_have_the_property.Name))

        {
        }
    }
}