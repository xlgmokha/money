using System;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Container
{
    public class DependencyResolutionException<T> : Exception
    {
        public DependencyResolutionException(Exception innerException)
            : base("Could not resolve {0}".formatted_using(typeof (T).FullName), innerException)
        {
        }
    }
}