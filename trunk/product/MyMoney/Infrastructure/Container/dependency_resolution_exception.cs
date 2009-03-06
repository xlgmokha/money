using System;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container
{
    public class dependency_resolution_exception<T> : Exception
    {
        public dependency_resolution_exception(Exception innerException)
            : base("Could not resolve {0}".formatted_using(typeof (T).FullName), innerException)
        {}
    }
}