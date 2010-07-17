using System;
using Rhino.Mocks;

namespace unit
{
    static public class Mocking
    {
        static public void received<T>(this T mock, Action<T> action) where T : class
        {
            mock.AssertWasCalled(action);
        }
    }
}