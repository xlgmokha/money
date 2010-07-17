using System;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace unit
{
    static public class Mocking
    {
        static public void received<T>(this T mock, Action<T> action) where T : class
        {
            mock.AssertWasCalled(action);
        }

        static public IMethodOptions<R> is_told_to<T, R>(this T mock, Function<T, R> action) where T : class
        {
            return mock.Stub(action);
        }

        static public IMethodOptions<T> it_will_return<T>(this IMethodOptions<T> options, T objToReturn)
        {
            return options.Return(objToReturn);
        }
    }
}