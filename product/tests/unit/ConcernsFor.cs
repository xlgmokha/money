using System;

namespace tests.unit
{
    [Obsolete]
    public class concerns : test {}

    [Obsolete]
    public abstract class TestsFor<T> : tests_for<T> {}

    [Obsolete]
    public abstract class tests_for<T> : runner<T> {}
}