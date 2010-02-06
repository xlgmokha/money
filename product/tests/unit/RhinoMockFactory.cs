using System;
using Rhino.Mocks;

namespace tests.unit
{
    public class RhinoMockFactory : IMockFactory
    {
        public T create<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        public object create(Type type)
        {
            return MockRepository.GenerateStub(type);
        }
    }
}