namespace gorilla.commons.utility
{
    public interface IContextFactory
    {
        IContext create_for(IScopedStorage storage);
    }
}