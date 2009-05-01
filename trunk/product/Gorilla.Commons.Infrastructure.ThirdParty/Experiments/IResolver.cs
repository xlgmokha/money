using System;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    public interface IResolver<T>
    {
        Func<T> build { get; }
    }
}