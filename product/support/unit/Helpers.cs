using Rhino.Mocks;

namespace unit
{
    public class Helpers
    {
        static public T a<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }
    }
}