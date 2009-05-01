using System;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public class TypeAlreadyRegisteredInContainerException : Exception
    {
        public TypeAlreadyRegisteredInContainerException(Type typeNotFound, string registration)
            : base(build_message(typeNotFound, registration))
        {
        }

        static string build_message(Type typeNotFound, string registration)
        {
            return string.Format("The type {0} has already been registered with {1} in the container",
                                 typeNotFound.FullName, registration);
        }
    }
}