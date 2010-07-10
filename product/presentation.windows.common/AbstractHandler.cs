using System;
using Gorilla.Commons.Infrastructure.Logging;

namespace presentation.windows.common
{
    public abstract class AbstractHandler<T> : Handler<T>, Handler
    {
        bool can_handle(Type type)
        {
            return typeof (T).Equals(type);
        }

        public void handle(object item)
        {
            if (can_handle(item.GetType()))
            {
                this.log().debug("handling... {0}", item);
                handle((T) item);
            }
        }

        public abstract void handle(T item);
    }
}