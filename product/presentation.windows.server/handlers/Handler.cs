namespace presentation.windows.server.handlers
{
    public interface Handler<T>
    {
        void handle(T item);
    }
}