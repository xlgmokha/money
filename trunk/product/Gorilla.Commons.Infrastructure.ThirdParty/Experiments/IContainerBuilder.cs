using System;
using System.Linq.Expressions;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public interface IContainerBuilder : IBuilder<IDependencyRegistry>
    {
        IExtendedRegistration<T> register<T>(Expression<Func<T>> func) where T : class;
    }
}