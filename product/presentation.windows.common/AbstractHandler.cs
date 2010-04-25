using System;

namespace presentation.windows.common
{
    public abstract class AbstractHandler<T> : Handler<T>, Handler
    {
        public bool can_handle(Type type)
        {
            return typeof (T).Equals(type);
        }

        public void handle(object item)
        {
            handle((T) item);
        }

        public abstract void handle(T item);
    }
}