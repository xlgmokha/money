using System;
using Machine.Specifications;

namespace unit
{
    static public class AssertionExtensions
    {
        static public void should_not_be_null<T>(this T item)
        {
            item.ShouldNotBeNull();
        }

        static public void should_be_an_instance_of<T>(this object actual)
        {
            actual.ShouldBeOfType(typeof (T));
        }

        static public void should_be_equal_to<T>(this T actual, T expected)
        {
            actual.ShouldEqual(expected);
        }

        static public void should_not_be_equal_to<T>(this T actual, T expected)
        {
            actual.ShouldNotEqual(expected);
        }

        static public void should_be_true(this bool actual)
        {
            actual.ShouldBeTrue();
        }

        static public void should_be_false(this bool actual)
        {
            actual.ShouldBeFalse();
        }

        static public void should_have_thrown<Exception>(this Action action) where Exception : System.Exception
        {
            try
            {
                action();
                throw new System.Exception("Did not throw.");
            }
            catch (Exception e)
            {
                if (!e.GetType().Equals(typeof (Exception)))
                {
                    throw new System.Exception("Threw the wrong exception");
                }
            }
        }
    }
}