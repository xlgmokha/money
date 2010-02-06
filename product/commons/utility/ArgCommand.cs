namespace gorilla.commons.utility
{
    public interface ArgCommand<T>
    {
        void run_against(T item);
    }
}