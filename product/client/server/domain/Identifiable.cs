namespace presentation.windows.server.domain
{
    public interface Identifiable<T>
    {
        T id { get; }
    }
}