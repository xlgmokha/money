namespace tests
{
    static class Casting
    {
        static public T downcast_to<T>(this object item)
        {
            return (T) item;
        }
    }
}