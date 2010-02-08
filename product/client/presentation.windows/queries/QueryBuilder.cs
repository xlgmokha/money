namespace presentation.windows.queries
{
    public interface QueryBuilder
    {
        Query build<Query>() where Query : class;
    }
}