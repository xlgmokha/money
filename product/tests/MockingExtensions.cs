using System;
using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace tests
{
    static public class MockingExtensions
    {
        static public MethodCallOccurance<T> was_told_to<T>(this T mocked_item, Action<T> action_to_perform)
        {
            return new MethodCallOccurance<T>(mocked_item, action_to_perform);
        }

        static public void was_not_told_to<T>(this T mocked_item, Action<T> action_to_perform)
        {
            mocked_item.AssertWasNotCalled(action_to_perform);
        }

        static public IMethodOptions<R> is_told_to<T, R>(this T mocked_item, Function<T, R> action_to_perform) where T : class
        {
            return mocked_item.Stub(action_to_perform);
        }

        static public IMethodOptions<R> is_asked_for<T, R>(this T mock, Function<T, R> func) where T : class
        {
            return mock.Stub(func);
        }

        static public IMethodOptions<R> it_will_return<R>(this IMethodOptions<R> options, R item)
        {
            return options.Return(item);
        }

        static public IMethodOptions<IEnumerable<R>> it_will_return<R>(this IMethodOptions<IEnumerable<R>> options,
                                                                       params R[] items)
        {
            return options.Return(items.AsEnumerable());
        }

        static public IMethodOptions<IEnumerable<R>> it_will_return_nothing<R>(
            this IMethodOptions<IEnumerable<R>> options)
        {
            return options.it_will_return();
        }

        static public void it_will_throw<R>(this IMethodOptions<R> options, Exception item)
        {
            options.Throw(item);
        }
    }
}