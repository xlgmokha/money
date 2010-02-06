using System;

namespace tests.unit
{
    public interface IMockFactory
    {
        T create<T>() where T : class;
        object create(Type type);
    }
}